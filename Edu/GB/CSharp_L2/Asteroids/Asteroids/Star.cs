using System.Drawing;

namespace Asteroids
{
    class Star: BaseObject
    {
        /// <summary>
        /// Прямая линия одного из трёх представленных цветов, толщиной 1
        /// </summary>
        private readonly Pen p;
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="size">Размер</param>
        public Star(Point pos, Point dir, Size size):base(pos, dir, size) => p = new Pen(new Color[] {
            Color.White,
            Color.Wheat,
            Color.LightGray
        }[rand.Next(0, 3)], 1);
        /// <summary>
        /// Переопределение метода отрисовки
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(p, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(p, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(p, Pos.X + Size.Width/6, Pos.Y + Size.Height/2, Pos.X + Size.Width - Size.Width / 6, Pos.Y + Size.Height / 2);
            Game.Buffer.Graphics.DrawLine(p, Pos.X + Size.Width / 2, Pos.Y + Size.Height / 6, Pos.X + Size.Width/2, Pos.Y + Size.Height - Size.Height / 6);
        }
        /// <summary>
        /// Изменение позиции объекта
        /// </summary>
        public override void Update()
        {
            Pos.X -= Dir.X;
            if (Pos.X > Game.Width) Pos.X -= Game.Width;
            if (Pos.X < 0) Pos.X += Game.Width + Size.Width;
            if (Pos.Y > Game.Height) Pos.Y -= Game.Height;
            if (Pos.Y < 0) Pos.Y += Game.Height;
        }
    }
}
