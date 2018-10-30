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
                // TODO перенести проверки в свойство поля SpaceShip
                if (e.KeyCode == Keys.Space)
                    Game.Bullets?.Add(new Bullet(new Point(Game.SpaceShip.Pos.X + Bullet.Img.Size.Width/2, Game.SpaceShip.Pos.Y + SpaceShip.Img.Size.Height / 4),
                        new Point(15, 0), 10));
                if (e.KeyCode == Keys.Up) Game.SpaceShip?.Up(true);
                if (e.KeyCode == Keys.Down) Game.SpaceShip?.Down(true);
                if (e.KeyCode == Keys.Left) Game.SpaceShip?.Left(true);
                if (e.KeyCode == Keys.Right) Game.SpaceShip?.Right(true);
            };
            form.KeyUp += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Up) Game.SpaceShip?.Up(false);
                if (e.KeyCode == Keys.Down) Game.SpaceShip?.Down(false);
                if (e.KeyCode == Keys.Left) Game.SpaceShip?.Left(false);
                if (e.KeyCode == Keys.Right) Game.SpaceShip?.Right(false);
            };
            #endregion
        }

    }
}
