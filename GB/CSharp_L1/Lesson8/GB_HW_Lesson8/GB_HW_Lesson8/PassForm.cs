using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace GB_HW_Lesson8
{
    public partial class PassForm : Form
    {
        static bool clicked = true;
        public PassForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработка события нажатия клавиши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (clicked) // Удалить введёное пояснение ввода пароля
            {
                tbPass.Text = "";
                clicked = false;
                tbPass.ForeColor = Color.Black;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (tbPass.Text == Constants.PASSWORD)
                {
                    Form1.SetIsCorrectPass(true);
                    Close();
                } else
                {
                    Form1.SetIsCorrectPass(false);
                    Form1.SendMessage(Constants.INCORRECT_PASSWORD, Constants.DESCR_ERR);
                    tbPass.Text = "";
                }
            }
        }

        /// <summary>
        /// При загрузке формы показываеи пояснение в поле ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PassForm_Load(object sender, EventArgs e)
        {
            tbPass.Text = "Введите пароль (123)";
            tbPass.ForeColor = Color.Gray;
            clicked = true;
        }

        /// <summary>
        /// Для удаления пояснения ввода пароля при нажатии мышкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPass_MouseClick(object sender, MouseEventArgs e)
        {
            if (clicked)
            {
                tbPass.Text = "";
                clicked = !clicked;
            }
        }
    }
}
