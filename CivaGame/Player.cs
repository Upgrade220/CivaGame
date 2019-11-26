﻿using System;
using System.Drawing;
using System.Linq;

namespace CivaGame
{
    public class Player : ICreature
    {
        public int HP { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Food { get; private set; }
        public bool IsAlive { get; private set; }
        public IItem[] Inventory { get; private set; }
        public int[] InventoryItemsCount { get; private set; }
        private bool IsEnoughForChurch;
        private int WoodCount, StoneCount, GoldCount;
        private readonly int DifficultyRate;

        public Player(int x, int y, int difficultyRate)
        {
            var inventoryLength = 8;
            HP = 100;
            X = x;
            Y = y;
            Food = 100;
            IsAlive = true;
            IsEnoughForChurch = false;
            Inventory = new IItem[inventoryLength];
            InventoryItemsCount = new int[inventoryLength];
            for (int i = 0; i < inventoryLength; i++)
            {
                InventoryItemsCount[i] = 0;
                Inventory[i] = new EmptyItem();
            }
            WoodCount = 0;
            StoneCount = 0; 
            GoldCount = 0;
            if (difficultyRate * 10 >= 64)
                DifficultyRate = 10;
            else
                DifficultyRate = difficultyRate;
        }

        public void ChangeFood (int food)
        {
            if ((Food + food) <= 0)
            {
                HP = 0;
                IsAlive = false;
            }
            else if ((Food + food) > 100)
                Food = 100;
            else
                Food += food;
        }

        public void GetDamage (int damageValue)
        {
            if (damageValue > 0)
            {
                if ((HP - damageValue) <= 0)
                {
                    IsAlive = false;
                    HP = 0;
                }
                else
                    HP -= damageValue;
            }
        }

        private void Heal (int healValue)
        {
            if ((HP + healValue) > 100)
                HP = 100;
            else
                HP += healValue;
            HP.GetType();
        }

        public bool AddItem(IItem item, IItem selectedItem)
        {
            bool succes = true;
            for (var i = 0; i <= Inventory.Length - 1; i++)
                if (Inventory[i].GetType() == item.GetType()
                    && item.RequiredItem() == selectedItem.GetType()
                    && InventoryItemsCount[i] < Inventory[i].MaxStack())
                {
                    if (item is Wood)
                        InventoryItemsCount[i] += 3;
                    InventoryItemsCount[i]++;
                    break;
                }
                else if (Inventory[i] is EmptyItem
                    && item.RequiredItem() == selectedItem.GetType())
                {
                    Inventory[i] = item;
                    if (item is Wood)
                        InventoryItemsCount[i] = 3;
                    InventoryItemsCount[i] += 1;
                    break;
                }
                else if (i == Inventory.Length - 1)
                    succes = false;
            if (succes)
            {
                if (item is Wood)
                    WoodCount+=4;
                else if (item is Stone)
                    StoneCount++;
                else if (item is Gold)
                    GoldCount++;
                if (WoodCount >= DifficultyRate * 10 && StoneCount >= DifficultyRate * 5 && GoldCount >= DifficultyRate)
                    IsEnoughForChurch = true;
            }
            return succes;
        }

        public bool BuildChurch()
        {
            var woodFlag = true;
            var stoneFlag = true;
            var goldFlag = true;
            if (IsEnoughForChurch)
            {
                for (var i = 0; i < Inventory.Length; i++)
                {
                    var item = Inventory[i];
                    if (item is Wood && woodFlag)
                    {
                        WoodCount -= DifficultyRate * 10;
                        woodFlag = false;
                        InventoryItemsCount[i] -= DifficultyRate * 10;
                    }
                    else if (item is Stone && stoneFlag)
                    {
                        StoneCount -= DifficultyRate * 5;
                        stoneFlag = false;
                        InventoryItemsCount[i] -= DifficultyRate * 5;
                    }
                    else if (item is Gold && goldFlag)
                    {
                        GoldCount -= DifficultyRate;
                        goldFlag = false;
                        InventoryItemsCount[i] -= DifficultyRate;
                    }
                }
                if (WoodCount >= DifficultyRate * 10 && StoneCount >= DifficultyRate * 5 && GoldCount >= DifficultyRate)
                    IsEnoughForChurch = true;
                else
                    IsEnoughForChurch = false;
                return true;
            }
            return false;
        }

        public IItem UseItem(int i, int count)
        {
            var item = Inventory[i];
            if (item is FoodItem)
            {
                Heal(25);
                ChangeFood(50);
            }
            if(!(item is Axe) || !(item is Pickaxe))
                InventoryItemsCount[i] -= count;
            if (InventoryItemsCount[i] <= 0)
            {
                Inventory[i] = new EmptyItem();
                InventoryItemsCount[i] = 0;
            }
            return item;
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            return "Player.png";
        }

    }
}
