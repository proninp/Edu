using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    static class Game
    {
        static BufferedGraphicsContext context;
        public static BufferedGraphics Buffer { get; set; }
        public static BaseObject[] BaseObj { get; set; }
        public static Random Rand { get; set; }
        public static int Width { get; set; }
        public static int Height { get; set; }

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
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (var obj in BaseObj)
                obj.Draw();
            Buffer.Render();
        }
        public static void Load()
        {
            BaseObj = new BaseObject[50];
            for (int i = 0; i < BaseObj.Length; i++)
            {
                int r = Rand.Next(5, 30);
                if (i < 3) BaseObj[i] = new BaseObject(new Point(600, i * i * i ), new Point(- i, -i / 2 - 1), new Size(r, r));
                else if (i > 2 && i < 6) BaseObj[i] = new BaseObject(new Point(600, i * i * i), new Point(-i, i / 2), new Size(r, r));
                else BaseObj[i] = new Star(new Point(600, i * 20), new Point(-i % 20 - 1, 0), new Size(r/4, r/4));
            }
                
        }
        public static void Update()
        {
            foreach (var obj in BaseObj)
                obj.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
