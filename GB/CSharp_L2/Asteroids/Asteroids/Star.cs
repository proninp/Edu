using System;
using System.Drawing;

namespace Asteroids
{
    class Star: BaseObject
    {
        Pen p;
        public Star(Point pos, Point dir, Size size):base(pos, dir, size) => p = new Pen(new Color[] {Color.White, Color.Wheat, Color.LightGray }[rand.Next(0, 3)], 1);
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(p, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(p, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(p, Pos.X + Size.Width/6, Pos.Y + Size.Height/2, Pos.X + Size.Width - Size.Width / 6, Pos.Y + Size.Height / 2);
            Game.Buffer.Graphics.DrawLine(p, Pos.X + Size.Width / 2, Pos.Y + Size.Height / 6, Pos.X + Size.Width/2, Pos.Y + Size.Height - Size.Height / 6);
        }
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X > Game.Width) Pos.X = Size.Width;
            if (Pos.Y > Game.Height) Pos.Y -= Game.Height;
        }
    }
}
