using System;
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

        public Player(int x, int y)
        {
            var inventoryLenght = 8;
            HP = 100;
            X = x;
            Y = y;
            Food = 100;
            IsAlive = true;
            Inventory = new IItem[inventoryLenght];
            InventoryItemsCount = new int[inventoryLenght];
            for (int i = 0; i < 8; i++)
            {
                InventoryItemsCount[i] = 0;
                Inventory[i] = new EmptyItem();
            }
        }

        public void ChangeFood (int food)
        {
            if ((Food + food) <= 0)
                HP = 0;
            else if ((Food + food) > 100)
                Food = 100;
            else
                Food += food;
        }

        public void GetDamage (int damageValue)
        {
            if((HP - damageValue) <= 0)
            {
                IsAlive = false;
                HP = 0;
            }
            else
                HP -= damageValue;
        }

        public void Heal (int healValue)
        {
            if ((HP + healValue) > 100)
                HP = 100;
            else
                HP += healValue;
        }

        public void AddItem(IItem item)
        {
            var emptySlot = Inventory.Length;
            bool succes = true;
            for (var i = 0; i < Inventory.Length; i++)
                if (Inventory[i] == item && InventoryItemsCount[i] <= Inventory[i].MaxStack())
                {
                    InventoryItemsCount[i]++;
                    break;
                }
                else if (Inventory[i] is EmptyItem && emptySlot > i)
                    emptySlot = i;
                else if (i == Inventory.Length - 1)
                    succes = false;
            if (!succes)
            {
                Inventory[emptySlot] = item;
                InventoryItemsCount[emptySlot] = 1;
            }
        }

        public IItem UseItem(int i, int count)
        {
            var item = Inventory[i];
            if(!(item is Axe) || !(item is Pickaxe))
                InventoryItemsCount[i] -= count;
            if (InventoryItemsCount[i] <= 0)
            {
                Inventory[i] = new EmptyItem();
                InventoryItemsCount[i] = 0;
            }
            return item;
        }

        public Point GetPosition()
        {
            return new Point(X, Y);
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public string GetImageFileName()
        {
            throw new NotImplementedException();
        }

    }
}
