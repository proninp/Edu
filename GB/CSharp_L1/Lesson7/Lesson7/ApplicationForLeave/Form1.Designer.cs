namespace ApplicationForLeave
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCompany = new System.Windows.Forms.Label();
            this.tbOrgName = new System.Windows.Forms.TextBox();
            this.lblDirectorFIO = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.tbDirName = new System.Windows.Forms.TextBox();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.btnGen = new System.Windows.Forms.Button();
            this.dtPFrom = new System.Windows.Forms.DateTimePicker();
            this.dtPTo = new System.Windows.Forms.DateTimePicker();
            this.btnPositions = new System.Windows.Forms.Button();
            this.cMSPositions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.programmerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hhrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekonomistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPositions = new System.Windows.Forms.Label();
            this.cMSPositions.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(16, 28);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(151, 13);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Наименование организации";
            // 
            // tbOrgName
            // 
            this.tbOrgName.Location = new System.Drawing.Point(172, 25);
            this.tbOrgName.Name = "tbOrgName";
            this.tbOrgName.Size = new System.Drawing.Size(136, 20);
            this.tbOrgName.TabIndex = 1;
            // 
            // lblDirectorFIO
            // 
            this.lblDirectorFIO.AutoSize = true;
            this.lblDirectorFIO.Location = new System.Drawing.Point(18, 52);
            this.lblDirectorFIO.Name = "lblDirectorFIO";
            this.lblDirectorFIO.Size = new System.Drawing.Size(142, 13);
            this.lblDirectorFIO.TabIndex = 2;
            this.lblDirectorFIO.Text = "ФИО Руководителя (кому)";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(18, 106);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(112, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "От заявителя (ФИО)";
            // 
            // tbDirName
            // 
            this.tbDirName.Location = new System.Drawing.Point(172, 49);
            this.tbDirName.Name = "tbDirName";
            this.tbDirName.Size = new System.Drawing.Size(136, 20);
            this.tbDirName.TabIndex = 4;
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(172, 103);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.Size = new System.Drawing.Size(136, 20);
            this.tbFIO.TabIndex = 5;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(18, 132);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(49, 13);
            this.lblDateFrom.TabIndex = 6;
            this.lblDateFrom.Text = "Дата От";
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(18, 158);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 7;
            this.lblDateTo.Text = "Дата До";
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(233, 191);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 23);
            this.btnGen.TabIndex = 10;
            this.btnGen.Text = "Заявление";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // dtPFrom
            // 
            this.dtPFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPFrom.Location = new System.Drawing.Point(172, 132);
            this.dtPFrom.Name = "dtPFrom";
            this.dtPFrom.Size = new System.Drawing.Size(136, 20);
            this.dtPFrom.TabIndex = 12;
            // 
            // dtPTo
            // 
            this.dtPTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPTo.Location = new System.Drawing.Point(172, 158);
            this.dtPTo.Name = "dtPTo";
            this.dtPTo.Size = new System.Drawing.Size(136, 20);
            this.dtPTo.TabIndex = 13;
            // 
            // btnPositions
            // 
            this.btnPositions.ContextMenuStrip = this.cMSPositions;
            this.btnPositions.Location = new System.Drawing.Point(172, 75);
            this.btnPositions.Name = "btnPositions";
            this.btnPositions.Size = new System.Drawing.Size(136, 23);
            this.btnPositions.TabIndex = 14;
            this.btnPositions.UseVisualStyleBackColor = true;
            this.btnPositions.Click += new System.EventHandler(this.btnPositions_Click);
            // 
            // cMSPositions
            // 
            this.cMSPositions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programmerToolStripMenuItem,
            this.buhToolStripMenuItem,
            this.hhrToolStripMenuItem,
            this.ekonomistToolStripMenuItem});
            this.cMSPositions.Name = "cMSPositions";
            this.cMSPositions.Size = new System.Drawing.Size(152, 92);
            // 
            // programmerToolStripMenuItem
            // 
            this.programmerToolStripMenuItem.Name = "programmerToolStripMenuItem";
            this.programmerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.programmerToolStripMenuItem.Text = "Программист";
            this.programmerToolStripMenuItem.Click += new System.EventHandler(this.programmerToolStripMenuItem_Click);
            // 
            // buhToolStripMenuItem
            // 
            this.buhToolStripMenuItem.Name = "buhToolStripMenuItem";
            this.buhToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.buhToolStripMenuItem.Text = "Бухгалтер";
            this.buhToolStripMenuItem.Click += new System.EventHandler(this.buhToolStripMenuItem_Click);
            // 
            // hhrToolStripMenuItem
            // 
            this.hhrToolStripMenuItem.Name = "hhrToolStripMenuItem";
            this.hhrToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.hhrToolStripMenuItem.Text = "Кадровик";
            this.hhrToolStripMenuItem.Click += new System.EventHandler(this.hhrToolStripMenuItem_Click);
            // 
            // ekonomistToolStripMenuItem
            // 
            this.ekonomistToolStripMenuItem.Name = "ekonomistToolStripMenuItem";
            this.ekonomistToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.ekonomistToolStripMenuItem.Text = "Экономист";
            this.ekonomistToolStripMenuItem.Click += new System.EventHandler(this.ekonomistToolStripMenuItem_Click);
            // 
            // lblPositions
            // 
            this.lblPositions.AutoSize = true;
            this.lblPositions.Location = new System.Drawing.Point(18, 80);
            this.lblPositions.Name = "lblPositions";
            this.lblPositions.Size = new System.Drawing.Size(145, 13);
            this.lblPositions.TabIndex = 15;
            this.lblPositions.Text = "От сотрудника (должность)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 222);
            this.Controls.Add(this.lblPositions);
            this.Controls.Add(this.btnPositions);
            this.Controls.Add(this.dtPTo);
            this.Controls.Add(this.dtPFrom);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.lblDateTo);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.tbDirName);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.lblDirectorFIO);
            this.Controls.Add(this.tbOrgName);
            this.Controls.Add(this.lblCompany);
            this.Name = "Form1";
            this.Text = "Заявление Отпуск";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cMSPositions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox tbOrgName;
        private System.Windows.Forms.Label lblDirectorFIO;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox tbDirName;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.DateTimePicker dtPFrom;
        private System.Windows.Forms.DateTimePicker dtPTo;
        private System.Windows.Forms.Button btnPositions;
        private System.Windows.Forms.Label lblPositions;
        private System.Windows.Forms.ContextMenuStrip cMSPositions;
        private System.Windows.Forms.ToolStripMenuItem programmerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hhrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekonomistToolStripMenuItem;
    }
}

