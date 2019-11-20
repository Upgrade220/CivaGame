using NUnit.Framework;
using CivaGame;
using FluentAssertions;

namespace Tests
{
    public class GameTests
    {
        [Test]
        public void GetplayerPositionTests()
        {
            var game = new Game();
            game.StartAction();
            game.GetPlayerPosition().X.Should().BeLessThan(9);
            game.GetPlayerPosition().X.Should().BeGreaterOrEqualTo(0);
            game.GetPlayerPosition().Y.Should().BeLessThan(9);
            game.GetPlayerPosition().Y.Should().BeGreaterOrEqualTo(0);
        }

        [Test]
        public void MoveTests()
        {
            var game = new Game();
            game.StartAction();
            game.Player.X = 8;
            game.Player.Y = 8;
            game.Move(Direction.Up);
            game.Player.Y.Should().Be(0);
            game.Move(Direction.Right);
            game.Player.X.Should().Be(0);
            game.Move(Direction.Down);
            game.Player.Y.Should().Be(8);
            game.Move(Direction.Left);
            game.Player.X.Should().Be(8);
        }

        [Test]
        public void PlayerEatTests()
        {
            var game = new Game();
            game.StartAction();
            game.Player.AddItem(new FoodItem());
            game.PlayerEat(0);
            game.Player.InventoryItemsCount[0].Should().Be(0);
        }
    }
}
