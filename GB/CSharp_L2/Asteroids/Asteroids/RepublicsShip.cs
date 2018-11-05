using System.Drawing;

namespace Asteroids
{
    class RepublicsShip: BaseObject
    {
        /// <summary>
        /// Событие гибели корабля
        /// </summary>
        public static event Message MessageDie;
        /// <summary>
        /// Изображение корабля
        /// </summary>
        public static Image Img { get; set; }
        public HealthBar HPBar { get; set; }
        /// <summary>
        /// Корабль ведёт огонь
        /// </summary>
        private bool fire;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Урон, который может нанести корабль</param>
        public RepublicsShip(Point pos, Point dir, int health): base(pos, dir, health)
        {
            Img = Properties.Resources.x_wing;
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
            HPBar = new HealthBar(Settings.HPBarPos, Health, Settings.HPBarSize, Game.Buffer?.Graphics);
            fire = false;
        }
        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Img, Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width - (int)(Img.Size.Width*0.2), Img.Size.Height - (int)(Img.Size.Height * 0.2));
            HPBar.Draw();
        }
        /// <summary>
        /// Обновление состояния корабля
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (fire && (Game.DiffLvl == 0 || Health > 1)) // На первой сложности не отнимаем жизни при стрельбе
            {
                Game.Bullets?.Add(new Bullet(new Point(Game.Ship.Pos.X + Bullet.Img.Size.Width / 2,
                    Game.Ship.Pos.Y + Img.Size.Height / 4), new Point(15, 0), 10));
                GetDamage(Game.DiffLvl); // Такой вот хардкор
            }
        }
        /// <summary>
        /// Метод начала/конца огня. Записал в виде метода, чтобы использовать ?. для экземпляра корабля
        /// </summary>
        /// <param name="f"></param>
        public void Fire(bool f) => fire = f;
        /// <summary>
        /// Движение корабля вверх
        /// </summary>
        public void Up(bool move) => Dir.Y = (move && Pos.Y > 0) ? -Settings.SpaceShipStep : 0;
        /// <summary>
        /// Движение корабля вниз
        /// </summary>
        public void Down(bool move) => Dir.Y = (move && Pos.Y < (Settings.FieldHeight - Img.Size.Height)) ? Settings.SpaceShipStep : 0;
        /// <summary>
        /// Движение корабля влево
        /// </summary>
        public void Left(bool move) => Dir.X = (move && Pos.X > 0) ? -Settings.SpaceShipStep : 0;
        /// <summary>
        /// Движение корабля вправо
        /// </summary>
        public void Right(bool move) => Dir.X = (move && Pos.X < (Settings.FieldMaxWidth - Img.Size.Width)) ? Settings.SpaceShipStep : 0;
        /// <summary>
        /// Метод получения кораблём урона
        /// </summary>
        /// <param name="damage"></param>
        public void GetDamage(int damage)
        {
            Health -= damage;
            HPBar.Health = Health > Settings.SpaceShipMaxHealth ? Settings.SpaceShipMaxHealth : Health;
        }
        public void Die()
        {
            if (Health <= 0) MessageDie.Invoke();
        }
    }
}
