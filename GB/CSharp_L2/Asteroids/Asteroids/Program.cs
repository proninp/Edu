﻿using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Asteroids
{
    class Program
    {
        #region Скрыть консоль
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        #endregion

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            Form form = new Form();
            form.Width = 800;
            form.Height = 600;
            form.MaximizeBox = false;
            form.MaximumSize = form.Size;
            Game.Init(form);
            SplashScreen.Greeting(form);
            form.Show();
            Game.Draw();
            Application.Run(form);


        }
    }
}