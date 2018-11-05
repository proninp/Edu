using System.Drawing;

namespace Asteroids
{
    class Empires: BaseObject
    {
        /// <summary>
        /// Массив возможных изображений астероидов
        /// </summary>
        public static Image[] Images { get; set; } = new Image[4]
        {
            Properties.Resources.Advanced_x1_1,
            Properties.Resources.Advanced_x1_2,
            Properties.Resources.TIE_Interceptor_1,
            Properties.Resources.TIE_Interceptor_2
        };
        int ImgIndex { get; set; } = rand.Next(0, Images.Length);
        /// <summary>
        /// Конструктор объекта Астероид
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Урок астероида</param>
        public Empires(Point pos, Point dir, int power) : base(pos, dir, power) { }
        /// <summary>
        /// Метод отрисовки астероида, в который попал снаряд
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Images[ImgIndex], Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Images[ImgIndex].Size.Width, Images[ImgIndex].Size.Height);
            Health = Game.Rand.Next(Settings.AsteroidsMinDamage[Game.DiffLvl], Settings.AsteroidsMaxDamage[Game.DiffLvl]);
        }
        /// <summary>
        /// Смена позиции астероида за пределы экрана
        /// </summary>
        public void Hide() => Pos = new Point(Settings.FieldWidth + Size.Width, rand.Next(0, Settings.FieldHeight - Size.Height));
    }
}
