namespace GB_HW_Lesson8
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblVersionDescr = new System.Windows.Forms.Label();
            this.lblDevDescr = new System.Windows.Forms.Label();
            this.lblCompanyDescr = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDev = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblCompanyInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVersionDescr
            // 
            this.lblVersionDescr.AutoSize = true;
            this.lblVersionDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblVersionDescr.Location = new System.Drawing.Point(12, 23);
            this.lblVersionDescr.Name = "lblVersionDescr";
            this.lblVersionDescr.Size = new System.Drawing.Size(67, 17);
            this.lblVersionDescr.TabIndex = 0;
            this.lblVersionDescr.Text = "Версия:";
            // 
            // lblDevDescr
            // 
            this.lblDevDescr.AutoSize = true;
            this.lblDevDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblDevDescr.Location = new System.Drawing.Point(12, 49);
            this.lblDevDescr.Name = "lblDevDescr";
            this.lblDevDescr.Size = new System.Drawing.Size(110, 17);
            this.lblDevDescr.TabIndex = 1;
            this.lblDevDescr.Text = "Разработчик:";
            // 
            // lblCompanyDescr
            // 
            this.lblCompanyDescr.AutoSize = true;
            this.lblCompanyDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCompanyDescr.Location = new System.Drawing.Point(12, 76);
            this.lblCompanyDescr.Name = "lblCompanyDescr";
            this.lblCompanyDescr.Size = new System.Drawing.Size(87, 17);
            this.lblCompanyDescr.TabIndex = 2;
            this.lblCompanyDescr.Text = "Компания:";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVersion.Location = new System.Drawing.Point(128, 25);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(51, 16);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "label1";
            // 
            // lblDev
            // 
            this.lblDev.AutoSize = true;
            this.lblDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblDev.Location = new System.Drawing.Point(128, 49);
            this.lblDev.Name = "lblDev";
            this.lblDev.Size = new System.Drawing.Size(52, 17);
            this.lblDev.TabIndex = 4;
            this.lblDev.Text = "label2";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblCompany.Location = new System.Drawing.Point(127, 76);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(52, 17);
            this.lblCompany.TabIndex = 5;
            this.lblCompany.Text = "label3";
            // 
            // lblCompanyInfo
            // 
            this.lblCompanyInfo.AutoSize = true;
            this.lblCompanyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCompanyInfo.Location = new System.Drawing.Point(12, 103);
            this.lblCompanyInfo.Name = "lblCompanyInfo";
            this.lblCompanyInfo.Size = new System.Drawing.Size(41, 15);
            this.lblCompanyInfo.TabIndex = 7;
            this.lblCompanyInfo.Text = "label1";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 130);
            this.Controls.Add(this.lblCompanyInfo);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblDev);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCompanyDescr);
            this.Controls.Add(this.lblDevDescr);
            this.Controls.Add(this.lblVersionDescr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.Text = "О программе";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersionDescr;
        private System.Windows.Forms.Label lblDevDescr;
        private System.Windows.Forms.Label lblCompanyDescr;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblDev;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblCompanyInfo;
    }
}