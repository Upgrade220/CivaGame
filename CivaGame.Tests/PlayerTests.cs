using NUnit.Framework;
using CivaGame;
using FluentAssertions;

namespace Tests
{
    public class PlayerTests
    {
        [Test]
        public void BorderTest()
        {
            var player = new Player(0, 0, 1);
            player.ChangeFood(-20);
            player.Food.Should().Be(80);
        }
    }
}
