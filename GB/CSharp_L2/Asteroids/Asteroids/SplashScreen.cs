using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Asteroids
{
    class SplashScreen
    {
        static List<Button> btnList = new List<Button>(); // Список кнопок формы
        public static void Greeting(Form form)
        {
            // Кнопка "Начать игру"
            Button startGameBtn = new Button()
            {
                Width = 200,
                Height = 50,
                Text = Settings.GameStart,
                Font = new Font(Settings.GreetingsBtnFont, 18F, FontStyle.Italic),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Popup,
                Location = new Point(20, 10)
            };
            btnList.Add(startGameBtn);
            // Кнопка "Выйти"
            Button exitBtn = new Button()
            {
                Width = 200,
                Height = 50,
                Text = Settings.GameEnd,
                Font = new Font(Settings.GreetingsBtnFont, 18F, FontStyle.Italic),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Popup,
                Location = new Point(40 + startGameBtn.Width, 10)
            };
            btnList.Add(exitBtn);
            foreach (var b in btnList) form.Controls.Add(b);
            startGameBtn.Click += (object sender, EventArgs e) =>
            {
                foreach (var b in btnList) b.Visible = false;
                MessageBox.Show("Игра началась!", $"Привет, {Settings.UserName}!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            };
            exitBtn.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
            };
        }
        
    }
}
