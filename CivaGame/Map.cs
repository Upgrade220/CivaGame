using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    public class Map
    {
        readonly int mapWidth;
        readonly int mapHeight;
        public static ICell[,] WorldMap;

        public Map(int x, int y)
        {
            mapWidth = x;
            mapHeight = y;
            var rnd = new Random();
            WorldMap = new ICell[mapWidth, mapHeight];
            for (var i = 0; i < mapWidth; i++)
                for (var j = 0; j < mapHeight; j++)
                {
                    var value = rnd.Next(0, 100);
                    if (value < 10) WorldMap[i, j] = new Cave();
                    else if (value > 60) WorldMap[i, j] = new Forest();
                    else WorldMap[i, j] = new Grass();
                }
        }

        public bool IsInBorders(int x, int y)
        {
            return (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight);
        }

        public void BuildChurch(int x, int y)
        {
            WorldMap[x, y] = new Church();
        }

        public ICell Interact(int x, int y, IItem item)
        {
            var cell = WorldMap[x, y];
            if (cell is Forest && item is Axe)
                WorldMap[x, y] = new Grass();
            else if (cell is Grass)
                WorldMap[x, y] = new EmptyGrass();
            return cell;
        }

        public class Grass : ICell
        {
            public string GetImageFileName()
            {
                return "Grass.png";
            }
        }

        public class EmptyGrass : ICell
        {
            public string GetImageFileName()
            {
                return "EmptyGrass.png";
            }
        }

        public class Forest : ICell
        {
            public string GetImageFileName()
            {
                return "Forest.png";
            }
        }

        public class Cave : ICell
        {
            public string GetImageFileName()
            {
                return "Cave.png";
            }
        }

        public class Church : ICell
        {
            public string GetImageFileName()
            {
                return "Church.png";
            }
        }
    }
}
