using System;
using System.Drawing;

namespace CivaGame
{
    public class Player : ICreature
    {
        public int HP { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Food { get; private set; }
        public IItem[] Inventory { get; set; }

        public Player(int x, int y)
        {
            HP = 100;
            X = x;
            Y = y;
        }

        public void ChangeFood (int food)
        {
            if ((Food + food) <= 0)
                HP = 0;
            else if ((Food + food) > 100)
                Food = 100;
            else
                Food += food;
        }

        public void GetDamage (int damageValue)
        {
            HP -= damageValue;
        }

        public void Heal (int healValue)
        {
            if ((HP + healValue) > 100)
                HP = 100;
            else
                HP += healValue;
        }

        public Point ReturnPosition()
        {
            return new Point(X, Y);
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

    }
}
