using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        int guessNumber = 0;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Проверка вводимых символов: если не Enter, не Backspace и не число - отбрасывать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNumber) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Back);
        }
        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Сбрасываем состояния элементов
            ResetControls();
        }
        // Нажаие клавиши Enter
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(tbGuessNum.Text, out int num))
                    if (num == guessNumber)
                    {
                        lblStatusValue.Text = "Угадали!";
                        if (MessageBox.Show("Вы угадали!\nХотите сыграть еще раз?", "Поздравляем!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            ResetControls();
                        else Application.Exit();
                    }
                    else
                    {
                        lblStatusValue.Text = ((num > guessNumber) ? "Нужно меньше!" : "Нужно больше!");
                        tbGuessNum.Text = "";
                        lblStatusValue.Visible = true;
                    }
                // Отключаем звук нажатия клавиши Enter, т.к. раздражает
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        // Новая игра
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        // Показать число
        private void showNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Число:\n" + guessNumber, "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // Выход из игры
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно уверены, что хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
        /// <summary>
        /// Сбросить в исходное состояние все элементы управления
        /// </summary>
        private void ResetControls()
        {
            lblStatusValue.Visible = false;
            tbGuessNum.Text = "";
            guessNumber = r.Next(1, 101);
        }
    }
}
