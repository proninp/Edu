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
        // TODO доделать аптечки

        /// <summary>
        /// Изображение аптечки
        /// </summary>
        public static Image Img { get; set; }
        public Kit(Point pos, Point dir): base(pos, dir) { }
        public override void Draw()
        {
            Pos = new Point(Settings.FieldWidth + Size.Width, rand.Next(0, Settings.FieldHeight - Size.Height));
            Game.Buffer.Graphics.DrawImage(Img, Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
            Health = Game.Rand.Next(Settings.AsteroidsMinDamage*(-2), Settings.AsteroidsMaxDamage*(-2));
        }
    }
}
