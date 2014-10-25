using Exam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Exam.WebServices.Models;
using Microsoft.AspNet.Identity;
using Exam.Models;

namespace Exam.WebServices.Controllers
{
    public class GamesController : BaseController
    {
        private const int DefaultGamesCount = 10;

        // TODO: uncomment ninject in Startup.cs and remove this empty constructor
        public GamesController()
            : base(new ExamData())
        {
        }

        public GamesController(IExamData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return GetByPage(0);
        }

        [HttpGet]
        public IHttpActionResult GetByPage(int page)
        {
            // TODO: refactor extract method
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.data
              .Users
              .All()
              .Where(x => x.Id == currentUserId)
              .FirstOrDefault();

            if (currentUser == null)
            {
                return GetUnauthenticatedGamesByPage(page);
            }

            // TODO: refactor this

            var ownGames = currentUser.Games
                .Where(g => g.State != GameState.WonByBlue && g.State != GameState.WonByRed)
                .OrderBy(g => g.State)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Take(DefaultGamesCount)
                .ToList();

            var modelled = ownGames.Select(g => new GameModel
                {
                    Red = g.RedPlayer.UserName,
                    DateCreated = g.DateCreated,
                    GameState = g.State.ToString(),
                    Id = g.Id,
                    Name = g.Name,
                })
                .ToList();


            if (modelled.Count == DefaultGamesCount)
            {
                return Ok(modelled);
            }
            else
            {
                int countOfOtherGames = DefaultGamesCount - modelled.Count;
                var otherGames = this.data.Games
                    .All()
                    .Where(g => g.RedPlayerId.ToString() != currentUserId &&
                        g.BluePlayerId.ToString() != currentUserId &&
                        g.State != GameState.WonByBlue &&
                        g.State != GameState.WonByRed)
                    .OrderBy(g => g.State)
                    .ThenBy(g => g.Name)
                    .ThenBy(g => g.DateCreated)
                    .ThenBy(g => g.RedPlayer.UserName)
                    .Take(countOfOtherGames)
                    .ToList();


                var modelledOther = new List<GameModel>();
                foreach (var g in otherGames)
                {
                    if (ownGames.Contains(g))
                    {
                        continue;
                    }

                    var user = g.RedPlayer != null ? g.RedPlayer.UserName : null;
                    var mod = new GameModel()
                    {
                        DateCreated = g.DateCreated,
                        GameState = g.State.ToString(),
                        Id = g.Id,
                        Name = g.Name,
                        Red = user,
                    };

                    modelledOther.Add(mod);
                }

                var result = modelled.Concat(modelledOther);
                return Ok(result);
            }

        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(GameModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.data
              .Users
              .All()
              .Where(x => x.Id == currentUserId)
              .FirstOrDefault();

            var game = new Game()
            {
                Name = model.Name,
                RedPlayer = currentUser,
                RedPlayerGuess = model.Number,
                DateCreated = DateTime.Now,
            };

            this.data.Games.Add(game);
            currentUser.Games.Add(game);
            this.data.SaveChanges();

            model.Id = game.Id;
            model.GameState = game.State.ToString();
            model.Red = currentUser.UserName;
            model.DateCreated = game.DateCreated;

            return Ok(model);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult Join(GameModel guess)
        {
            if (!ModelState.IsValidField("number"))
            {
                return BadRequest();
            }

            // TODO: refactor extract method
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.data
              .Users
              .All()
              .Where(x => x.Id == currentUserId)
              .FirstOrDefault();

            var games = this.data.Games.All().Where(g => g.RedPlayer != currentUser && g.BluePlayer == null).Select(g => g.Id).ToList();
            var random = new Random();
            var nextRandom = random.Next(0, games.Count + 1);
            var randomGameId = games[nextRandom];

            var theGame = this.data.Games.Find(randomGameId);
            theGame.BluePlayer = currentUser;

            if (nextRandom % 10 == 0)
            {
                theGame.State = GameState.BlueInTurn;
            }
            else
            {
                theGame.State = GameState.RedInTurn;
            }

            this.data.SaveChanges();

            return Ok(string.Format(@"{""result: "" ""You joined game ""{0}""}", theGame.Name));
        }



        [HttpGet]
        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            // TODO: refactor extract method
            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.data
              .Users
              .All()
              .Where(x => x.Id == currentUserId)
              .FirstOrDefault();

            var game = this.data
                .Games
                .Find(id);

            if (game == null)
            {
                return NotFound();
            }
            if (game.RedPlayer != currentUser && game.BluePlayer != currentUser)
            {
                return BadRequest("Not authorized to see others' games!");
            }

            var model = new GameModel()
            {
                Blue = game.BluePlayer.UserName,
                DateCreated = game.DateCreated,
                GameState = game.State.ToString(),
                Id = game.Id,
                Name = game.Name,
                Red = game.RedPlayer.UserName,
            };

            return Ok(model);

        }

        [NonAction]
        private IHttpActionResult GetUnauthenticatedGamesByPage(int page)
        {
            var games = this.data.Games
                .All()
                .Where(g => g.State == GameState.WaitingForOpponent)
                .OrderBy(g => g.State)
                    .ThenBy(g => g.Name)
                    .ThenBy(g => g.DateCreated)
                    .ThenBy(g => g.RedPlayer.UserName)
                    .Skip(page * DefaultGamesCount)
                    .Take(DefaultGamesCount)
                    .Select(g => new GameModel
                    {
                        Blue = g.BluePlayer.UserName,
                        DateCreated = g.DateCreated,
                        GameState = g.State.ToString(),
                        Id = g.Id,
                        Name = g.Name,
                        Red = g.RedPlayer.UserName,
                    })
                    .ToList();

            return Ok(games);
        }

    }
}
