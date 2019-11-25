using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CivaGame.GUI
{
    public partial class CivaGameForm : Form
    {
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        private readonly Game game;
        private int inventorySlotSeted;

        public CivaGameForm(DirectoryInfo imagesDirectory = null)
        {
            game = new Game();
            game.StartAction();
            ClientSize = new Size(Game.ElementSize * game.MapSizeX, Game.ElementSize * (game.MapSizeY + 1));
            FormBorderStyle = FormBorderStyle.FixedDialog;
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Pictures");
            foreach (var image in imagesDirectory.GetFiles("*.png"))
                bitmaps[image.Name] = (Bitmap)Image.FromFile(image.FullName);
            inventorySlotSeted = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "CivaGame";
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch(e.KeyData)
            {
                case Keys.Up:
                    game.Move(Direction.Up);
                    break;
                case Keys.Down:
                    game.Move(Direction.Down);
                    break;
                case Keys.Left:
                    game.Move(Direction.Left);
                    break;
                case Keys.Right:
                    game.Move(Direction.Right);
                    break;
                case Keys.Enter:
                    game.InteractPlayerWithMap(inventorySlotSeted);
                    break;
                case Keys.RShiftKey:
                    game.PlayerBuildChurch();
                    break;
                case Keys.RControlKey:
                    game.PlayerEat(inventorySlotSeted);
                    break;
                case Keys.D1:
                    inventorySlotSeted = 0;
                    break;
                case Keys.D2:
                    inventorySlotSeted = 1;
                    break;
                case Keys.D3:
                    inventorySlotSeted = 2;
                    break;
                case Keys.D4:
                    inventorySlotSeted = 3;
                    break;
                case Keys.D5:
                    inventorySlotSeted = 4;
                    break;
                case Keys.D6:
                    inventorySlotSeted = 5;
                    break;
                case Keys.D7:
                    inventorySlotSeted = 6;
                    break;
                case Keys.D8:
                    inventorySlotSeted = 7;
                    break;
                default:
                    break;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(
                Brushes.Black, 0, 0, Game.ElementSize * game.MapSizeX,
                Game.ElementSize * game.MapSizeY);
            for (var i = 0; i < game.MapSizeX; i++)
                for (var j = 0; j < game.MapSizeY; j++)
                    e.Graphics.DrawImage(bitmaps[game.Map.WorldMap[i, j].GetImageFileName()], new Point(i * Game.ElementSize, (game.MapSizeY - j - 1) * Game.ElementSize));
            e.Graphics.DrawImage(bitmaps[game.Trader.GetImageFileName()], new Point(game.Trader.X * Game.ElementSize, (game.MapSizeY - game.Trader.Y - 1) * Game.ElementSize));
            e.Graphics.DrawImage(bitmaps[game.Player.GetImageFileName()], new Point(game.Player.X * Game.ElementSize, (game.MapSizeY - game.Player.Y - 1)* Game.ElementSize));
            e.Graphics.TranslateTransform(0, game.MapSizeY * Game.ElementSize);
            for (var i = 0; i < game.Player.Inventory.Length; i++)
            {
                e.Graphics.DrawImage(bitmaps[game.Player.Inventory[i].GetImageFileName()], new Point(i * Game.ElementSize, 0));
                e.Graphics.DrawString((i + 1).ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, i * Game.ElementSize, - 5);
                e.Graphics.DrawString(game.Player.InventoryItemsCount[i].ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, i * Game.ElementSize, Game.ElementSize - 15);
            }
            e.Graphics.DrawImage(bitmaps["Sign.png"], new Point(Game.ElementSize * (game.MapSizeX - 1), 0));
            e.Graphics.DrawString("Money:", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, Game.ElementSize * (game.MapSizeX - 1), 10);
            e.Graphics.DrawString(game.Money.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, Game.ElementSize * (game.MapSizeX - 1), 50);
            var inventorySlotPoint = inventorySlotSeted * Game.ElementSize;
            var InventorySlotRectangle = new Rectangle(new Point(inventorySlotPoint), new Size(Game.ElementSize, Game.ElementSize));
            e.Graphics.DrawRectangle(new Pen(Brushes.Red, 2), InventorySlotRectangle);
        }
    }
}
