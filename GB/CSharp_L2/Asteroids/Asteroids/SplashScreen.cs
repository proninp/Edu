using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    class SplashScreen
    {
        static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static void Greeting(Form form)
        {
            if (userName.Contains("\\")) userName = userName.Substring(userName.IndexOf("\\") + 1);
            Button grBtn = new Button()
            {
                Width = 200,
                Height = 100,
                Text = "Стартуем!",
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Italic),
                ForeColor = Color.DarkGoldenrod
            };

            grBtn.Location = new Point(form.Width / 2 - grBtn.Width / 2, form.Height / 2 - grBtn.Height / 2);
            form.Controls.Add(grBtn);
            grBtn.Click += (object sender, EventArgs e) =>
            {
                grBtn.Visible = false;
                MessageBox.Show($"Привет, {userName}!", "Приветствие", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            };
        }
        
    }
}
