using System.Drawing;

namespace Asteroids
{
    class Bullet: BaseObject
    {
        /// <summary>
        /// Изображение луча
        /// </summary>
        public static Image Img { get; set; } = Properties.Resources.ray;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Урон, который может нанести корабль</param>
        public Bullet(Point pos, Point dir, int power) : base(pos, dir, power)
        {
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
        }
        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Img, Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
        }
        /// <summary>
        /// Обновление позиции объекта
        /// </summary>
        public override void Update() => Pos.X += Dir.X;
    }
}
