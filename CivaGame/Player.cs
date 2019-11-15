using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    public class Player : ICreature
    {
        int HP;
        int X, Y;
        int Food;

        public CreatureCommand Act(int x, int y)
        {
        }

        public void GetDamage (int damageValue)
        {
            HP -= damageValue;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

        public void Heal (int healValue)
        {
            if ((HP + healValue) > 100)
                HP = 100;
            else
                HP += healValue;
        }
    }
}
