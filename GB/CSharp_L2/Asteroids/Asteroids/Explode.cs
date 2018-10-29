using System;
using System.Drawing;

namespace Asteroids
{
    class Explode : BaseObject
    {
        static Random Rand { get; set; } = new Random();
        /// <summary>
        /// Массив изображений взрывов
        /// </summary>
        public static Image[] Images { get; set; } = new Image[4]
        {
            Properties.Resources.explode_1,
            Properties.Resources.explode_2,
            Properties.Resources.explode_3,
            Properties.Resources.explode_4
        };
        int ImgIndex { get; set; } = Rand.Next(0, Images.Length);
        /// <summary>
        /// Количество Тиков для показа взрыва
        /// </summary>
        public int VisabilityTicksCount = 5;
        /// <summary>
        /// Конструктор объекта
        /// </summary>
        /// <param name="pos">Позиция</param>
        public Explode(Point pos) : base(pos, new Point(0, 0)) { }
        /// <summary>
        /// Стандартная отрисовка взрыва
        /// </summary>
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Images[ImgIndex], Pos);
        /// <summary>
        /// Обновление количества Тиков видимости
        /// </summary>
        public override void Update() => VisabilityTicksCount--;
    }
}
