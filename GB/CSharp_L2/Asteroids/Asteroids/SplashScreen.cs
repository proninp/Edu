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
                MessageBox.Show("Игра началась!\n" + Settings.GameRules, $"Привет, {Settings.UserName}!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            };
            exitBtn.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Application.Exit();
            };
            form.KeyDown += (object sender, KeyEventArgs e) =>
            {
                // TODO перенести проверки в свойство поля SpaceShip
                if (e.KeyCode == Keys.Space)
                    Game.Bullets.Add(new Bullet(new Point(Game.SpaceShip.Pos.X + Bullet.Img.Size.Width/2, Game.SpaceShip.Pos.Y + SpaceShip.Img.Size.Height / 4),
                        new Point(15, 0), 10));
                if (e.KeyCode == Keys.Up) if (Game.SpaceShip.Pos.Y > 0) Game.SpaceShip.Pos.Y -= 5;
                if (e.KeyCode == Keys.Down) if (Game.SpaceShip.Pos.Y < (Settings.FieldHeight - SpaceShip.Img.Size.Height)) Game.SpaceShip.Pos.Y += 5;
                if (e.KeyCode == Keys.Left) if (Game.SpaceShip.Pos.X > 0) Game.SpaceShip.Pos.X -= 5;
                if (e.KeyCode == Keys.Right) if (Game.SpaceShip.Pos.X < (Settings.FieldWidth - SpaceShip.Img.Size.Width)) Game.SpaceShip.Pos.X += 5;
            };
        }
        
    }
}
