using System.Collections.Generic;
using System.Drawing;

namespace Asteroids
{
    class Settings
    {
        #region Настройки игрового поля
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public static int FieldWidth { get; set; } = 1000;
        /// <summary>
        /// Максимальная ширина игрового поля
        /// </summary>
        public static int FieldMaxWidth { get; set; } = 1000;
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public static int FieldMaxHeight { get; set; } = 667;
        /// <summary>
        /// Максимальная высота игрового поля
        /// </summary>
        public static int FieldHeight { get; set; } = 667;
        /// <summary>
        /// Размер кнопок
        /// </summary>
        public static Size ButtonSize { get; set; } = new Size(250, 50);
        /// <summary>
        /// Высота между кнопками
        /// </summary>
        public static int HeightBetweenButtons { get; } = 40;
        /// <summary>
        /// Размер лэйбла паузы
        /// </summary>
        public static Size PauseLblSize { get; } = new Size(150, 50);
        public static string[] ButtonNames { get; set; } = { "NewGame", "Exit", "Continue", "Records" };
        #endregion

        #region Настройки элементов игры
        /// <summary>
        /// Минимальный уровень сложности
        /// </summary>
        public static int MinDiffLevel { get; } = 0;
        /// <summary>
        /// Максимальный уровень сложности
        /// </summary>
        public static int MaxDiffLevel { get; } = 2;
        /// <summary>
        /// Минимальный размер звезды
        /// </summary>
        public static int MinStarSize { get; set; } = 1;
        /// <summary>
        /// Максимальный размер звезды
        /// </summary>
        public static int MaxStarSize { get; set; } = 1;
        /// <summary>
        /// Количество кораблей Империи на игровом поле
        /// </summary>
        public static int[] EmpireShipsCount { get; set; } = new int[] { 20, 22, 25 };
        /// <summary>
        /// Шанс создания нового вражеского корабля
        /// </summary>
        public static int[] EmpireShipsCreatingChance { get; set; } = new int[] { 12, 10, 8 };
        /// <summary>
        /// Усредненное значение высоты корабля Империи
        /// </summary>
        public static int EmpireShipAvgHeight { get; set; } = 75;
        /// <summary>
        /// Максимальный уровень урона корабля Империи
        /// </summary>
        public static int[] EmpireShipMaxDamage { get; set; } = new int[] { 30, 40, 50 };
        /// <summary>
        /// Минимальный уровень урона у корабля Империи
        /// </summary>
        public static int[] EmpireShipMinDamage { get; set; } = new int[] { 20, 30, 40 };
        /// <summary>
        /// Шанс выстрела корабля соперника
        /// </summary>
        public static int[] EmpireShipShotChance { get; set; } = new int[] { 50, 40, 30 };
        /// <summary>
        /// Индекс изображения пули корабля Империи
        /// </summary>
        public static int EmpireShipBulletIndex { get; set; } = 1;
        /// <summary>
        /// Количество звезд на поле
        /// </summary>
        public static int StarsCount { get; } = 40;
        /// <summary>
        /// Стартовая позиция корабля
        /// </summary>
        public static Point SpaceShipStartPos { get; set; } = new Point(50, 300);
        /// <summary>
        /// Уровень жизни для Ship
        /// </summary>
        public static int SpaceShipMaxHealth { get; set; } = 100;
        /// <summary>
        /// Энергия корабля для выстрела
        /// </summary>
        public static int SpaceShipMaxEnergy { get; set; } = 100;
        /// <summary>
        /// Сдвиг корабля при нажатии на клавишу управления движением
        /// </summary>
        public static int SpaceShipStep { get; set; } = 7;
        /// <summary>
        /// Интервал таймера класса Game
        /// </summary>
        public static int TimerInterval { get; set; } = 100;
        /// <summary>
        /// Позиция Хелс бара
        /// </summary>
        public static Point HPBarPos { get; set; } = new Point(10, 10);
        /// <summary>
        /// Размер хелс бара
        /// </summary>
        public static Size HPBarSize { get; set; } = new Size(200, 12);
        /// <summary>
        /// Позиция энерджи бара
        /// </summary>
        public static Point EnergyBarPos { get; set; } = new Point(10, HPBarPos.Y + HPBarSize.Height + 20);
        /// <summary>
        /// Размер Energy бара
        /// </summary>
        public static Size EnergyBarSize { get; set; } = new Size(200, 12);
        /// <summary>
        /// Положение отображения статистики счета
        /// </summary>
        public static Point ScoreStatPos { get; set; } = new Point(FieldWidth - 150, 10);
        /// <summary>
        /// Положение отображения статистики уровня сложности
        /// </summary>
        public static Point LevelStatPos { get; set; } = new Point(FieldWidth - 150, 25);
        /// <summary>
        /// Текстовое описание информации о счете игрока
        /// </summary>
        public static string ScoreStatText { get; set; } = "Score: ";
        /// <summary>
        /// Текстовое описание информации о уровне сложности
        /// </summary>
        public static string DiffLevelStatText { get; set; } = "Level: ";
        /// <summary>
        /// Количество энергии, затраченной на выстрел
        /// </summary>
        public static int[] EnergyCostShoot { get; set; } = new int[] { 6, 8, 10 };
        /// <summary>
        /// Шанс восстановления энергии колеблется в зависимости от уровня сложности
        /// </summary>
        public static int[] EnergyRecoveryChance { get; set; } = new int[] { 3, 4, 5 };
        /// <summary>
        /// Шаг изменения позиции астероидов по уровням сложности
        /// </summary>
        public static Dictionary<int, int[]> AsteroidsDir { get; } = new Dictionary<int, int[]> {
            [0] = new int[] { -10, -5 },
            [1] = new int[] { -12, -5 },
            [2] = new int[] { -15, -5 }
        };
        /// <summary>
        /// Скорость перемещения аптечек в зависимости от сложности
        /// </summary>
        public static int[] KitDir { get; } = new int[] { 5, 7, 9};
        /// <summary>
        /// Кол-во аптечек на уровень, в зависимости от сложности
        /// </summary>
        public static int[] KitsCount { get; } = new int[] { 3, 2, 1 };
        /// <summary>
        /// Шанс появления аптечки
        /// </summary>
        public static int KitAppearence { get; } = 150;
        #endregion

