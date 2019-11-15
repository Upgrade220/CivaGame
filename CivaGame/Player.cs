using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CivaGame
{
    public class Player : ICreature
    {
        int HP;
        int X, Y;
        int Food;
        public IItem[] Inventory { get; }

        public Player()
        {
            HP = 100;
            X = 0;
            Y = 0;
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

        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Up :
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
