using System;
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
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out int isNumber) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Back);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetControls();
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (int.TryParse(tbGuessNum.Text, out int num))
                    if (num == guessNumber)
                    {
                        lblStatusValue.Text = "Guessed!";
                        if (MessageBox.Show("You guessed it!\nDo you want to play again?", "Congratulate!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            ResetControls();
                        else Application.Exit();
                    }
                    else
                    {
                        lblStatusValue.Text = ((num > guessNumber) ? "Get lower!" : "Get bigger!");
                        tbGuessNum.Text = "";
                        lblStatusValue.Visible = true;
                    }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        private void ShowNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The number:\n" + guessNumber, "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to get out?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
        private void ResetControls()
        {
            lblStatusValue.Visible = false;
            tbGuessNum.Text = "";
            guessNumber = r.Next(1, 101);
        }
    }
}
