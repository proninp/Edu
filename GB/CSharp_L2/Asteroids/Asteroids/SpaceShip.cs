using System.Drawing;

namespace Asteroids
{
    class SpaceShip: BaseObject
    {
        /// <summary>
        /// Событие гибели корабля
        /// </summary>
        public static event Message MessageDie;
        /// <summary>
        /// Изображение корабля
        /// </summary>
        public static Image Img { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Урон, который может нанести корабль</param>
        public SpaceShip(Point pos, Point dir, int health): base(pos, dir, health)
        {
            Img = Properties.Resources.The_Death_Star;
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
        }
        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Img, Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width - (int)(Img.Size.Width*0.2), Img.Size.Height - (int)(Img.Size.Height * 0.2));
        }
        /// <summary>
        /// Движение корабля вверх
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y -= Settings.SpaceShipStep;
        }
        /// <summary>
        /// Движение корабля вниз
        /// </summary>
        public void Down()
        {
            if (Pos.Y < (Settings.FieldHeight - Img.Size.Height)) Pos.Y += Settings.SpaceShipStep;
        }
        /// <summary>
        /// Движение корабля влево
        /// </summary>
        public void Left()
        {
            if (Pos.X > 0) Pos.X -= Settings.SpaceShipStep;
        }
        /// <summary>
        /// Движение корабля вправо
        /// </summary>
        public void Right()
        {
            if (Pos.X < (Settings.FieldMaxWidth - Img.Size.Width)) Pos.X += Settings.SpaceShipStep;
        }
        /// <summary>
        /// Метод получения кораблём урона
        /// </summary>
        /// <param name="damage"></param>
        public void GetDamage(int damage)
        {
            Health -= damage;
            if (Health > Settings.SpaceShipMaxHealth) Health = Settings.SpaceShipMaxHealth;
            if (Health <= Settings.SpaceShipMaxHealth / 3) Img = Properties.Resources.The_Death_Star_Damaged; // Если меньше 30% hp, меняем изображение
            else if (Img.Equals(Properties.Resources.The_Death_Star_Damaged)) Img = Properties.Resources.The_Death_Star; // Меняем обратно
            if (Game.HPBar != null) Game.HPBar.Health = Health;
        }
        public void Die()
        {
            if (Health <= 0) MessageDie.Invoke();
        }
    }
}
