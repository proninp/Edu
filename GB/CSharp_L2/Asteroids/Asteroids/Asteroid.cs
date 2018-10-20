using System.Drawing;

namespace Asteroids
{
    class Asteroid: BaseObject
    {
        /// <summary>
        /// Массив возможных изображений астероидов
        /// </summary>
        public static Image[] Images { get; set; } = new Image[3]
        {
            Properties.Resources.ast_0,
            Properties.Resources.ast_1,
            Properties.Resources.ast_2
        };
        /// <summary>
        /// Конструктор объекта Астероид
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Урок астероида</param>
        public Asteroid(Point pos, Point dir, int power) : base(pos, dir, power) { }
        /// <summary>
        /// Стандартный метод отрисовки астероида
        /// </summary>
        public override void Draw() => Game.Buffer.Graphics.DrawImage(Images[0], Pos);
        /// <summary>
        /// Метод отрисовки для Астероида
        /// </summary>
        /// <param name="i">Индекс изображения из массива возможных изображений астероида</param>
        public void Draw(int i)
        {
            i %= Images.Length; // Чтобы не получить IndexOutOBoundException
            Game.Buffer.Graphics.DrawImage(Images[i], Pos);
        }
    }
}
