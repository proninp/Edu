using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Asteroids
{
    class SplashScreen
    {
        public static List<Button> BtnList { get; set; } = new List<Button>(); // Список кнопок формы
        // Кнопка "Начать игру"
        public static Button StartGameBtn = new Button()
        {
            Size = Settings.ButtonSize,
            Text = Settings.GameStart,
            Font = new Font(Settings.MainFont, 18F, FontStyle.Italic),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Popup,
            Location = new Point(Settings.FieldWidth / 2 - Settings.ButtonSize.Width / 2, 10)
        };
        // Кнопка "Выйти"
        public static Button ExitBtn = new Button()
        {
            Size = Settings.ButtonSize,
            Text = Settings.GameEnd,
            Font = new Font(Settings.MainFont, 18F, FontStyle.Italic),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Popup,
            Location = new Point(Settings.FieldWidth / 2 - Settings.ButtonSize.Width / 2, 10)
        };
        // Кнопка "Перейти на новый уровень"
        public static Button NewLevelBtn = new Button()
        {
            Size = Settings.ButtonSize,
            Text = Settings.GameNextLvl,
            Visible = false,
            Font = new Font(Settings.MainFont, 18F, FontStyle.Italic),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Popup,
            Location = new Point(Settings.FieldWidth / 2 - Settings.ButtonSize.Width / 2, 10)
        }; 
        // Кнопка "Сыграть еще раз"
        public static Button OneMoreGameBtn = new Button()
        {
            Size = Settings.ButtonSize,
            Text = Settings.GamePlayOneMore,
            Visible = false,
            Font = new Font(Settings.MainFont, 18F, FontStyle.Italic),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Popup,
            Location = new Point(Settings.FieldWidth / 2 - Settings.ButtonSize.Width / 2, 10)
        };
        public static void Greeting(Form form)
        {
            BtnList.Clear();
            BtnList.Add(StartGameBtn);
            BtnList.Add(ExitBtn);
            form.Controls.Add(OneMoreGameBtn);
            form.Controls.Add(NewLevelBtn);
            for (int i = 0; i < BtnList.Count; i++)
            {
                int startPos = GetStartPos();
                BtnList[i].Location = new Point(BtnList[i].Location.X, startPos + (i * Settings.ButtonSize.Height) + (i * Settings.HeightBetweenButtons));
                form.Controls.Add(BtnList[i]);
            }
            #region Описание событий
            // Событие нажатия "Начать игру"
            StartGameBtn.Click += (object sender, EventArgs e) =>
            {
                foreach (var b in BtnList) b.Visible = false;
                if (MessageBox.Show("Игра началась!\n" + Settings.GameRules, $"Привет, {Settings.UserName}!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    Game.BasicLoad();
            };
            // Событие нажатия "Выход"
            ExitBtn.Click += (object sender, EventArgs e) =>
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
                if (e.KeyCode == Keys.Escape && Game.GameStarting) Game.Pause();
            };
            form.KeyUp += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Space) Game.Ship?.Fire(false);
                if (e.KeyCode == Keys.Up) Game.Ship?.Up(false);
                if (e.KeyCode == Keys.Down) Game.Ship?.Down(false);
                if (e.KeyCode == Keys.Left) Game.Ship?.Left(false);
                if (e.KeyCode == Keys.Right) Game.Ship?.Right(false);
            };
            OneMoreGameBtn.Click += (object sender, EventArgs e) => Game.Restart();
            #endregion
        }
        public static int GetStartPos() => Settings.FieldHeight / 2 - (BtnList.Count * Settings.ButtonSize.Height + (BtnList.Count - 1) * Settings.HeightBetweenButtons);
    }
}
