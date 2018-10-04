namespace Asteroids
{
    class Settings
    {
        public static int ElementsCount { get; set; } = 50;
        public static int MinElementSize { get; set; } = 5;
        public static int MaxElementSize { get; set; } = 30;
        public static string GreetingsBtnFont { get; set; } = "Microsoft Sans Serif";
        public static string GreetingsBtnText { get; set; } = "Поехали";
        public static string UserName { get; set; } = (!System.Security.Principal.WindowsIdentity.GetCurrent().Name.Contains("\\") ?
            System.Security.Principal.WindowsIdentity.GetCurrent().Name :
            System.Security.Principal.WindowsIdentity.GetCurrent().Name.
            Substring(System.Security.Principal.WindowsIdentity.GetCurrent().Name.IndexOf("\\") + 1));
        public static string ShipImgPath { get; set; } = "..\\..\\pics\\spaceship_min.png";
        public static int ShipMaxYPos = 400;
        public static int ShipMinYPos = 200;

    }
}
