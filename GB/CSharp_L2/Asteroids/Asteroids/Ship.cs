using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Ship
    {
        protected static Image Img { get; set; } = Image.FromFile(Settings.ShipImgPath);
        protected Point Pos;
        protected Point Dir;
        protected float RotationAngle { get; set; }
        public Ship()
        {
            Pos.X = 50;
            Pos.Y = 300;
            Dir.Y = 2;
        }
        public Ship(Point pos, Point dir, float rotation)
        {
            Pos = pos;
            Dir = dir;
            RotationAngle = rotation;
        }
        public void Draw() => Game.Buffer.Graphics.DrawImage(Img, Pos);
        public void Rotate() { }
        public void Update()
        {
            Pos.Y += Dir.Y;
            if (Pos.Y > Settings.ShipMaxYPos || Pos.Y < Settings.ShipMinYPos) Dir.Y = -Dir.Y;
        }
        
    }
}
