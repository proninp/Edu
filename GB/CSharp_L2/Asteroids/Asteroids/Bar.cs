using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Bar : BaseObject
    {
        /// <summary>
        /// Размер полоски
        /// </summary>
        int BarWidth { get; set; }
        /// <summary>
        /// Графическое отображение
        /// </summary>
        Graphics Shape { get; set; }
        /// <summary>
        /// "Подложка" с черным фоном для полосы жизни
        /// </summary>
        Rectangle SubRect { get; set; }
        /// <summary>
        /// Внутренний цвет бара
        /// </summary>
        Color InnerColor { get; set; }
        /// <summary>
        /// Максимальное кол-во для поинтов бара
        /// </summary>
        int BarMaxPoints { get; set; }
        /// <summary>
        /// Динамическая смена цвета, в зависимости от значения поинтов бара
        /// </summary>
        bool DynamicColorChange { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        public Bar(Point pos, int hp, Size size, Graphics fromGraphics, Color innerColor, int maxPoints, bool changeColor) : base(pos, new Point(0, 0), hp, size)
        {
            Shape = fromGraphics;
            SubRect = new Rectangle(Pos.X - 2, Pos.Y - 2, size.Width + 4, size.Height + 4);
            InnerColor = innerColor;
            BarMaxPoints = maxPoints;
            DynamicColorChange = changeColor;
            Shape.DrawString($"{Health}/{BarMaxPoints}", new Font(Settings.MainFont, 8, FontStyle.Bold), Brushes.White, Pos.X, Pos.Y + Size.Height);
        }
        /// <summary>
        /// Метод орисовки хелс бара, меняет цвет в зависимости от количества оставшихся хелс поинтов
        /// </summary>
        public override void Draw()
        {
            BarWidth = Size.Width / BarMaxPoints * Health;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Shape.FillRectangle(solidBrush, SubRect);
            solidBrush.Color = DynamicColorChange ? ((double)BarWidth / Size.Width > 0.6 ? InnerColor : (double)BarWidth / Size.Width > 0.3 ? Color.Yellow : Color.Red) : InnerColor;
            Rect = new Rectangle(Pos, new Size(BarWidth, Size.Height));
            Shape.FillRectangle(solidBrush, Rect);
            solidBrush.Dispose();
            Shape.DrawString($"{Health}/{BarMaxPoints}", new Font(Settings.MainFont, 8, FontStyle.Bold), Brushes.White, Pos.X, Pos.Y + Size.Height);
        }

    }
}
