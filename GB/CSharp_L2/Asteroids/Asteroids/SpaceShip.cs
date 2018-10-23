using System.Drawing;

namespace Asteroids
{
    class SpaceShip: BaseObject
    {
        /// <summary>
        /// Изображение корабля
        /// </summary>
        public static Image Img { get; set; } = Properties.Resources.The_Death_Star;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Урон, который может нанести корабль</param>
        public SpaceShip(Point pos, Point dir, int power): base(pos, dir, power) { }
        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Img, Pos);
        /// <summary>
        /// Обновление позиции объекта
        /// </summary>
        public override void Update()
        {
            Pos.Y += Dir.Y;
            if (Pos.Y > Settings.ShipMaxYPos || Pos.Y < Settings.ShipMinYPos) Dir.Y = -Dir.Y;
        }   
    }
}
