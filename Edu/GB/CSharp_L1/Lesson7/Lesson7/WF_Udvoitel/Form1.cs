using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        List<int> values = new List<int>(); // Записываем значение каждого шага
        int[] steps; // Изначально сделал при помощи List, но при быстром нажатии кнопок отрабатывало некорректно
        int i;

        public Form1()
        {
            InitializeComponent();
        }

        #region События
        // Прибавляем 1
        private void btnCommand1_Click(object sender, EventArgs e)
        {
            steps[i] = int.Parse(lblNumber.Text);
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
            i++;
            StepsCheck();
        }
        // Умножаем на 2
        private void btnCommand2_Click(object sender, EventArgs e)
        {
            steps[i] = int.Parse(lblNumber.Text);
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
            i++;
            StepsCheck();
        }
        // Сбрасываем до 0
        private void btnReset_Click(object sender, EventArgs e)
        {
            steps[i] = int.Parse(lblNumber.Text);
            lblNumber.Text = "0";
            i++;
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
        }
        // Новая игра
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        // Выход
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно уверены, что хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
        // Отменить последний ход
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (i != 0)
            {
                lblNumber.Text = steps[--i].ToString();
                lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
            }
        }
        // Загрузка формы
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetControls();
        }
        #endregion

        #region Вспомогательные методы
        // Сброс всех элементов
        private void ResetControls()
        {
            lblResultNum.Text = r.Next(0, 201).ToString();
            lblCommandsCount.Text = "0";
            lblNumber.Text = "0";
            steps = new int[1000];
            i = 0;
            //values.Add(int.Parse(lblNumber.Text));
        }
        // Проверка на полученное значение
        private void StepsCheck()
        {
            // Проиграли
            if (int.Parse(lblNumber.Text) > int.Parse(lblResultNum.Text))
            {
                lblNumber.ForeColor = Color.Red;
                if (MessageBox.Show("Полученное число больше необходимого!\nХотите сыграть еще?", "Перебор!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    lblNumber.ForeColor = Color.Black;
                    ResetControls();
                }
                else
                    Application.Exit();
            }
            // Выиграли
            if (int.Parse(lblNumber.Text) == int.Parse(lblResultNum.Text))
            {
                lblNumber.ForeColor = Color.Green;
                if (MessageBox.Show("Вы выиграли!\nХотите сыграть еще?", "Поздравляем!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    lblNumber.ForeColor = Color.Black;
                    ResetControls();
                }
                else
                    Application.Exit();
            }
        }
        #endregion
    }
}
