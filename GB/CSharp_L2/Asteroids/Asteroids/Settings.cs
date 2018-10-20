using System.Drawing;
namespace Asteroids
{
    class Settings
    {
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public static int FieldWidth { get; set; } = 800;
        /// <summary>
        /// Высота игрового поля
        /// </summary>
        public static int FieldHeight { get; set; } = 600;
        /// <summary>
        /// Общее количество элементов игрового поля
        /// </summary>
        public static int ElementsCount { get; set; } = 50;
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
        public static int AsteroidsCount { get; } = 9;
        /// <summary>
        /// Стартовая позиция корабля
        /// </summary>
        public static Point SpaceShipStartPos { get; set; } = new Point(50, 300);
        /// <summary>
        /// Шрифт кнопки приветсвия
        /// </summary>
        public static string GreetingsBtnFont { get; set; } = "Microsoft Sans Serif";
        /// <summary>
        /// Текст кнопки старта игры
        /// </summary>
        public static string GameStart { get; set; } = "Начать игру";
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
        /// Максимальная позиция передвижения корабля вертикали
        /// </summary>
        public static int ShipMaxYPos = 400;
        /// <summary>
        /// Максимальная позиция передвижения корабля горизонтали
        /// </summary>
        public static int ShipMinYPos = 200;
    }
}
