using System;
using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Класс для отображения счета игрока
    /// </summary>
    class Stat : BaseObject
    {
        Graphics Graphics { get; set; }
        public String Text { get; set; }
        public int Points { get; set; }

        public  Stat() : base(Settings.StatPos, new Point(0, 0))
        {
            Graphics = Game.Buffer?.Graphics;
        Points = 0;
            Text = $"Score: {Points}";
        }

        /// <summary>
        /// Метод отрисовки счета
        /// </summary>
        public override void Draw()
        {
            Text = $"Score: {Points}";
            Graphics?.DrawString(Text, new Font(Settings.MainFont, 10, FontStyle.Bold), Brushes.White, Pos);
        }
    }
}
