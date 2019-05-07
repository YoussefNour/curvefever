using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Windows.Input;

namespace Drawing_point.GUI
{
    class GamePanel : Panel
    {
        Player[] Players = new Player[4];
        int WhichPlayer;
        Random rand;
        static Bitmap ActionMap = new Bitmap(500, 500);

        public GamePanel(int WhichPlayer)
        {
            rand = new Random();
            this.WhichPlayer = WhichPlayer;
            this.SetPlayers(rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360), rand.Next(50, 360));
            for (int i = 0; i < 500; i++)
            {
                for (int j = 0; j < 500; j++)
                {
                    ActionMap.SetPixel(i, j, Color.Black);
                }
            }

            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;

            this.SetBounds(0, 0, 500, 500);
            this.BackColor = Color.White;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 11;
            timer.Tick += Updategame;
            timer.Start();
        }
        public void SetPlayers(int x0, int x1, int x2, int x3, int y0, int y1, int y2, int y3, int a0, int a1, int a2, int a3)
        {
            Players[0] = new Player(x0, y0, a0, Color.Red);
            Players[1] = new Player(x1, y1, a1, Color.Green);
            Players[2] = new Player(x2, y2, a2, Color.Blue);
            Players[3] = new Player(x3, y3, a3, Color.Yellow);
        }
        private void Updategame(object sender, EventArgs e)
        {
            if (KeyMnager.getKey(Keys.Right))
                Players[this.WhichPlayer].RotateCC();
            if (KeyMnager.getKey(Keys.Left))
                Players[this.WhichPlayer].RotateACC();
            for (int i = 0; i < 4; i++)
            {
                Players[i].Collide(ActionMap);
                Players[i].Move();
            }

            this.Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(ActionMap, 0, 0);
            base.OnPaint(e);
            DrawGame(e.Graphics, ActionMap);
        }
        private void DrawGame(Graphics G, Bitmap B)
        {
            for (int i = 0; i < 4; i++)
            {
                Players[i].Draw(G, B);
            }
        }
    }
}
