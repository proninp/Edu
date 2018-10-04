using System;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    class SplashScreen
    {
        public static void Greeting(Form form)
        {
            Button grBtn = new Button()
            {
                Width = 200,
                Height = 100,
                Text = Settings.GreetingsBtnText,
                Font = new Font(Settings.GreetingsBtnFont, 18F, FontStyle.Italic),
                ForeColor = Color.DarkGoldenrod
            };

            grBtn.Location = new Point(form.Width / 2 - grBtn.Width / 2, form.Height / 2 - grBtn.Height / 2);
            form.Controls.Add(grBtn);
            grBtn.Click += (object sender, EventArgs e) =>
            {
                grBtn.Visible = false;
                MessageBox.Show($"Привет, {Settings.UserName}!", "Приветствие", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            };
        }
        
    }
}
