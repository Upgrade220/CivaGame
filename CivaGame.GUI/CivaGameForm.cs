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
    public class Bitmaps
    {
        private Bitmaps()
        {

        }

        public Bitmap GetImage(string name) => bitmaps[name];

        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();

        private static Lazy<Bitmaps> instance = new Lazy<Bitmaps>(() => new Bitmaps());
        public static Bitmaps Instance => instance.Value;
    }

    public partial class CivaGameForm : Form
    {
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        private readonly Game game;
        private InventoryControl inventoryControl;

        public CivaGameForm(DirectoryInfo imagesDirectory = null)
        {
            game = new Game();
            game.StartAction();
            ClientSize = new Size(Game.ElementSize * (game.MapSizeX + 1), Game.ElementSize * (game.MapSizeY + 1));
            FormBorderStyle = FormBorderStyle.FixedDialog;
            if (imagesDirectory == null)
                imagesDirectory = new DirectoryInfo("Pictures");
            foreach (var image in imagesDirectory.GetFiles("*.png"))
                bitmaps[image.Name] = (Bitmap)Image.FromFile(image.FullName);

            inventoryControl = new InventoryControl(game, bitmaps);
            inventoryControl.InventorySlotSeted = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "CivaGame";
            DoubleBuffered = true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            //var dict = new Dictionary<Keys, Action>();
            //dict.Add(Keys.Down, () => game.Move(Direction.Up));
            //dict.Add(Keys.Down, () => game.Move(Direction.Up));
            //dict.Add(Keys.Down, () => game.Move(Direction.Up));
            //dict.Add(Keys.Down, () => game.Move(Direction.Up));

            base.OnKeyDown(e);
            switch (e.KeyData)
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
                    game.InteractPlayerWithMap(inventoryControl.InventorySlotSeted);
                    break;
                case Keys.Space:
                    game.PlayerBuildChurch();
                    break;
                case Keys.NumPad0:
                    game.PlayerEat(inventoryControl.InventorySlotSeted);
                    break;
                case Keys.NumPad1:
                    game.PlayerBuy(new Axe());
                    break;
                case Keys.NumPad2:
                    game.PlayerBuy(new Pickaxe());
                    break;
                case Keys.D1:
                    inventoryControl.InventorySlotSeted = 0;
                    break;
                case Keys.D2:
                    inventoryControl.InventorySlotSeted = 1;
                    break;
                case Keys.D3:
                    inventoryControl.InventorySlotSeted = 2;
                    break;
                case Keys.D4:
                    inventoryControl.InventorySlotSeted = 3;
                    break;
                case Keys.D5:
                    inventoryControl.InventorySlotSeted = 4;
                    break;
                case Keys.D6:
                    inventoryControl.InventorySlotSeted = 5;
                    break;
                case Keys.D7:
                    inventoryControl.InventorySlotSeted = 6;
                    break;
                case Keys.D8:
                    inventoryControl.InventorySlotSeted = 7;
                    break;
                default:
                    break;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(game.CurrentState == GameState.Action)
            DrawMap(e);

            e.Graphics.DrawImage(bitmaps[game.Trader.GetImageFileName()],
                new Point(game.Trader.X * Game.ElementSize, (game.MapSizeY - game.Trader.Y - 1) * Game.ElementSize));

            e.Graphics.DrawImage(bitmaps[game.Player.GetImageFileName()],
                new Point(game.Player.X * Game.ElementSize, (game.MapSizeY - game.Player.Y - 1) * Game.ElementSize));

            var hpRectangle = new Rectangle(new Point(game.MapSizeX * Game.ElementSize), new Size(Game.ElementSize / 2, Game.ElementSize * (game.MapSizeY + 1)));
            var hpRectangleFill = new Rectangle(new Point((int)((game.MapSizeX + 0.5) * Game.ElementSize)), new Size(Game.ElementSize / 2, (int)(Game.ElementSize * (game.MapSizeY + 1) * ((double)game.Player.HP / 100))));
            e.Graphics.DrawRectangle(new Pen(Brushes.Red), hpRectangle);
            e.Graphics.FillRectangle(Brushes.Red, hpRectangleFill);

            var foodRectangle = new Rectangle(new Point((int)((game.MapSizeX + 0.5) * Game.ElementSize)), new Size(Game.ElementSize / 2, Game.ElementSize * (game.MapSizeY + 1)));
            var foodRectangleFill = new Rectangle(new Point(game.MapSizeX * Game.ElementSize), new Size(Game.ElementSize / 2, (int)(Game.ElementSize * (game.MapSizeY + 1) * ((double)game.Player.Food / 100))));
            e.Graphics.DrawRectangle(new Pen(Brushes.Brown), foodRectangle);
            e.Graphics.FillRectangle(Brushes.Brown, foodRectangleFill);

            inventoryControl.Draw(e.Graphics);
        }

        private void DrawMap(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(
                            Brushes.Black, 0, 0,
                            Game.ElementSize * game.MapSizeX,
                            Game.ElementSize * game.MapSizeY);

            for (var i = 0; i < game.MapSizeX; i++)
                for (var j = 0; j < game.MapSizeY; j++)
                    e.Graphics.DrawImage(bitmaps[game.Map.WorldMap[i, j].GetImageFileName()],
                        new Point(i * Game.ElementSize, (game.MapSizeY - j - 1) * Game.ElementSize));
        }
    }

    public class InventoryControl : IControl
    {
        private readonly Game game;
        private readonly Dictionary<string, Bitmap> bitmaps;
        public int InventorySlotSeted { get; set; }

        public int Priority => 0;

        public InventoryControl(Game game, Dictionary<string, Bitmap> bitmaps)
        {
            this.game = game;
            this.bitmaps = bitmaps;
        }

        public void Draw(Graphics graphics)
        {
            graphics.TranslateTransform(0, game.MapSizeY * Game.ElementSize);
            for (var i = 0; i < game.Player.Inventory.Length; i++)
            {
                graphics.DrawImage(bitmaps[game.Player.Inventory[i].GetImageFileName()], new Point(i * Game.ElementSize, 0));
                graphics.DrawString((i + 1).ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, i * Game.ElementSize, -5);
                graphics.DrawString(game.Player.InventoryItemsCount[i].ToString(), new Font("Arial", 8, FontStyle.Bold), Brushes.Black, i * Game.ElementSize, Game.ElementSize - 15);
            }

            var signBitmap = bitmaps["Sign.png"];
            graphics.DrawImage(signBitmap, Game.ElementSize * (game.MapSizeX - 1), 0, signBitmap.Width, signBitmap.Height);

            graphics.DrawString("Money:", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, Game.ElementSize * (game.MapSizeX - 1), 10);
            graphics.DrawString(game.Money.ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Black, Game.ElementSize * (game.MapSizeX - 1), 50);
            var inventorySlotPoint = InventorySlotSeted * Game.ElementSize;
            var InventorySlotRectangle = new Rectangle(new Point(inventorySlotPoint), new Size(Game.ElementSize, Game.ElementSize));
            graphics.DrawRectangle(new Pen(Brushes.Red, 2), InventorySlotRectangle);
        }
    }

    public interface IControl
    {
        void Draw(Graphics graphics);
        int Priority { get; }
    }
}
