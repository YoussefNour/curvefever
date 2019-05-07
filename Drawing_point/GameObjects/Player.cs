using System;
using System.Drawing;

namespace Drawing_point
{
    class Player
    {
        private double x, y;
        private double Speed = 1;
        private Color C;
        private double Angle = 0;
        private int Size = 8;
        private bool IsAlive = true;

        public Player(int x, int y, double Angle, Color C)
        {
            this.x = x;
            this.y = y;
            this.Angle = Angle;
            this.C = C;
        }

        public void Move()
        {
            if (IsAlive)
            {
                if (this.Angle >= 360)
                {
                    this.Angle = Angle % 360;
                }
                else if (this.Angle <= -360)
                {
                    this.Angle = Angle % 360;
                }
                if (x >= (500 - this.Size)) { IsAlive = false; }
                if (x <= 0) { IsAlive = false; }

                if (y >= 500 - this.Size) { IsAlive = false; }
                if (y <= 0) { IsAlive = false; }

                this.x += (Math.Sin((Angle * Math.PI) / 180) * Speed);
                this.y += (Math.Cos((Angle * Math.PI) / 180) * Speed);

            }

        }
        public void Draw(Graphics G, Bitmap B)
        {
            G = Graphics.FromImage(B);
            G.FillEllipse(new SolidBrush(this.C), (float)this.x, (float)this.y, Size, Size);
        }
        public void RotateACC()
        {
            this.Angle += 2.5;
        }
        public void RotateCC()
        {
            this.Angle -= 2.5;
        }
        public void Collide(Bitmap B)
        {
            int P_x = 0, P_y = 0;
            P_x += (int)Math.Round(this.x + (this.Size / 2) + ( (Math.Sin((Angle * Math.PI) / 180) * Speed)) + ( (Math.Sin((Angle * Math.PI) / 180) * (Size / 2))));
            P_y += (int)Math.Round(this.y + (this.Size / 2) + ( (Math.Cos((Angle * Math.PI) / 180) * Speed)) + ( (Math.Cos((Angle * Math.PI) / 180) * (Size / 2))));
            if (P_x <= 0 || P_x >= 500|| P_y <= 0 || P_y >= 500)
            {
                IsAlive = false;
                return;
            }
            Color c = B.GetPixel(P_x, P_y);
            if (c.B != 0 || c.G != 0 || c.R != 0)
            {
                IsAlive = false;
            }
        }
        public void setSize(int x)
        {
            this.Size = x;
        }
        public void setSpeed(int s) { this.Speed = s; this.Speed = s; }

    }
}
