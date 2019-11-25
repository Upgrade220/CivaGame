using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CivaGame
{
    public class Game
    {
        public int MapSizeX { get; }
        public int MapSizeY { get; }
        public int Money { get; private set; }
        public GameState CurrentState { get; private set; }
        public Player Player { get; private set; }
        public Map Map { get; private set; }
        public Trader Trader { get; private set; }
        public const int ElementSize = 100;

        public Game()
        {
            CurrentState = GameState.Menu;
            Money = 0;
            MapSizeX = MapSizeY = 9;
        }

        public Point GetPlayerPosition()
        {
            return new Point(Player.X, Player.Y);
        }

        public void StartAction()
        {
            var rnd = new Random();
            var playerX = rnd.Next(0, MapSizeX - 1);
            var playerY = rnd.Next(0, MapSizeY - 1);
            var traderX = rnd.Next(0, MapSizeX - 1);
            var traderY = rnd.Next(0, MapSizeY - 1);
            CurrentState = GameState.Action;
            Player = new Player(playerX, playerY, 1);
            Map = new Map(MapSizeX, MapSizeY);
            Trader = new Trader(traderX, traderY);
        }

        public int EndAction()
        {
            CurrentState = GameState.Score;
            return Money;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    if (Map.IsInBorders(Player.X, Player.Y - 1))
                        Player.Y--;
                    else
                        Player.Y = MapSizeY - 1;
                    break;
                case Direction.Up:
                    if (Map.IsInBorders(Player.X, Player.Y + 1))
                        Player.Y++;
                    else
                        Player.Y = 0;
                    break;
                case Direction.Left:
                    if (Map.IsInBorders(Player.X - 1, Player.Y))
                        Player.X--;
                    else
                        Player.X = MapSizeX - 1;
                    break;
                case Direction.Right:
                    if (Map.IsInBorders(Player.X + 1, Player.Y))
                        Player.X++;
                    else
                        Player.X = 0;
                    break;
            }
        }

        public void PlayerEat(int inventoryIndex)
        {
            if (Player.Inventory[inventoryIndex] is FoodItem)
                Player.UseItem(inventoryIndex, 1);
        }

        public void PlayerBuy(IItem item)
        {
            if ((Player.X == Trader.X) && (Player.Y == Trader.Y))
            {
                if (item is Axe && Money >= 50)
                {
                    Player.AddItem(new Axe(), new EmptyItem());
                    ChangeMoney(-50);
                }
                else if (item is Pickaxe && Money >= 100)
                {
                    Player.AddItem(new Pickaxe(), new EmptyItem());
                    ChangeMoney(-100);
                }
            }
        }

        public bool PlayerBuildChurch()
        {
            if (Player.BuildChurch())
            {
                Map.BuildChurch(Player.X, Player.Y);
                return true;
            }
            return false;
        }

        public void InteractPlayerWithMap(int inventoryIndex)
        {
            var rnd = new Random();
            var cell = Map.Interact(Player.X, Player.Y, Player.Inventory[inventoryIndex]);
            var selectedItem = Player.Inventory[inventoryIndex];
            if (cell is Map.Grass)
            {
                if (Player.AddItem(new FoodItem(), new EmptyItem()))
                    ChangeMoney(5);
            }
            else if (cell is Map.Forest)
            {
                if (Player.AddItem(new Wood(), selectedItem))
                {
                    ChangeMoney(10);
                    var value = rnd.Next(0, 100);
                    if (value < 5)
                    {
                        ChangeMoney(-10);
                        Player.GetDamage(49);
                    }
                }
            }
            else if (cell is Map.Cave)
            {
                if (Player.AddItem(new Stone(), selectedItem))
                {
                    ChangeMoney(15);
                    var value = rnd.Next(0, 100);
                    if (value < 10)
                    {
                        if (Player.AddItem(new Gold(), selectedItem))
                            ChangeMoney(100);
                    }
                    value = rnd.Next(0, 100);
                    if (value < 10)
                    {
                        ChangeMoney(-150);
                        Player.GetDamage(25);
                    }
                }
            }
        }

        private void ChangeMoney(int delta)
        {
            if ((Money + delta) < 0)
                Money = 0;
            else
                Money += delta;
        }
    }
}
