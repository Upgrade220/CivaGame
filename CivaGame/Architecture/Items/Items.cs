using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    class EmptyItem : IItem
    {
        public string GetImageFileName()
        {
            return "EmptyItem.png";
        }

        public int MaxStack()
        {
            return 0;
        }
    }

    class Food : IItem
    {
        public string GetImageFileName()
        {
            return "Food.png";
        }

        public int MaxStack()
        {
            return 8;
        }
    }

    class Wood : IItem
    {
        public string GetImageFileName()
        {
            return "Wood.png";
        }

        public int MaxStack()
        {
            return 16;
        }
    }

    class Stone : IItem
    {
        public string GetImageFileName()
        {
            return "Stone.png";
        }

        public int MaxStack()
        {
            return 16;
        }
    }

    class Gold : IItem
    {
        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public int MaxStack()
        {
            return 16;
        }
    }

    class Axe : IItem
    {
        public string GetImageFileName()
        {
            return "Axe.png";
        }

        public int MaxStack()
        {
            return 1;
        }
    }

    class Pickaxe : IItem
    {
        public string GetImageFileName()
        {
            return "Pickaxe.png";
        }

        public int MaxStack()
        {
            return 1;
        }
    }
}
