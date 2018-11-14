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
        public String StatText { get; set; }
        public string Description { get; set; }
        public int StatValue { get; set; }

        public Stat(Point pos, string text, int value) : base(pos, new Point(0, 0))
        {
            Graphics = Game.Buffer?.Graphics;
            StatValue = value;
            Description = text;
            StatText = $"{Description} {StatValue}";
        }

        /// <summary>
        /// Метод отрисовки счета
        /// </summary>
        public override void Draw()
        {
            StatText = $"{Description} {StatValue}";
            Graphics?.DrawString(StatText, new Font(Settings.MainFont, 10, FontStyle.Bold), Brushes.White, Pos);
        }
    }
}
