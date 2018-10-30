using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    /// <summary>
    /// Класс аптечек
    /// </summary>
    class Kit : BaseObject
    {
        /// <summary>
        /// Изображение аптечки
        /// </summary>
        public static Image Img { get; set; } = Properties.Resources.stormtrooper;
        public static int KitsCount { get; set; } = Settings.KitsCount[Game.DiffLvl];
        public Kit(Point pos, Point dir): base(pos, dir) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Img, Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
            Health = Game.Rand.Next(-Settings.AsteroidsMaxDamage, Settings.AsteroidsMinDamage*(-2));
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.Y <= Img.Height || Pos.Y >= (Settings.FieldHeight - Img.Height)) Dir.Y = -Dir.Y;
        }

    }
}