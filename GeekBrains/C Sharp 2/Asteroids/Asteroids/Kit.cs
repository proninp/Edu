using System.Drawing;

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
        public static Image Img { get; set; } = Properties.Resources.R2_D2;
        public Kit(Point pos, Point dir): base(pos, dir) { }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Img, Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
            Health = Game.Rand.Next(-Settings.EmpireShipMaxDamage[Game.DiffLvl], -Settings.EmpireShipMinDamage[Game.DiffLvl]);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.Y <= Img.Height || Pos.Y >= (Settings.FieldHeight - Img.Height)) Dir.Y = -Dir.Y;
        }

    }
}