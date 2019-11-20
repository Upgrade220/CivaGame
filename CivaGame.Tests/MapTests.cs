using NUnit.Framework;
using CivaGame;
using FluentAssertions;

namespace Tests
{
    public class MapTests
    {

        [Test]
        public void BorderTests()
        {
            var map = new Map(2, 2);
            map.IsInBorders(1, 1).Should().BeTrue();
            map.IsInBorders(0, 0).Should().BeTrue();
            map.IsInBorders(-1, -1).Should().BeFalse();
            map.IsInBorders(2, 2).Should().BeFalse();
        }
        [Test]
        public void ChurchBuildingTests()
        {
            var map = new Map(2, 2);
            map.BuildChurch(1, 1);
            map.WorldMap[1, 1].Should().BeOfType<Map.Church>();
        }

        [Test]
        public void InteractWithGrassTest()
        {
            var map = new Map(50, 50);
            ICell cell = null;
            for (var i = 0; i < 50; i++)
                for (var j = 0; j < 50; j++)
                {
                    if (map.WorldMap[i, j] is Map.Grass)
                    {
                        map.Interact(i, j, new EmptyItem());
                        cell = map.WorldMap[i, j];
                        break;
                    }
                }
            cell.Should().BeOfType<Map.EmptyGrass>();
        }

        [Test]
        public void InteractWithForest()
        {
            var map = new Map(50, 50);
            ICell cell = null;
            for (var i = 0; i < 50; i++)
                for (var j = 0; j < 50; j++)
                {
                    if (map.WorldMap[i, j] is Map.Forest)
                    {
                        map.Interact(i, j, new Axe());
                        cell = map.WorldMap[i, j];
                        break;
                    }
                }
            cell.Should().BeOfType<Map.Grass>();
        }
    }
}