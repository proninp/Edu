using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Asteroids
{
    class SplashScreen
    {
        public static List<Button> BtnList { get; set; } = new List<Button>(); // Список кнопок формы
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
            BtnList.Add(startGameBtn);
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
            BtnList.Add(exitBtn);
            foreach (var b in BtnList) form.Controls.Add(b);
            #region Описание событий
            // Событие нажатия "Начать игру"
            startGameBtn.Click += (object sender, EventArgs e) =>
            {
                foreach (var b in BtnList) b.Visible = false;
                if (MessageBox.Show("Игра началась!\n" + Settings.GameRules, $"Привет, {Settings.UserName}!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    Game.BasicLoad();
            };
            // Событие нажатия "Выход"
            exitBtn.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
            };
            // Событие нажатия клавиш
            form.KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Space) Game.Ship?.Fire(true);
                if (e.KeyCode == Keys.Up) Game.Ship?.Up(true);
                if (e.KeyCode == Keys.Down) Game.Ship?.Down(true);
                if (e.KeyCode == Keys.Left) Game.Ship?.Left(true);
                if (e.KeyCode == Keys.Right) Game.Ship?.Right(true);
            };
            form.KeyUp += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Space) Game.Ship?.Fire(false);
                if (e.KeyCode == Keys.Up) Game.Ship?.Up(false);
                if (e.KeyCode == Keys.Down) Game.Ship?.Down(false);
                if (e.KeyCode == Keys.Left) Game.Ship?.Left(false);
                if (e.KeyCode == Keys.Right) Game.Ship?.Right(false);
            };
            #endregion
        }

    }
}
