using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    public class Map 
    {
        private int mapWidth;
        private int mapHeight;
        public ICell[,] WorldMap { get; }

        public Map(int x, int y)
        {
            mapWidth = x;
            mapHeight = y;
            var rnd = new Random();
            for (var i = 0; i < mapWidth; i++)
                for (var j = 0; j < mapHeight; j++)
                {
                    var value = rnd.Next(0, 100);
                    if (value < 10) WorldMap[i, j] = new Cave();
                    if (value > 60) WorldMap[i, j] = new Forest();
                    else WorldMap[i, j] = new Grass();
                }
        }

        public ICell GetCellType(int x, int y)
        {
            return WorldMap[x, y];
        }

        public bool IsInBorders(int x,int y)
        {
            return (x >= 0 && x < mapWidth && y >= 0 && y < mapHeight);
        }
    }

    class Grass : ICell
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }
    }

    class EmptyGrass : ICell
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }
    }

    class Forest : ICell
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }
    }

    class Cave : ICell
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }
    }

    class Church : ICell
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

        public void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
