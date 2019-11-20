using NUnit.Framework;
using CivaGame;
using FluentAssertions;

namespace Tests
{
    public class Tests
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
            map.WorldMap[1, 1].Should().BeOfType(Map.Church);
        }
    }
}