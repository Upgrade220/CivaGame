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
        }
    }
}