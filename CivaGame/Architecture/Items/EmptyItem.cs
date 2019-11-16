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
    }

    class Food : IItem
    {
        public string GetImageFileName()
        {
            return "Food.png";
        }
    }

    class Wood : IItem
    {
        public string GetImageFileName()
        {
            return "Wood.png";
        }
    }

    class Stone : IItem
    {
        public string GetImageFileName()
        {
            return "Stone.png";
        }
    }

    class Gold : IItem
    {
        public string GetImageFileName()
        {
            return "Gold.png";
        }
    }

    class Axe : IItem
    {
        public string GetImageFileName()
        {
            return "Axe.png";
        }
    }

    class Pickaxe : IItem
    {
        public string GetImageFileName()
        {
            return "Pickaxe.png";
        }
    }
}
