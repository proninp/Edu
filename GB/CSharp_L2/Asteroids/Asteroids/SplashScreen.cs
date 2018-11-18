﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Asteroids
{
    class SplashScreen
    {
        public static List<Button> BtnList { get; set; } = new List<Button>(); // Список кнопок формы
        // Кнопка "Новая игра"
        public static Button NewGameBtn = new Button()
        {
            Name = Settings.ButtonNames[0],
            Size = Settings.ButtonSize,
            Text = Settings.GameStart,
            //Visible = true,
            Font = new Font(Settings.MainFont, 18F, FontStyle.Italic),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Popup,
            Location = new Point(Settings.FieldWidth / 2 - Settings.ButtonSize.Width / 2, 10)
        };
        // Кнопка "Выйти"
        public static Button ExitBtn = new Button()
        {
            Name = Settings.ButtonNames[1],
            Size = Settings.ButtonSize,
            Text = Settings.GameEnd,
            //Visible = true,
            Font = new Font(Settings.MainFont, 18F, FontStyle.Italic),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Popup,
            Location = new Point(Settings.FieldWidth / 2 - Settings.ButtonSize.Width / 2, 10)
        };
        // Кнопка "Продолжить игру"
        public static Button GameContinueBtn = new Button()
        {
            Name = Settings.ButtonNames[2],
            Size = Settings.ButtonSize,
            Text = Settings.GameContinue,
            //Visible = false,
            Font = new Font(Settings.MainFont, 18F, FontStyle.Italic),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Popup,
            Location = new Point(Settings.FieldWidth / 2 - Settings.ButtonSize.Width / 2, 10)
        };
        // Кнопка "Рекорды"
        public static Button RecordsBtn = new Button()
        {
            Name = Settings.ButtonNames[3],
            Size = Settings.ButtonSize,
            Text = Settings.Records,
            //Visible = true,
            Font = new Font(Settings.MainFont, 18F, FontStyle.Italic),
            ForeColor = Color.White,
            BackColor = Color.Transparent,
            FlatStyle = FlatStyle.Popup,
            Location = new Point(Settings.FieldWidth / 2 - Settings.ButtonSize.Width / 2, 10)
        };
        // Лэйбл Паузы
        public static Label PauseLbl = new Label()
        {
            Text = "Pause",
            //Visible = false,
            Font = new Font(Settings.MainFont, 24, FontStyle.Bold),
            Size = Settings.PauseLblSize,
            TextAlign = ContentAlignment.TopLeft,
            ForeColor = Color.White,
            Location = new Point(Settings.FieldWidth / 2 - Settings.PauseLblSize.Width / 2, Settings.FieldHeight / 2 - Settings.PauseLblSize.Height),
            BackColor = Color.Transparent
        };
        public static void ControlsInit(Form form)
        {
            BtnList.Clear();
            BtnList.Add(GameContinueBtn);
            BtnList.Add(NewGameBtn);
            BtnList.Add(RecordsBtn);
            BtnList.Add(ExitBtn);
            ShowMenu(form, true); // Показать меню
            foreach (var b in BtnList) form.Controls.Add(b);
            #region Описание событий
            // Событие нажатия "Начать игру"
            NewGameBtn.Click += (object sender, EventArgs e) =>
            {
                ShowMenu(form, false);
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
                if (e.KeyCode == Keys.Escape && Game.GameStarting)
                {
                    Game.Pause();
                    PauseLbl.Visible = !PauseLbl.Visible;
                }
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
        /// <summary>
        /// Поиск стартовой позиции для кнопок меню
        /// </summary>
        /// <returns>Позиция по оси Y</returns>
        public static int GetStartPos() => Settings.FieldHeight / 2 - (BtnList.Where(b => b.Visible).ToList().Count * Settings.ButtonSize.Height + BtnList.Where(b => b.Visible).ToList().Count * Settings.HeightBetweenButtons) / 2;
        /// <summary>
        /// Функция отображения меню
        /// </summary>
        /// <param name="form">Основная форма</param>
        /// <param name="isShow">Показать меню</param>
        public static void ShowMenu(Form form, bool isShow)
        {
            int startPos = GetStartPos();
            int deltaHeight = 0;
            for (int i = 0; i < BtnList.Count; i++)
            {
                BtnList[i].Visible = isShow;
                if (BtnList[i].Name == Settings.ButtonNames[2] && isShow)
                    BtnList[i].Visible = Game.GameStarting; // Продолжить игру
                if (BtnList[i].Visible)
                {
                    BtnList[i].Location = new Point(BtnList[i].Location.X, startPos + deltaHeight);
                    deltaHeight += Settings.ButtonSize.Height + Settings.HeightBetweenButtons;
                }
            }
        }
    }
}
