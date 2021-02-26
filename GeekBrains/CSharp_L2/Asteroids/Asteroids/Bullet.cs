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
        /// Массив изображений лучей
        /// </summary>
        public static Image[] Images { get; set; } = new Image[2]
        {
            Properties.Resources.ray,
            Properties.Resources.redRay
        };
        /// <summary>
        /// Индекс изображения пули
        /// </summary>
        public int ImageIndex { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Мощность наносимого урона</param>
        public Bullet(Point pos, Point dir, int power) : base(pos, dir, power)
        {
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
            ImageIndex = 0;
        }
        /// <summary>
        /// Конструктор с указанием индекса изображения
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Мощность наносимого урона</param>
        /// <param name="imgInd">Индекс изображения объекта</param>
        public Bullet(Point pos, Point dir, int power, int imgInd) : base(pos, dir, power)
        {
            ImageIndex = imgInd;
        }
        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Images[ImageIndex], Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
        }
        /// <summary>
        /// Обновление позиции объекта
        /// </summary>
        public override void Update() => Pos.X += Dir.X;
    }
}
