using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
                
            }
            //10
            ExplodingBlock exBlock = new ExplodingBlock(new MatrixCoords(4,30));
            engine.AddObject(exBlock);
            //END 10

            //01.The AcademyPopcorn class contains an IndestructibleBlock class. 
            //Use it to create side and ceiling walls to the game. You can ONLY edit the 
            //AcademyPopcornMain.cs file.

            for (int row = 0; row < 40; row++)
            {
                IndestructibleBlock leftSideBlock = new IndestructibleBlock(new MatrixCoords(row, 0));
                IndestructibleBlock rightSideBlock = new IndestructibleBlock(new MatrixCoords(row, WorldCols - 1));
                engine.AddObject(leftSideBlock);
                engine.AddObject(rightSideBlock);
            }

            for (int col = 0; col < WorldCols; col++)
            {
                IndestructibleBlock ceilingBlock = new IndestructibleBlock(new MatrixCoords(0, col));
                engine.AddObject(ceilingBlock);
            }
            //END 01

            //05
            TrailObject trailObj = new TrailObject(new MatrixCoords(8, 8), 8);
            //engine.AddObject(trailObj);
            //END 05

            //07.Test the MeteoriteBall by replacing the normal ball in the AcademyPopcornMain.cs file.
            //MeteoriteBall metBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(metBall);
            //END 07

            //09
            ImpassableBlock imPassBlock = new ImpassableBlock(new MatrixCoords(4, 7));
            engine.AddObject(imPassBlock);
            UnstoppableBall unstopBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            engine.AddObject(unstopBall);
            //END 09

            //12
            GiftBlock gift = new GiftBlock(new MatrixCoords(7,25));
            engine.AddObject(gift);
            //END 12

            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootEngine gameEngine = new ShootEngine(renderer, keyboard, 200);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
