using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using St = Asteroids.Settings;

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
        public static RepublicsShip Ship { get; set; }
        public static List<BaseObject> BaseObj { get; set; }
        public static List<Empires> Asteroids { get; set; } // Список астероидов
        public static List<Bullet> Bullets { get; set; } // Список снарядов
        public static List<Explode> Explodes { get; set; } // Список взрывов
        public static List<Kit> Kits { get; set; } // Список аптечек
        public static Random Rand { get; set; }
        public static Image SpaceImg { get; set; } = Properties.Resources.background;
        private static Timer Timer = new Timer { Interval = 80 };
        public static int DiffLvl { get; set; } = 0; // Уровень сложности (0, 1, 2)
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static bool GameStart { get; set; }
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
            if (Width > St.FieldMaxWidth || Height > St.FieldMaxHeight || Width < 0 || Height < 0)
                throw new GameObjectException(St.WindowSizeException);
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
            for (int i = Asteroids.Count - 1; i >= 0 ; i--) // Проверка столкновения астероидов с пулями
                for (int j = Bullets.Count - 1; j >= 0; j--)
                    if (Asteroids[i].Collision(Bullets[j]))
                    {
                        Bullets[j].Pos.X = St.FieldMaxWidth; // Чтобы сразу скрыть
                        Bullets[j].Del(Bullets, j);
                        Explodes.Add(new Explode(Asteroids[i].Pos)); // Создание взрыва
                        Asteroids[i].Del(Asteroids, i);
                        break;
                    }
            if (Ship != null)
            {
                for (int i = Asteroids.Count - 1; i >= 0; i--) // Проверка столкновения астероидов с кораблём
                    if (Asteroids[i].Collision(Ship))
                    {
                        Explodes.Add(new Explode(Asteroids[i].Pos));
                        Ship.GetDamage(Asteroids[i].Health);
                        Asteroids[i].Del(Asteroids, i);
                    }
                for (int i = Kits.Count - 1; i >= 0; i--) // Проверка столкновения аптечки с кораблём
                    if (Ship != null && Kits[i].Collision(Ship))
                    {
                        Kit.KitsCount--;
                        Ship.GetDamage(Kits[i].Health);
                        Kits[i].Pos.X = St.FieldMaxWidth;
                        Kits[i].Del(Kits, i);
                    }
            }
            foreach (var e in Bullets) e.Draw();
            foreach (var e in Explodes) e.Draw();
            foreach (var e in Kits) e.Draw();
            foreach (var e in Asteroids) e.Draw();
            Ship?.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// Первоначальная загрузка объектов до нажатия кнопки "Начать игру"
        /// Инициализация объектов Star
        /// </summary>
        public static void InitialLoad()
        {
            InitLists();
            int r = Rand.Next(St.MinElementSize, St.MaxElementSize);
            for (int i = 0; i < St.StarsCount; i++)
                BaseObj.Add(new Star(new Point(Rand.Next(0, St.FieldWidth), Rand.Next(10, St.FieldHeight)),
                    new Point(-i % 20 - 1, 0), new Size(r / 4, r / 4)));
        }
        /// <summary>
        /// Загрузка объектов после нажатия кнопки "Начать игру"
        /// Добавляет объект Ship, Asteroid и Kit
        /// </summary>
        public static void BasicLoad()
        {
            GameStart = true;
            for (int i = 0; i < St.AsteroidsCount[DiffLvl]; i++)
                Asteroids.Add(new Empires(
                    new Point(Rand.Next(St.SpaceShipStartPos.X + 300, St.FieldWidth), Rand.Next(St.AsteroidAvgHeight, St.FieldHeight- St.AsteroidAvgHeight)), 
                    new Point(Rand.Next(St.AsteroidsDir[DiffLvl][0], St.AsteroidsDir[DiffLvl][1]), i / 2 - 1), 
                    Rand.Next(St.AsteroidsMinDamage[DiffLvl], St.AsteroidsMaxDamage[DiffLvl])));
            Ship = new RepublicsShip(St.SpaceShipStartPos, new Point(0, 0), St.SpaceShipMaxHealth);
            RepublicsShip.MessageDie += Finish;
        }
        /// <summary>
        /// Обновление каждого объекта
        /// </summary>
        public static void Update()
        {
            foreach (var o in BaseObj) o.Update();
            foreach (var o in Asteroids) o.Update();
            foreach (var o in Bullets) o.Update();
            foreach (var o in Kits) o.Update();
            UpdateKits();
            Ship?.Update();
            for (int i = Explodes.Count - 1; i >= 0; i--) // Проверка на необходимость удаления взрыва
            {
                Explodes[i].Update();
                if (Explodes[i].VisabilityTicksCount > 0 && Explodes[i].VisabilityTicksCount < 4) { if (Ship.Health <= 0) Ship.Die(); }
                else if (Explodes[i].VisabilityTicksCount <= 0)
                {
                    Explodes[i].Pos.X = St.FieldMaxWidth;
                    Explodes[i].Del(Explodes, i);
                }
            }
            IsEndLevel();
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
            Asteroids = new List<Empires>(St.AsteroidsCount[DiffLvl]);
            Bullets = new List<Bullet>();
            Explodes = new List<Explode>(St.AsteroidsCount[DiffLvl]);
            Kits = new List<Kit>();
        }
        /// <summary>
        /// Конец игры
        /// </summary>
        public static void Finish()
        {
            Timer.Stop();
            if (MessageBox.Show(St.LooseMessage, St.LooseMessageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
            else Restart();
        }
        /// <summary>
        /// Перезагрузка основных объектов для рестарта игры
        /// </summary>
        public static void Restart()
        {
            InitLists();
            Ship = null;
            RepublicsShip.MessageDie -= Finish; // Убираем, чтобы в списке вызовов не было дублирования
            Timer.Tick -= Timer_Tick; // Так же, убираем
            Init(MainForm);
            foreach (var e in SplashScreen.BtnList) e.Visible = true;
        }
        /// <summary>
        /// Создание и удаление аптечек
        /// </summary>
        private static void UpdateKits()
        {
            if (Kit.KitsCount > 0 && Rand.Next(0, St.KitAppearence) == Rand.Next(0, St.KitAppearence) && Ship?.Health < St.SpaceShipMaxHealth * 0.5) // Создание новых аптечек
                Kits.Add(new Kit(new Point(St.FieldMaxWidth - Kit.Img.Size.Width, Rand.Next(Kit.Img.Size.Height, St.FieldMaxHeight - Kit.Img.Size.Height)),
                    new Point(-St.KitDir[DiffLvl], Rand.Next(-St.KitDir[DiffLvl], St.KitDir[DiffLvl]))));
            for (int i = Kits.Count - 1; i >= 0; i--) // Обновление и удаление пропущенных аптечек
            {
                Kits[i].Update();
                if (Kits[i].Pos.X + Kit.Img.Size.Width < 0)
                    Kits[i].Del(Kits, i);
            }
        }
        /// <summary>
        /// Смена уровня сложности
        /// </summary>
        /// <param name="lvl">Уровень сложности</param>
        public static void ChangeDifficultLevel(int lvl)
        {
            DiffLvl = lvl;
            Kit.KitsCount = St.KitsCount[DiffLvl];
            Restart();
        }
        /// <summary>
        /// Определяем прохождение текущего уровня
        /// </summary>
        private static void IsEndLevel()
        {
            if (Asteroids?.Count == 0 && Ship?.Health > 0)
            {
                Finish();
            }
        }
        private static void UpdateButtons()
        {
            foreach (var b in SplashScreen.BtnList) b.Visible = true;
        }

    }
}