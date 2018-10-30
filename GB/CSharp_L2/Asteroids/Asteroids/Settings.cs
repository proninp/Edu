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
        public static int FieldWidth { get; set; } = 800;
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public static int FieldMaxHeight { get; set; } = 1000;
        /// <summary>
        /// Максимальная ширина игрового поля
        /// </summary>
        public static int FieldMaxWidth { get; set; } = 1000;
        /// <summary>
        /// Максимальная высота игрового поля
        /// </summary>
        public static int FieldHeight { get; set; } = 600;
        #endregion

        #region Настройки элементов игры
        /// <summary>
        /// Минимальный размер элемента
        /// </summary>
        public static int MinElementSize { get; set; } = 5;
        /// <summary>
        /// Максимальный размер элемента
        /// </summary>
        public static int MaxElementSize { get; set; } = 30;
        /// <summary>
        /// Количество астероидов на игровом поле
        /// </summary>
        public static int AsteroidsCount { get; set; } = 12;
        /// <summary>
        /// Максимальный уровень урона астероида
        /// </summary>
        public static int AsteroidsMaxDamage { get; set; } = 40;
        /// <summary>
        /// Минимальный уровень урона у астероида
        /// </summary>
        public static int AsteroidsMinDamage { get; set; } = 5;
        /// <summary>
        /// Количество звезд на поле
        /// </summary>
        public static int StarsCount { get; } = 40;
        /// <summary>
        /// Стартовая позиция корабля
        /// </summary>
        public static Point SpaceShipStartPos { get; set; } = new Point(50, 300);
        /// <summary>
        /// Уровень жизни для SpaceShip
        /// </summary>
        public static int SpaceShipMaxHealth { get; set; } = 100;
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
        /// Шаг изменения позиции астероидов по уровням сложности
        /// </summary>
        public static Dictionary<int, int[]> AsteroidsDir { get; } = new Dictionary<int, int[]> {
            [0] = new int[] { -10, -5 },
            [1] = new int[] { -10, 10 },
            [2] = new int[] { 5, 15 }
        };
        
        #endregion

        #region Описания Элементов формы и исключительных ситуаций
        /// <summary>
        /// Шрифт кнопки приветсвия
        /// </summary>
        public static string GreetingsBtnFont { get; set; } = "Microsoft Sans Serif";
        /// <summary>
        /// Текст кнопки старта игры
        /// </summary>
        public static string GameStart { get; set; } = "Начать игру";
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
        #endregion
    }
}
