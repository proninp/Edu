using System.Drawing;

namespace Asteroids
{
    class Ship: BaseObject
    {
        /// <summary>
        /// Изображение корабля
        /// </summary>
        public static Image Img { get; set; }
        /// <summary>
        /// Полоска жизни корабля
        /// </summary>
        public Bar HealthBar { get; set; }
        /// <summary>
        /// Полоска энергии корабля
        /// </summary>
        public Bar EnergyBar { get; set; }
        /// <summary>
        /// Корабль ведёт огонь
        /// </summary>
        private bool fire;
        /// <summary>
        /// Свойство для управления поведением при изменении кол-ва поинтов жизни
        /// </summary>
        public override int Health
        {
            get { return health; }
            set
            {
                health = (value > Settings.SpaceShipMaxHealth ? Settings.SpaceShipMaxHealth : value);
                if (HealthBar != null) HealthBar.Health = health;
            }
        }
        /// <summary>
        /// Доступная энергия корабля для выстрела
        /// </summary>
        private int energy;
        /// <summary>
        /// Свойство для установки энергии корабля
        /// </summary>
        public int Energy
        {
            get { return energy; }
            set { energy = (value < 0) ? 0 : (value > Settings.SpaceShipMaxEnergy ? Settings.SpaceShipMaxEnergy : value); EnergyBar.Health = energy; }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pos">Позиция</param>
        /// <param name="dir">Шаг изменения позиции</param>
        /// <param name="power">Урон, который может нанести корабль</param>
        public Ship(Point pos, Point dir, int health, int energy): base(pos, dir, health)
        {
            Img = Properties.Resources.x_wing;
            HealthBar = new Bar(Settings.HPBarPos, Health, Settings.HPBarSize, Game.Buffer?.Graphics, Color.Green, Health, true);
            EnergyBar = new Bar(Settings.EnergyBarPos, energy, Settings.EnergyBarSize, Game.Buffer?.Graphics, Color.Blue, energy, false);
            Energy = energy;
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width, Img.Size.Height);
            fire = false;
        }
        /// <summary>
        /// Метод отрисовки объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Img, Pos);
            Rect = new Rectangle(Pos.X, Pos.Y, Img.Size.Width - (int)(Img.Size.Width*0.2), Img.Size.Height - (int)(Img.Size.Height * 0.2));
            HealthBar.Draw();
            EnergyBar.Draw();
        }
        /// <summary>
        /// Обновление состояния корабля
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (fire)
            {
                if (Energy > 0)
                {
                    Energy -= Settings.EnergyCostShoot[Game.DiffLvl];
                    Game.ShipBullets?.Add(new Bullet(new Point(Game.Ship.Pos.X + Bullet.Img.Size.Width / 2, Game.Ship.Pos.Y + Img.Size.Height / 4), new Point(15, 0), 10));
                }
                //GetDamage(Game.DiffLvl); // Если уровень выше первого, наносить урон самому себе при выстреле (такой вот хардкор)
            }
            if (!fire && rand.Next(0, Settings.EnergyRecoveryChance[Game.DiffLvl]) == Game.DiffLvl) Energy++;
        }
        /// <summary>
        /// Метод начала/конца огня. Записал в виде метода, чтобы использовать ?. для экземпляра корабля
        /// </summary>
        /// <param name="f"></param>
        public void Fire(bool f) => fire = f;
        /// <summary>
        /// Движение корабля вверх
        /// </summary>
        public void Up(bool move) => Dir.Y = (move && Pos.Y > Img.Size.Height / 2) ? -Settings.SpaceShipStep : 0;
        /// <summary>
        /// Движение корабля вниз
        /// </summary>
        public void Down(bool move) => Dir.Y = (move && Pos.Y < (Settings.FieldHeight - Img.Size.Height * 2)) ? Settings.SpaceShipStep : 0;
        /// <summary>
        /// Движение корабля влево
        /// </summary>
        public void Left(bool move) => Dir.X = (move && Pos.X > Img.Size.Width / 2) ? -Settings.SpaceShipStep : 0;
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
            Energy -= (damage > 0) ? rand.Next(0, damage) : rand.Next(damage, 0);
        }
    }
}
