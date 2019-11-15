using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    class Game
    {
        int MapSize;
        int Score;
        GameState CurrentState;
        Player Player;

        public void Inicialise()
        {
        }

        public void StartAction()
        {
        }

        public void ChangeSrore(int delta)
        {
            if ((Score + delta) < 0)
                Score = 0;
            else
                Score += delta;
        }

        public void SetGameState (GameState newState)
        {
            CurrentState = newState;
        }
    }
}
