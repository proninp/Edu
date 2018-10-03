using System;
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
        //static Game()
        //{

        //}
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
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();
            Buffer.Graphics.Clear(Color.Black);
            foreach (var obj in BaseObj)
                obj.Draw();
            Buffer.Render();
        }
        public static void Load()
        {
            BaseObj = new BaseObject[60];
            for (int i = 0; i < BaseObj.Length; i++)
            {
                int r = Rand.Next(5, 20);
                if (i % 3 == 0) BaseObj[i] = new BaseObject(new Point(600, i * 20), new Point(- i, -i), new Size(r, r));
                else BaseObj[i] = new Star(new Point(600, i * 20), new Point(-i, 0), new Size(r/2, r/2));
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
