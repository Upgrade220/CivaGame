using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CivaGame
{
    class Game
    {
        public int MapSizeX { get; }
        public int MapSizeY { get; }
        public static int Score { get; private set; }
        public static GameState CurrentState { get; private set; }
        public static Player Player { get; private set; }
        public static Map Map { get; private set; }

        public Game()
        {
            CurrentState = GameState.Menu;
            Score = 0;
            MapSizeX = MapSizeY = 9;
        }

        public Point GetPlayerPosition()
        {
            return new Point(Player.X, Player.Y);
        }

        public void StartAction()
        {
            var rnd = new Random();
            var playerX = rnd.Next(0, MapSizeX - 1);
            var playerY = rnd.Next(0, MapSizeY - 1);
            CurrentState = GameState.Action;
            Player = new Player(playerX,playerY);
            Map = new Map(MapSizeX, MapSizeY);
        }

        public int EndAction()
        {
            CurrentState = GameState.Score;
            return Score;
        }

        public void ChangeScore(int delta)
        {
            if ((Score + delta) < 0)
                Score = 0;
            else
                Score += delta;
        }
    }
}
