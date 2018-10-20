using System;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    static class Game
    {
        static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer { get; set; }
        public static SpaceShip SpaceShip { get; set; }
        public static BaseObject[] BaseObj { get; set; }
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
            Width = form.Width;
            Height = form.Height;
            Buffer = context.Allocate(g, new Rectangle(0, 0, Width, Height));
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
            for (int i = 0; i < BaseObj.Length; i++)
                if (BaseObj[i] is Star || BaseObj[i] is SpaceShip) BaseObj[i].Draw();
                else if (BaseObj[i] is Asteroid) (BaseObj[i] as Asteroid).Draw(i / Asteroid.Images.Length);
            Buffer.Render();
        }
        /// <summary>
        /// Первоначальная загрузка объектов
        /// </summary>
        public static void Load()
        {
            BaseObj = new BaseObject[Settings.ElementsCount + 1]; // +1 - для корабля
            for (int i = 0; i < BaseObj.Length - 1; i++) // Заполняем все элементы, кроме последнего
            {
                int r = Rand.Next(Settings.MinElementSize, Settings.MaxElementSize);
                if (i < Settings.AsteroidsCount) BaseObj[i] = 
                        new Asteroid(new Point(Rand.Next(Settings.SpaceShipStartPos.X + 300, Settings.FieldWidth), Rand.Next(0, Settings.FieldHeight)),
                    new Point(-Rand.Next(5, 10), -i / 2 - 1), 10);
                else BaseObj[i] = new Star(new Point(Rand.Next(0, Settings.FieldWidth), Rand.Next(10, Settings.FieldHeight)),
                    new Point(-i % 20 - 1, 0), new Size(r / 4, r / 4));
            }
            BaseObj[BaseObj.Length - 1] = new SpaceShip(Settings.SpaceShipStartPos, new Point(0, 2), 5); // Корабль добавляем последним
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
    }
}
