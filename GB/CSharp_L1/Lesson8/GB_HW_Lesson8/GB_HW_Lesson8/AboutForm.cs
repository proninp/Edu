using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GB_HW_Lesson8
{
    public partial class AboutForm : Form
    {
        
        String companyInfo = "\"Верю - Не верю\", " + DateTime.Now.Year.ToString() + ". Все права защищены";

        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Constants.VERSION;
            lblDev.Text = Constants.DEV;
            lblCompany.Text = Constants.COMPANY;
            lblCompanyInfo.Text = companyInfo;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
