using System.Drawing;

namespace Asteroids
{
    class HealthBar : BaseObject
    {
        int HealthPointsBarWidth { get; set; }
        Graphics Shape { get; set; }
        /// <summary>
        /// "Подложка" с черным фоном для полосы жизни
        /// </summary>
        Rectangle SubRect { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        public HealthBar(Point pos, int hp, Size size, Graphics fromGraphics) : base(pos, new Point(0, 0), hp, size)
        {
            Shape = fromGraphics;
            SubRect = new Rectangle(Pos.X - 2, Pos.Y - 2, size.Width + 4, size.Height + 4);
        }
        /// <summary>
        /// Метод орисовки хелс бара, меняет цвет в зависимости от количества оставшихся хелс поинтов
        /// </summary>
        public override void Draw()
        {
            HealthPointsBarWidth = Size.Width / Settings.SpaceShipMaxHealth * Health;
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            Shape.FillRectangle(solidBrush, SubRect);
            solidBrush.Color = (double)HealthPointsBarWidth / Size.Width > 0.6 ? Color.Green : (double)HealthPointsBarWidth / Size.Width > 0.3 ? Color.Yellow : Color.Red;
            Rect = new Rectangle(Pos, new Size(HealthPointsBarWidth, Size.Height));
            Shape.FillRectangle(solidBrush, Rect);
            solidBrush.Dispose();
        }

    }
}
