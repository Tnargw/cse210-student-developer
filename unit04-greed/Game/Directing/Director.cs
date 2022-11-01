using System;
using System.Collections.Generic;
using unit04_greed.Game.Casting;
using unit04_greed.Game.Services;



namespace unit04_greed.Game.Directing
{
    
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private static int Counter = 0;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_ARTIFACTS = 2;
        private KeyboardService _keyboardService = null;
        private VideoService _videoService = null;
        
        private int Score = 0;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this._keyboardService = keyboardService;
            this._videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            _videoService.OpenWindow();
            while (_videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            _videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = _keyboardService.GetDirection();
            robot.SetVelocity(velocity);     
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// Ensures there are at least 50 actors on screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> artifacts = cast.GetActors("artifacts");

            banner.SetText("Score: " + Score);
            int maxX = _videoService.GetWidth();
            int maxY = _videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            if (cast.GetAllActors().Count < 50)
            {
                SpawnStuff(cast);
                Counter += 1;
            }
            
            foreach (Actor actor in artifacts)
            {
                actor.MoveArtifact(maxX, maxY);
                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    Artifact artifact = (Artifact) actor;
                    string message = artifact.GetMessage();
                    if (message == "-1")
                    {
                        Score -= 1;
                        cast.RemoveActor("artifacts", actor);
                    }
                    else if (message == "+1")
                    {
                        Score += 1;
                        cast.RemoveActor("artifacts", actor);
                    }
                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            _videoService.ClearBuffer();
            _videoService.DrawActors(actors);
            _videoService.FlushBuffer();
        }

        /// <summary>
        /// Spawns the artifacts for the game and adds them to the cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void SpawnStuff(Cast cast)
        {
            // create the artifacts
            if (Counter % 2 == 0)
            {
                Random random = new Random();
                int speed = random.Next(1,7);
                int x = random.Next(1, COLS);
                int y = 1;
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText("*");
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetMessage("+1");
                artifact.SetSpeed(speed);
                cast.AddActor("artifacts", artifact);
            }
            else
            {
                Random random = new Random();
                int speed = random.Next(1,7);
                int x = random.Next(1, COLS);
                int y = 1;
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText("O");
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetMessage("-1");
                artifact.SetSpeed(speed);
                cast.AddActor("artifacts", artifact);
            }
        }




    }
}