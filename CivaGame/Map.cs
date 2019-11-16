using System;
using System.Collections.Generic;
using System.Text;

namespace CivaGame
{
    public class Map : IMap
    {
        private static IMap[,] WorldMap;

        public void CreateMap(int mapWidth, int mapHeight)
        {
            var rnd = new Random();
            WorldMap = new IMap[mapWidth, mapHeight];
            for (var i = 0; i < mapWidth; i++)
                for (var j = 0; j < mapHeight; j++)
                {
                    var value = rnd.Next(0, 100);
                    if (value < 10) WorldMap[i, j] = new Cave();
                    if (value > 60) WorldMap[i, j] = new Forest();
                    else WorldMap[i, j] = new Grass();
                }
        }

        public IMap GetCellType(int x, int y)
        {
            return WorldMap[x, y];
        }

        public static void Interact(int x, int y)
        {
            if (WorldMap[x,y] is Grass)
                InteractWithGrass(x, y);
            if (WorldMap[x, y] is Forest)
                InteractWithForest(x, y);
            if (WorldMap[x, y] is Cave)
                InteractWithCave(x, y);
        }

        private static void InteractWithGrass(int x, int y)
        {
            WorldMap[x, y] = CellType.EmptyGrass;
            // получает еду
        }

        private static void InteractWithForest(int x, int y)
        {
            //если есть топор делает ето
            WorldMap[x, y] = CellType.Grass;
            // получает доски 
        }

        private static void InteractWithCave(int x, int y)
        {
            // 
        }

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }

    class Grass : IMap
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }

    class EmptyGrass : IMap
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }

    class Forest : IMap
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }

    class Cave : IMap
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }

    class Church : IMap
    {
        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }
    }
}
