using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        List<int> values = new List<int>();
        int[] steps;
        int i;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnCommand1_Click(object sender, EventArgs e)
        {
            steps[i] = int.Parse(lblNumber.Text);
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
            i++;
            StepsCheck();
        }
        private void BtnCommand2_Click(object sender, EventArgs e)
        {
            steps[i] = int.Parse(lblNumber.Text);
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
            i++;
            StepsCheck();
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            steps[i] = int.Parse(lblNumber.Text);
            lblNumber.Text = "0";
            i++;
            lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
        }
        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Shure?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (i != 0)
            {
                lblNumber.Text = steps[--i].ToString();
                lblCommandsCount.Text = (int.Parse(lblCommandsCount.Text) + 1).ToString();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void ResetControls()
        {
            lblResultNum.Text = r.Next(0, 201).ToString();
            lblCommandsCount.Text = "0";
            lblNumber.Text = "0";
            steps = new int[1000];
            i = 0;
        }
        private void StepsCheck()
        {
            if (int.Parse(lblNumber.Text) > int.Parse(lblResultNum.Text))
            {
                lblNumber.ForeColor = Color.Red;
                if (MessageBox.Show("Too much!\nOnce again?", "Too much!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    lblNumber.ForeColor = Color.Black;
                    ResetControls();
                }
                else
                    Application.Exit();
            }
            if (int.Parse(lblNumber.Text) == int.Parse(lblResultNum.Text))
            {
                lblNumber.ForeColor = Color.Green;
                if (MessageBox.Show("You won!\nDo you want to play again?", "!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    lblNumber.ForeColor = Color.Black;
                    ResetControls();
                }
                else
                    Application.Exit();
            }
        }
    }
}
