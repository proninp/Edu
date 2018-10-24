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
        public static BufferedGraphics Buffer { get; set; }
        public static SpaceShip SpaceShip { get; set; }
        public static List<BaseObject> BaseObj { get; set; }
        public static List<Asteroid> Asteroids { get; set; } // Список астероидов
        public static List<Bullet> Bullets { get; set; } // Список снарядов
        public static List<Explode> Explodes { get; set; } // Список взрывов
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
            // TODO сделать инициализацию основных игровых объектов только после нажатия кнопки начать игру
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
            {
                bool isHit = false;
                if (BaseObj[i] is Asteroid) // Проверк на столкновение
                {
                    for (int j = 0; j < Bullets.Count; j++)
                        if (BaseObj[i].Collision(Bullets[j]))
                        {
                            Bullets[j].Pos.X = Settings.FieldMaxWidth; // Чтобы сразу скрыть
                            Bullets[j] = null;
                            Bullets.RemoveAt(j);
                            isHit = true;
                            break;
                        }
                    if (isHit)
                    {
                        Explodes.Add(new Explode(BaseObj[i].Pos)); // Создание взрыва
                        BaseObj[i].Draw(); // Отрисовка астероида в новом случайном месте на поле
                    }
                    else (BaseObj[i] as Asteroid).Draw(i / Asteroid.Images.Length);
                }
                else BaseObj[i].Draw();
                foreach (var e in Bullets) e.Draw();
                foreach (var e in Explodes) e.Draw();
                SpaceShip.Draw();
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
        }
        /// <summary>
        /// Обновление каждого объекта
        /// </summary>
        public static void Update()
        {
            foreach (var obj in BaseObj) obj.Update();
            foreach (var obj in Bullets) obj.Update();
            // Проверка на необходимость удаления взрыва
            for (int i = 0; i < Explodes.Count; i++)
            {
                Explodes[i].Update();
                if (Explodes[i].VisabilityTicksCount <= 0)
                {
                    Explodes[i].Pos.X = Settings.FieldMaxWidth;
                    Explodes[i] = null;
                    Explodes.RemoveAt(i);
                    i--;
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
        /// Инициализация списков
        /// </summary>
        static void InitLists()
        {
            BaseObj = new List<BaseObject>();
            Asteroids = new List<Asteroid>(Settings.AsteroidsCount);
            Bullets = new List<Bullet>();
            Explodes = new List<Explode>(Settings.AsteroidsCount);
        }
    }
}
