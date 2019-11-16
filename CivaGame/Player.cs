using System;
using System.Drawing;

namespace CivaGame
{
    public class Player : ICreature
    {
        public static int HP { get; private set; }
        public static int X { get; private set; }
        public static int Y { get; private set; }
        public static int Food { get; private set; }
        public static IItem[] Inventory { get; set; }

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

        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up :
                    if()
                    Y--;
                    break;
                case Direction.Down :
                    Y++;
                    break;
                case Direction.Left :
                    X--;
                    break;
                case Direction.Right :
                    X++;
                    break;
            }
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
