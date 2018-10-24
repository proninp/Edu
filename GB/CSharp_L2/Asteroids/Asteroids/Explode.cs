using System.Drawing;

namespace Asteroids
{
    class Explode : BaseObject
    {
        /// <summary>
        /// Изображение взрыва
        /// </summary>
        public static Image Img { get; set; } = Properties.Resources.explode_1;
        public int VisabilityTicksCount = 5;
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="pos">Позиция</param>
        public Explode(Point pos): base(pos, new Point(0, 0)) { }
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Img, Pos);
        public override void Update() => VisabilityTicksCount--;
    }
}
