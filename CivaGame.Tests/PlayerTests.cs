using NUnit.Framework;
using CivaGame;
using FluentAssertions;

namespace Tests
{
    public class PlayerTests
    {
        [Test]
        public void FoodTests()
        {
            var player = new Player(0, 0, 1);
            player.ChangeFood(-20);
            player.Food.Should().Be(80);
            player.ChangeFood(-100);
            player.IsAlive.Should().BeFalse();
        }

        [Test]
        public void DamageTests()
        {
            var player = new Player(0, 0, 1);
            player.GetDamage(20);
            player.IsAlive.Should().BeTrue();
            player.GetDamage(100);
            player.IsAlive.Should().BeFalse();
        }

        [Test]
        public void HealDamage()
        {
            var player = new Player(0, 0, 1);
            player.GetDamage(20);
            player.AddItem(new FoodItem());
            player.UseItem(0, 1);
            player.HP.Should().Be(100);
        }

        [Test]
        public void AddItemToStack()
        {
            var player = new Player(0, 0, 1);
            player.AddItem(new FoodItem());
            player.AddItem(new FoodItem());
            player.InventoryItemsCount[0].Should().Be(2);
        }

        [Test]
        public void BuilChurchTest()
        {
            var player = new Player(0, 0, 1);
            for (var i = 0; i < 10; i++) 
                player.AddItem(new Wood());
            for (var i = 0; i < 5; i++)
                player.AddItem(new Stone());
            player.AddItem(new Gold());
            player.BuildChurch().Should().BeTrue();
        }

        [Test]
        public void kaAa()
        {
            var player = new Player(0, 0, 1);

        }
    }
}
