using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace Asteroids
{
    static class Game
    {
        static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer { get; set; }
        public static SpaceShip SpaceShip { get; set; }
        public static List<BaseObject> BaseObj { get; set; }
        public static List<Asteroid> Asteroids { get; set; }
        public static List<Bullet> Bullets { get; set; }
        public static Random Rand { get; set; }
        public static Image SpaceImg { get; set; } = Properties.Resources.space;
        public static int Width { get; set; }
        public static int Height { get; set; }
        /// <summary>
        /// инициализация формы
        /// </summary>
        /// <param name="form">Объекты Winfows.Forms</param>
        public static void Init(Form form)
        {
            Graphics g = form.CreateGraphics();
            Rand = new Random();
            context = BufferedGraphicsManager.Current;
            if (Width > Settings.FieldMaxWidth || Height > Settings.FieldMaxHeight || Width < 0 || Height < 0)
                throw new GameObjectException(Settings.WindowSizeException);
            Width = form.Width;
            Height = form.Height;
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
            InitLists();
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Отрисовка объектов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.DrawImage(SpaceImg, new Point(0, 0)); // Отрисовка фона
            for (int i = 0; i < BaseObj.Count; i++)
                if (BaseObj[i] is Asteroid) (BaseObj[i] as Asteroid).Draw(i / Asteroid.Images.Length);
                else BaseObj[i].Draw();
            for (int i = 0; i < BaseObj.Count; i++)
            {
                if (BaseObj[i] is Asteroid)
                    for (int j = 0; j < BaseObj.Count; j++)
                        if (BaseObj[j] is Bullet)
                            if (BaseObj[i].Collision(BaseObj[j]))
                                Console.Beep();
            }
            Buffer.Render();
        }
        /// <summary>
        /// Первоначальная загрузка объектов
        /// </summary>
        public static void Load()
        {
            for (int i = 0; i < Settings.ElementsCount; i++) // Заполняем все элементы
            {
                int r = Rand.Next(Settings.MinElementSize, Settings.MaxElementSize);
                if (i < Settings.AsteroidsCount)
                {
                    Asteroids.Add(new Asteroid(new Point(Rand.Next(Settings.SpaceShipStartPos.X + 300, Settings.FieldWidth),
                    Rand.Next(0, Settings.FieldHeight)), new Point(-Rand.Next(5, 10), -i / 2 - 1), 10));
                    BaseObj.Add(Asteroids[Asteroids.Count - 1]);
                }
                else BaseObj.Add(new Star(new Point(Rand.Next(0, Settings.FieldWidth), Rand.Next(10, Settings.FieldHeight)),
                    new Point(-i % 20 - 1, 0), new Size(r / 4, r / 4)));
            }
            SpaceShip = new SpaceShip(Settings.SpaceShipStartPos, new Point(0, 2), 5); // Корабль добавляем последним
            BaseObj.Add(SpaceShip);
            Bullets.Add(new Bullet(new Point(SpaceShip.Pos.X + SpaceShip.Img.Size.Width, SpaceShip.Pos.Y), new Point(10, 0), 10));
            BaseObj.Add(Bullets[Bullets.Count - 1]);
        }
        /// <summary>
        /// Обновление каждого объекта
        /// </summary>
        public static void Update()
        {
            foreach (var obj in BaseObj) obj.Update();
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
        static void InitLists()
        {
            BaseObj = new List<BaseObject>();
            Asteroids = new List<Asteroid>();
            Bullets = new List<Bullet>();
        }
    }
}
