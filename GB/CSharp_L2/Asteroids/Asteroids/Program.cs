using System;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.MaximizeBox = false;
            form.MaximumSize = form.Size;
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);


        }
    }
}
