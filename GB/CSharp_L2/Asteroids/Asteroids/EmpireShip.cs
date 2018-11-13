using System.Collections.Generic;
using System.Drawing;

namespace Asteroids
{
    class EmpireShip: BaseObject
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
        public EmpireShip(Point pos, Point dir, int power) : base(pos, dir, power) { }
        /// <summary>
        /// Метод отрисовки астероида, в который попал снаряд
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Images[ImgIndex], Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Images[ImgIndex].Size.Width, Images[ImgIndex].Size.Height);
            Health = Game.Rand.Next(Settings.EmpireShipMinDamage[Game.DiffLvl], Settings.EmpireShipMaxDamage[Game.DiffLvl]);
            if (rand.Next(0, 50) == rand.Next(0, 50))
                Game.EnemiesBullets?.Add(new Bullet(
                    new Point(Pos.X - Bullet.Img.Size.Width / 2, Pos.Y + Images[ImgIndex].Size.Height / 4), // Позиция
                    new Point(-15, 0), // Направление движения
                    rand.Next(Settings.EmpireShipMinDamage[Game.DiffLvl], Settings.EmpireShipMaxDamage[Game.DiffLvl]), // Мощность выстрела
                    Settings.EmpireShipBulletIndex)); // Индекс используемого изображения
        }
        /// <summary>
        /// Смена позиции астероида за пределы экрана
        /// </summary>
        public void Hide() => Pos = new Point(Settings.FieldWidth + Size.Width, rand.Next(0, Settings.FieldHeight - Size.Height));
        /// <summary>
        /// Уничтожение корабля противника
        /// </summary>
        /// <param name="list">Список кораблей противников</param>
        /// <param name="i">индекс текущего корабля в списке</param>
        public void Die(List<EmpireShip> list, int i)
        {
            if (Game.Stat != null) Game.Stat.Points += Health; // Вызов отрисовки статистики
            Del(list, i);
        }
    }
}
