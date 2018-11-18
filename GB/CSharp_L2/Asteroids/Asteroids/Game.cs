using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using St = Asteroids.Settings;

namespace Asteroids
{
    /*
     * Пронин П.С.
     * В данной игре вместо астероидов представлены корабли Империи из фильма "Star Wars"
     * TODO:
     * Доработать главное меню, добавить возможность ставить игру на паузу
     * Доработать систему рекордов
     */
    static class Game
    {
        static BufferedGraphicsContext context;
        static Form MainForm { get; set; }
        public static BufferedGraphics Buffer { get; set; }
        public static Ship Ship { get; set; }
        public static List<Stat> Stats { get; set; }
        public static List<BaseObject> BaseObj { get; set; }
        public static List<EmpireShip> EmpireShips { get; set; } // Список астероидов
        public static List<Bullet> PlayerBullets { get; set; } // Список снарядов игрока
        public static List<Bullet> EnemiesBullets { get; set; } // Список снарядов кораблей Империи
        public static List<Explode> Explodes { get; set; } // Список взрывов
        public static List<Kit> Kits { get; set; } // Список аптечек
        public static Random Rand { get; set; }
        public static Image SpaceImg { get; set; } = Properties.Resources.background;
        private static Timer Timer = new Timer { Interval = 80 };
        public static int DiffLvl { get; set; } // Уровень сложности (0, 1, 2)
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static bool GameStarting { get; set; }
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
            CreateEnemiesShips();
            foreach (var e in BaseObj) e.Draw();
            if (Ship != null)
            {
                for (int i = EmpireShips.Count - 1; i >= 0; i--)
                {
                    if (EmpireShips[i].Collision(Ship)) // Проверка столкновения корабля-противника с кораблём
                    {
                        Explodes.Add(new Explode(EmpireShips[i].Pos));
                        Ship.GetDamage(EmpireShips[i].Health);
                        EmpireShips[i].Die(EmpireShips, i);
                        continue;
                    }
                    for (int j = PlayerBullets.Count - 1; j >= 0; j--)
                        if (EmpireShips[i].Collision(PlayerBullets[j])) // Проверка столкновения кораблей-противников с пулями
                        {
                            PlayerBullets[j].Del(PlayerBullets, j);
                            Explodes.Add(new Explode(EmpireShips[i].Pos));
                            EmpireShips[i].Die(EmpireShips, i);
                            break;
                        }
                }
                for (int i = EnemiesBullets.Count - 1; i >= 0; i--)
                {
                    if (EnemiesBullets[i].Collision(Ship)) // Проверка на столкновение пули корабля-противника с кораблём игрока
                    {
                        Explodes.Add(new Explode(EnemiesBullets[i].Pos));
                        Ship.GetDamage(EnemiesBullets[i].Health);
                        EnemiesBullets[i].Del(EnemiesBullets, i);
                        continue;
                    }
                    for (int j = PlayerBullets.Count - 1; j >= 0; j--)
                        if (EnemiesBullets[i].Collision(PlayerBullets[j])) // Проверка на столкновение пуль игрока с пулями кораблей-противников
                        {
                            PlayerBullets[j].Del(PlayerBullets, j);
                            Explodes.Add(new Explode(EnemiesBullets[i].Pos));
                            EnemiesBullets[i].Del(EnemiesBullets, i);
                            break;
                        }
                }
                for (int i = Kits.Count - 1; i >= 0; i--)
                    if (Ship != null && Kits[i].Collision(Ship)) // Проверка столкновения аптечки с кораблём
                    {
                        Ship.GetDamage(Kits[i].Health);
                        Kits[i].Del(Kits, i);
                    }
            }
            foreach (var e in PlayerBullets) e.Draw();
            foreach (var e in EnemiesBullets) e.Draw();
            foreach (var e in EnemiesBullets) e.Draw();
            foreach (var e in Explodes) e.Draw();
            foreach (var e in Kits) e.Draw();
            foreach (var e in EmpireShips) e.Draw();
            foreach (var e in Stats) e.Draw();
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
            DiffLvl = St.MinDiffLevel;
            EmpireShip.DestroyedShips = 0; // Обнуляем кол-во сбитых кораблей - противников
            EmpireShip.CreatedShips = 0; // Обнуляем кол-во созданных кораблей - противников
            for (int i = 0; i < St.StarsCount; i++)
                BaseObj.Add(new Star(new Point(Rand.Next(0, St.FieldWidth),Rand.Next(10, St.FieldHeight)),
                    new Point(i % 20 - 1, 0),
                    new Size(St.MinStarSize, St.MaxStarSize)));
        }
        /// <summary>
        /// Загрузка объектов после нажатия кнопки "Начать игру"
        /// Добавляет объект Ship, Asteroid и Kit
        /// </summary>
        public static void BasicLoad()
        {
            GameStarting = true;
            Ship = new Ship(St.SpaceShipStartPos, new Point(0, 0), St.SpaceShipMaxHealth, St.SpaceShipMaxEnergy);
            Stats.Add(new Stat(St.ScoreStatPos, St.ScoreStatText, 0));
            Stats.Add(new Stat(St.LevelStatPos, St.DiffLevelStatText, 1));
        }
        /// <summary>
        /// Заполнениее списка кораблей - противников новыми экземплярами
        /// </summary>
        public static void CreateEnemiesShips()
        {
            if (GameStarting && (EmpireShip.CreatedShips < St.EmpireShipsCount[DiffLvl]) && (Rand.Next(St.EmpireShipsCreatingChance[DiffLvl]) == Rand.Next(St.EmpireShipsCreatingChance[DiffLvl])))
                EmpireShips.Add(new EmpireShip(
                    new Point(Width + Rand.Next(50, 100), Rand.Next(50, Height)),
                    new Point(Rand.Next(St.AsteroidsDir[DiffLvl][0], St.AsteroidsDir[DiffLvl][1]), (EmpireShip.DestroyedShips + 2) / 2 * (Rand.Next(0, 2) * 2 - 1)),
                    Rand.Next(St.EmpireShipMinDamage[DiffLvl], St.EmpireShipMaxDamage[DiffLvl])));
        }
        /// <summary>
        /// Обновление каждого объекта
        /// </summary>
        public static void Update()
        {
            foreach (var o in BaseObj) o.Update();
            foreach (var o in EmpireShips) o.Update();
            foreach (var o in PlayerBullets) o.Update();
            foreach (var e in EnemiesBullets) e.Update();
            foreach (var o in Kits) o.Update();
            UpdateKits();
            Ship?.Update();
            for (int i = Explodes.Count - 1; i >= 0; i--) // Проверка на необходимость удаления взрыва
            {
                Explodes[i].Update();
                if (Explodes[i].VisabilityTicksCount > 0 && Explodes[i].VisabilityTicksCount < 4) { if (Ship.Health <= 0) Finish(St.LooseMessage, St.LooseMessageHeader); }
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
            EmpireShips = new List<EmpireShip>(St.EmpireShipsCount[DiffLvl]);
            PlayerBullets = new List<Bullet>();
            EnemiesBullets = new List<Bullet>();
            Explodes = new List<Explode>(St.EmpireShipsCount[DiffLvl]);
            Kits = new List<Kit>();
            Stats = new List<Stat>();
        }
        /// <summary>
        /// Конец игры
        /// </summary>
        public static void Finish(string message, string messageHeader)
        {
            Timer.Stop();
            GameStarting = false;
            if (MessageBox.Show(message, messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
            else Restart();
        }
        /// <summary>
        /// Перезагрузка основных объектов для рестарта игры
        /// </summary>
        public static void Restart()
        {
            InitLists();
            Ship = null;
            Timer.Tick -= Timer_Tick;
            Init(MainForm);
            BasicLoad();
            //foreach (var e in SplashScreen.BtnList) e.Visible = true;
        }
        public static void LevelUp()
        {
            EmpireShip.DestroyedShips = 0;
            EmpireShip.CreatedShips = 0;
            if (Stats.Count > 1) Stats[1].StatValue = ++DiffLvl + 1; // Стататистика уровня слложности
        }
        /// <summary>
        /// Создание и удаление аптечек
        /// </summary>
        private static void UpdateKits()
        {
            if (Kits.Count == 0 && Rand.Next(0, St.KitAppearence) == Rand.Next(0, St.KitAppearence) && Ship?.Health < St.SpaceShipMaxHealth * 0.5) // Создание новых аптечек
                Kits.Add(new Kit(new Point(St.FieldMaxWidth - Kit.Img.Size.Width, Rand.Next(Kit.Img.Size.Height, St.FieldMaxHeight - Kit.Img.Size.Height)),
                    new Point(-St.KitDir[DiffLvl], Rand.Next(-St.KitDir[DiffLvl], St.KitDir[DiffLvl]))));
            for (int i = Kits.Count - 1; i >= 0; i--) // Обновление и удаление пропущенных аптечек
            {
                Kits[i].Update();
                if (Kits[i].Pos.X + Kit.Img.Size.Width < 0) Kits[i].Del(Kits, i);
            }
        }
        /// <summary>
        /// Определяем прохождение текущего уровня
        /// </summary>
        private static void IsEndLevel()
        {
            if (St.EmpireShipsCount[DiffLvl] == EmpireShip.DestroyedShips && Ship?.Health > 0)
                if (DiffLvl == St.MaxDiffLevel) Finish(St.GameComplete, St.Greetings);
                else LevelUp();
        }
        /// <summary>
        /// Ставим игру на паузу
        /// </summary>
        public static void Pause()
        {
            if (Timer.Enabled)
            {
                SplashScreen.ShowMenu(MainForm, Timer.Enabled);
                Timer.Stop();
            }
            else
            {
                SplashScreen.ShowMenu(MainForm, Timer.Enabled);
                Timer.Start();
            }
        }
    }
}