﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    public class EmptyItem : IItem
    {
        public string GetImageFileName()
        {
            return "EmptyItem.png";
        }

        public int MaxStack()
        {
            return 0;
        }

        public Type RequiredItem()
        {
            return typeof(EmptyItem);
        }
    }

    public class FoodItem : IItem
    {
        public string GetImageFileName()
        {
            return "Food.png";
        }

        public int MaxStack()
        {
            return 8;
        }

        public Type RequiredItem()
        {
            return typeof(EmptyItem);
        }
    }

    public class Wood : IItem
    {
        public string GetImageFileName()
        {
            return "Wood.png";
        }

        public int MaxStack()
        {
            return 64;
        }

        public Type RequiredItem()
        {
            return typeof(Axe);
        }
    }

    public class Stone : IItem
    {
        public string GetImageFileName()
        {
            return "Stone.png";
        }

        public int MaxStack()
        {
            return 64;
        }

        public Type RequiredItem()
        {
            return typeof(Pickaxe);
        }
    }

    public class Gold : IItem
    {
        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public int MaxStack()
        {
            return 64;
        }

        public Type RequiredItem()
        {
            return typeof(Pickaxe);
        }
    }

    public class Axe : IItem
    {
        public string GetImageFileName()
        {
            return "Axe.png";
        }

        public int MaxStack()
        {
            return 1;
        }

        public Type RequiredItem()
        {
            return typeof(EmptyItem);
        }
    }

    public class Pickaxe : IItem
    {
        public string GetImageFileName()
        {
            return "Pickaxe.png";
        }

        public int MaxStack()
        {
            return 1;
        }

        public Type RequiredItem()
        {
            return typeof(EmptyItem);
        }
    }
}
