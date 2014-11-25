namespace TicTacToe.Web.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Web.Http;

    using Antlr.Runtime.Tree;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using TicTacToe.Data;
    using TicTacToe.Models;
    using TicTacToe.Web.DataModels;

    [Authorize]
    public class GameController : ApiController
    {
        private readonly ITicTacToeData data;

        public GameController(ITicTacToeData data)
        {
            this.data = data;
        }

        [HttpPost]
        public IHttpActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var game = new Game { FirstPlayerId = userId };
            this.data.Games.Add(game);
            this.data.SaveChanges();

            var gameDataModel =
                this.data.Games.All()
                    .Where(x => x.Id == game.Id)
                    .Project()
                    .To<GameInfoDataModel>()
                    .FirstOrDefault();

            return this.Ok(gameDataModel);
        }

        [HttpPost]
        public IHttpActionResult Join()
        {
            var userId = User.Identity.GetUserId();

            var firstAvailableGame =
                this.data.Games.All()
                    .FirstOrDefault(x => x.State == GameState.WaitingForSecondPlayer && x.FirstPlayerId != userId);

            if (firstAvailableGame == null)
            {
                return this.NotFound();
            }

            firstAvailableGame.SecondPlayerId = userId;
            firstAvailableGame.State = GameState.TurnX;
            this.data.SaveChanges();

            var gameDataModel =
                this.data.Games.All()
                    .Where(x => x.Id == firstAvailableGame.Id)
                    .Project()
                    .To<GameInfoDataModel>()
                    .FirstOrDefault();

            return this.Ok(gameDataModel);
        }

        [HttpGet]
        public IHttpActionResult Status([Required]string gameId)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var gameIdAsGuid = new Guid(gameId);
            var gameDataModel =
                this.data.Games.All()
                    .Where(x => x.Id == gameIdAsGuid && (x.FirstPlayerId == userId || x.SecondPlayerId == userId))
                    .Project()
                    .To<GameInfoDataModel>()
                    .FirstOrDefault();

            if (gameDataModel == null)
            {
                return this.NotFound();
            }

            return this.Ok(gameDataModel);
        }

        [HttpPost]
        public IHttpActionResult Play([FromUri]PlayRequestDataModel request)
        {
            var userId = User.Identity.GetUserId();

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var gameIdAsGuid = new Guid(request.GameId);
            var game =
                this.data.Games.All()
                    .FirstOrDefault(
                        x => x.Id == gameIdAsGuid && (x.FirstPlayerId == userId || x.SecondPlayerId == userId));

            if (game == null)
            {
                return this.NotFound();
            }

            if (game.State != GameState.TurnX && game.State != GameState.TurnO)
            {
                return this.BadRequest(string.Format("Invalid game state: {0}", game.State));
            }

            if ((game.State == GameState.TurnX && game.FirstPlayerId != userId)
                || (game.State == GameState.TurnO && game.SecondPlayerId != userId))
            {
                return this.BadRequest(string.Format("It's not your turn!"));
            }

            int positionIndex = ((request.Row - 1) * 3) + request.Col - 1;
            if (game.Board[positionIndex] != '-')
            {
                return this.BadRequest("This position is already taken. Please choose a different one.");
            }

            var board = new StringBuilder(game.Board);
            board[positionIndex] = game.State == GameState.TurnX ? 'X' : 'O';
            var boardAsString = board.ToString();
            game.Board = boardAsString;
            game.State = game.State == GameState.TurnX ? GameState.TurnO : GameState.TurnX;

            var gameResult = this.CheckGameResult(game.Board);
            var user = this.data.Users.All().First(u => u.Id == userId);
            switch (gameResult)
            {
                case GameResult.XWins:
                    game.State = GameState.GameWonByX;
                    user.Scores += 100;
                    break;
                case GameResult.OWins:
                    game.State = GameState.GameWonByO;
                    user = this.data.Users.All().First(u => u.Id == userId);
                    user.Scores += 100;
                    break;
                case GameResult.Draw:
                    game.State = GameState.GameDraw;
                    break;
            }

            this.data.SaveChanges();

            var gameDataModel =
                this.data.Games.All()
                    .Where(x => x.Id == gameIdAsGuid && (x.FirstPlayerId == userId || x.SecondPlayerId == userId))
                    .Project()
                    .To<GameInfoDataModel>()
                    .FirstOrDefault();

            return this.Ok(gameDataModel);
        }

        public GameResult CheckGameResult(string boardAsString)
        {
            var board = new char[3, 3];
            for (int i = 0; i < boardAsString.Length; i++)
            {
                int row = i / 3;
                int col = i % 3;
                board[row, col] = boardAsString[i];
            }

            var gameResultIfWonOrNotFinished = CheckBoardLinesForWinner(board);
            if (gameResultIfWonOrNotFinished != GameResult.NotFinished)
            {
                return gameResultIfWonOrNotFinished;
            }
            else if (!boardAsString.Contains('-'))
            {
                return GameResult.Draw;
            }
            else
            {
                return GameResult.NotFinished;
            }
        }

        private GameResult CheckBoardLinesForWinner(char[,] board)
        {
            bool[] allLines = new bool[8];
            //cols
            allLines[0] = board[0, 0] != '-' && board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0];
            allLines[1] = board[0, 1] != '-' & board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1];
            allLines[2] = board[0, 2] != '-' && board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2];
            //rows
            allLines[3] = board[0, 0] != '-' && board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2];
            allLines[4] = board[1, 0] != '-' && board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2];
            allLines[5] = board[2, 0] != '-' && board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2];

            //diagonals
            allLines[6] = board[0, 0] != '-' && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2];
            allLines[7] = board[0, 2] != '-' && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0];

            for (int i = 0; i < allLines.Length; i++)
            {
                if (allLines[i])
                {
                    switch (i)
                    {
                        case 0: return GetWonGameByUserFromSymbol(board[0, 0]);
                        case 1: return GetWonGameByUserFromSymbol(board[0, 1]);
                        case 2: return GetWonGameByUserFromSymbol(board[0, 3]);
                        case 3: return GetWonGameByUserFromSymbol(board[0, 0]);
                        case 4: return GetWonGameByUserFromSymbol(board[1, 0]);
                        case 5: return GetWonGameByUserFromSymbol(board[2, 0]);
                        case 6: return GetWonGameByUserFromSymbol(board[2, 2]);
                        case 7: return GetWonGameByUserFromSymbol(board[2, 2]);

                    }
                }
            }

            return GameResult.NotFinished;
        }

        private GameResult GetWonGameByUserFromSymbol(char symbol)
        {
            if (symbol == 'O')
            {
                return GameResult.OWins;
            }
            else if (symbol == 'X')
            {
                return GameResult.XWins;
            }
            else
            {
                throw new ArgumentException("Invalid player symbol!");
            }
        }
    }
}