        #region Описания Элементов формы и исключительных ситуаций
        /// <summary>
        /// Шрифт кнопки приветсвия
        /// </summary>
        public static string MainFont { get; set; } = "Verdana";
        /// <summary>
        /// Текст кнопки старта игры
        /// </summary>
        public static string GameStart { get; set; } = "Новая игра";
        /// <summary>
        /// Перейти на новый уровень
        /// </summary>
        public static string GameContinue { get; set; } = "Продолжить игру";
        /// <summary>
        /// Сыграть еще раз
        /// </summary>
        public static string Records { get; set; } = "Рекорды";
        /// <summary>
        /// Текст сообщения при старте
        /// </summary>
        public static string GameRules { get; set; } = "Выстрел - пробел;\nУправление кораблём - стрелки.";
        /// <summary>
        /// Текст кнопки выход
        /// </summary>
        public static string GameEnd { get; set; } = "Выход";
        /// <summary>
        /// Получение имени пользователя
        /// </summary>
        public static string UserName { get; set; } = (!System.Security.Principal.WindowsIdentity.GetCurrent().Name.Contains("\\") ?
            System.Security.Principal.WindowsIdentity.GetCurrent().Name :
            System.Security.Principal.WindowsIdentity.GetCurrent().Name.
            Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1));
        /// <summary>
        /// Текст ошибки установки некорректных значений размера экрана
        /// </summary>
        public static string WindowSizeException { get; } = "Некорректно задан размер экрана!";
        /// <summary>
        /// Сообщение о проигрыше в диалоговом окне:
        /// Увы, Ваш корабль сбит!
        /// Выйти?
        /// </summary>
        public static string LooseMessage { get; } = "Увы, Ваш корабль сбит!\nВыйти?";
        /// <summary>
        /// Заголовок для сообщения о проигрыше:
        /// Проиграли!
        /// </summary>
        public static string LooseMessageHeader { get; } = "Проиграли!";
        /// <summary>
        /// Переход на новый уровень
        /// Вы сбили все астероиды! Перейти на новый уровень?
        /// </summary>
        public static string NewLevel { get; } = "Вы сбили все астероиды!\nПерейти на новый уровень?";
        /// <summary>
        /// Поздравительное сообщение
        /// </summary>
        public static string Greetings { get; } = "Поздравляем!";
        /// <summary>
        /// Конец игры
        /// Вы успешно завершили игру! Сыграть еще раз?
        /// </summary>
        public static string GameComplete { get; } = "Вы успешно завершили игру!\nСыграть еще раз?";
        /// <summary>
        /// Конец игры
        /// Вы успешно завершили игру! Сыграть еще раз?
        /// </summary>
        public static string RestartOrQuit { get; } = "Сыграть еще раз или выйти?\nСыграть еще раз?";
        #endregion
    }
}
