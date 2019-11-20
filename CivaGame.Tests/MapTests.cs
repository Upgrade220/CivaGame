using NUnit.Framework;
using CivaGame;
using FluentAssertions;

namespace Tests
{
    public class MapTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

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
        public void kek()
        {
            var map = new Map(50, 50);
            ICell cell;
            for (var i = 0; i < 50; i++)
                for (var j = 0; j < 50; j++)
                {
                    if (map.WorldMap[i, j] is Map.Grass)
                    {
                        cell = map.WorldMap[i, j];
                        map.Interact(i, j, new EmptyItem());
                    }

                }
        }
    }
}