using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Asteroids
{
    class BaseObject
    {
        protected static Random rand = new Random();
        protected static Color[] clr = new Color[] 
        {
                Color.CadetBlue,
                Color.OrangeRed,
                Color.DarkMagenta,
                Color.Magenta,
                Color.DeepSkyBlue,
                Color.IndianRed,
                Color.CornflowerBlue,
                Color.SkyBlue,
                Color.DodgerBlue,
                Color.LightCoral,
                Color.DarkBlue,
                Color.LightCyan,
                Color.DarkOrange
            };
        static BaseObject()
        {
            rand = new Random();
        }
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        Color surrClr;
        protected Color CntrClr { get; set; }
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            surrClr = clr[rand.Next(0, clr.Length)];
            CntrClr = clr.Where(c => !c.Equals(surrClr)).ToArray()[rand.Next(0, clr.Length - 1)];
        }
        //public virtual void Draw() => Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        public virtual void Draw()
        {
            Rectangle rect = new Rectangle(Pos, Size);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(rect);
            using (PathGradientBrush br = new PathGradientBrush(path))
            {
                br.CenterColor = CntrClr;
                br.SurroundColors = new Color[] { surrClr };
                Game.Buffer.Graphics.FillEllipse(br, rect);
            }
        }

        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y -= Dir.Y;
            //if (Pos.X < 0 || Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0 || Pos.Y > Game.Height) Dir.Y = -Dir.Y;
            if (Pos.X < 0) Pos.X = Game.Width;
            if (Pos.Y > Game.Height) Pos.Y = 0;
            if (Pos.X > Game.Width) Pos.X = 0;
            if (Pos.Y < 0) Pos.Y = Game.Height;
        }
    }
}
