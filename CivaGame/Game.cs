using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CivaGame
{
    class Game
    {
        public int MapSizeX { get; private set; }
        public int MapSizeY { get; private set; }
        public int Score { get; private set; }
        public GameState CurrentState { get; private set; }
        Player Player;
        Map Map;

        public Game(int x, int y)
        {
            CurrentState = GameState.Menu;
            Score = 0;
        }

        public Point GetPlayerPosition()
        {
            return new Point(Player.X, Player.Y);
        }

        public void StartAction(int x, int y)
        {
            var rnd = new Random();
            var playerX = rnd.Next(0, x);
            var playerY = rnd.Next(0, y);
            CurrentState = GameState.Action;
            Player = new Player(playerX,playerY);
            Map = new Map(x, y);
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
