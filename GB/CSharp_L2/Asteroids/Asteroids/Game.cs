using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace Asteroids
{
    /*
     * Сделал разные списки с объектами для ускорения проверок на коллизии и необходимость удаления экземпляра
     */
    static class Game
    {
        static BufferedGraphicsContext context;
        static Form MainForm { get; set; }
        public static BufferedGraphics Buffer { get; set; }
        public static SpaceShip SpaceShip { get; set; }
        public static HealthBar HPBar { get; set; }
        public static List<BaseObject> BaseObj { get; set; }
        public static List<Asteroid> Asteroids { get; set; } // Список астероидов
        public static List<Bullet> Bullets { get; set; } // Список снарядов
        public static List<Explode> Explodes { get; set; } // Список взрывов
        public static Random Rand { get; set; }
        public static Image SpaceImg { get; set; } = Properties.Resources.space;
        private static Timer Timer = new Timer { Interval = 80 };
        public static int Width { get; set; }
        public static int Height { get; set; }
        /// <summary>
        /// инициализация формы
        /// </summary>
        /// <param name="form">Объекты Winfows.Forms</param>
        public static void Init(Form form)
        {
            if (MainForm == null) MainForm = form;
            Graphics g = form.CreateGraphics();
            Rand = new Random();
            context = BufferedGraphicsManager.Current;
            if (Width > Settings.FieldMaxWidth || Height > Settings.FieldMaxHeight || Width < 0 || Height < 0)
                throw new GameObjectException(Settings.WindowSizeException);
            Width = form.Width;
            Height = form.Height;
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            InitialLoad();
            Timer.Start();
            Timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Отрисовка объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.DrawImage(SpaceImg, new Point(0, 0)); // Отрисовка фона
            foreach (var e in BaseObj) e.Draw();
            for (int i = 0; i < Asteroids.Count; i++)
            {
                for (int j = Bullets.Count - 1; j >= 0; j--)
                    if (Asteroids[i].Collision(Bullets[j]))
                    {
                        Bullets[j].Pos.X = Settings.FieldMaxWidth; // Чтобы сразу скрыть
                        Bullets[j] = null;
                        Bullets.RemoveAt(j);
                        Explodes.Add(new Explode(Asteroids[i].Pos)); // Создание взрыва
                        Asteroids[i].Hide();
                        break;
                    }
                if ((SpaceShip != null) && Asteroids[i].Collision(SpaceShip))
                {
                    Explodes.Add(new Explode(Asteroids[i].Pos));
                    Asteroids[i].Hide();
                    SpaceShip.GetDamage(Asteroids[i].Health);
                }
                Asteroids[i].Draw();
            }
            foreach (var e in Bullets) e.Draw();
            foreach (var e in Explodes) e.Draw();
            if (SpaceShip != null)
            {
                SpaceShip.Draw();
                HPBar.Draw();
            }
            Buffer.Render();
        }
        /// <summary>
        /// Первоначальная загрузка объектов до нажатия кнопки "Начать игру"
        /// Инициализация объектов Star
        /// </summary>
        public static void InitialLoad()
        {
            InitLists();
            int r = Rand.Next(Settings.MinElementSize, Settings.MaxElementSize);
            for (int i = 0; i < Settings.StarsCount; i++)
                BaseObj.Add(new Star(new Point(Rand.Next(0, Settings.FieldWidth), Rand.Next(10, Settings.FieldHeight)),
                    new Point(-i % 20 - 1, 0), new Size(r / 4, r / 4)));
        }
        /// <summary>
        /// Загрузка объектов после нажатия кнопки "Начать игру"
        /// Добавляет объект SpaceShip, Asteroid и Kit
        /// </summary>
        public static void BasicLoad()
        {
            for (int i = 0; i < Settings.AsteroidsCount; i++)
                Asteroids.Add(new Asteroid(new Point(Rand.Next(Settings.SpaceShipStartPos.X + 300, Settings.FieldWidth),
                    Rand.Next(0, Settings.FieldHeight)), new Point(-Rand.Next(5, 10), -i / 2 - 1), Rand.Next(Settings.AsteroidsMinDamage, Settings.AsteroidsMaxDamage)));
            SpaceShip = new SpaceShip(Settings.SpaceShipStartPos, new Point(0, 2), Settings.SpaceShipMaxHealth);
            HPBar = new HealthBar(Settings.HPBarPos, SpaceShip.Health, Settings.HPBarSize, Buffer.Graphics);
            SpaceShip.MessageDie += Finish;
        }
        /// <summary>
        /// Обновление каждого объекта
        /// </summary>
        public static void Update()
        {
            foreach (var o in BaseObj) o.Update();
            foreach (var o in Asteroids) o.Update();
            foreach (var o in Bullets) o.Update();
            // Проверка на необходимость удаления взрыва
            for (int i = 0; i < Explodes.Count; i++)
            {
                Explodes[i].Update();
                if (Explodes[i].VisabilityTicksCount > 0 && Explodes[i].VisabilityTicksCount < 4) { if (SpaceShip.Health <= 0) SpaceShip.Die(); }
                else if (Explodes[i].VisabilityTicksCount <= 0)
                {
                    Explodes[i].Pos.X = Settings.FieldMaxWidth;
                    Explodes[i] = null;
                    Explodes.RemoveAt(i--);
                }
            }
        }
        /// <summary>
        /// Тик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Инициалиация списков объектов
        /// </summary>
        private static void InitLists()
        {
            BaseObj = new List<BaseObject>();
            Asteroids = new List<Asteroid>(Settings.AsteroidsCount);
            Bullets = new List<Bullet>();
            Explodes = new List<Explode>(Settings.AsteroidsCount);
        }
        /// <summary>
        /// Конец игры
        /// </summary>
        public static void Finish()
        {
            Timer.Stop();
            if (MessageBox.Show(Settings.LooseMessage, Settings.LooseMessageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
            else Restart();
        }
        /// <summary>
        /// Перезагрузка основных объектов для рестарта игры
        /// </summary>
        private static void Restart()
        {
            InitLists();
            SpaceShip = null;
            HPBar = null;
            SpaceShip.MessageDie -= Finish; // Убираем, чтобы списке вызовов не было дублирования
            Timer.Tick -= Timer_Tick; // Так же, убираем
            Init(MainForm);
            foreach (var e in SplashScreen.BtnList) e.Visible = true;
        }
    }
}
