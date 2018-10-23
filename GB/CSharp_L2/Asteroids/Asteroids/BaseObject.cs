using System;
using System.Drawing;

namespace Asteroids
{
    abstract class BaseObject: ICollision
    {
        protected static Random rand = new Random();
        /// <summary>
        /// Лимит выхода объекта за пределы экрана
        /// </summary>
        static readonly int beyoundLim = 50;
        /// <summary>
        /// Позиция
        /// </summary>
        public Point Pos;
        /// <summary>
        /// Шаг изменения позиции
        /// </summary>
        protected Point Dir;
        /// <summary>
        /// Размер
        /// </summary>
        protected Size Size;
        /// <summary>
        /// Урон
        /// </summary>
        protected int Power { get; set; }
        /// <summary>
        /// Размер прямоугольной области объекта
        /// </summary>
        public Rectangle Rect { get; set; }
        /// <summary>
        /// Нужно ли цничтожить объект
        /// </summary>
        public bool IsDestroy { get; set; }
        /// <summary>
        /// Стандартный конструктор
        /// </summary>
        /// <param name="pos">Позиция объекта</param>
        /// <param name="dir">Шаг изенения позиции</param>
        protected BaseObject(Point pos, Point dir)
        {
            Pos = pos;
            Dir = dir;
        }
        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="pos">Позиция объекта</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="size">Размер объекта</param>
        protected BaseObject(Point pos, Point dir, Size size): this(pos, dir) => Size = size;
        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="pos">Позиция объекта</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Урон, который может нанести объект</param>
        protected BaseObject(Point pos, Point dir, int power) : this(pos, dir) => Power = power;
        /// <summary>
        /// Метод для отрисовки
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Метод для обновления позиции объекта
        /// </summary>
        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y -= Dir.Y;
            if (Pos.X < -beyoundLim) Pos.X = Game.Width;
            if (Pos.Y > Game.Height + beyoundLim) Pos.Y = 0;
            if (Pos.X > (Game.Width + beyoundLim)) Pos.X = 0;
            if (Pos.Y < -beyoundLim) Pos.Y = Game.Height;
        }
        public bool Collision(ICollision obj) => ((BaseObject)obj).Rect.IntersectsWith(Rect);
    }
}
