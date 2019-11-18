using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    class Trader : ICreature
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Trader (int x, int y)
        {
            X = x;
            Y = y;
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public string GetImageFileName()
        {
            return "Trader.png";
        }
    }
}
