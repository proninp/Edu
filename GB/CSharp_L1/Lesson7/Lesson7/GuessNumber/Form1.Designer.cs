namespace GuessNumber
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
            this.lblGuessDescription = new System.Windows.Forms.Label();
            this.lblEnterNumber = new System.Windows.Forms.Label();
            this.tbGuessNum = new System.Windows.Forms.TextBox();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNumberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGuessDescription
            // 
            this.lblGuessDescription.AutoSize = true;
            this.lblGuessDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblGuessDescription.Location = new System.Drawing.Point(12, 36);
            this.lblGuessDescription.Name = "lblGuessDescription";
            this.lblGuessDescription.Size = new System.Drawing.Size(239, 13);
            this.lblGuessDescription.TabIndex = 0;
            this.lblGuessDescription.Text = "Компьютер загадал число от 1 до 100!";
            // 
            // lblEnterNumber
            // 
            this.lblEnterNumber.AutoSize = true;
            this.lblEnterNumber.Location = new System.Drawing.Point(12, 69);
            this.lblEnterNumber.Name = "lblEnterNumber";
            this.lblEnterNumber.Size = new System.Drawing.Size(84, 13);
            this.lblEnterNumber.TabIndex = 1;
            this.lblEnterNumber.Text = "Введите число:";
            // 
            // tbGuessNum
            // 
            this.tbGuessNum.Location = new System.Drawing.Point(102, 66);
            this.tbGuessNum.MaxLength = 3;
            this.tbGuessNum.Name = "tbGuessNum";
            this.tbGuessNum.Size = new System.Drawing.Size(68, 20);
            this.tbGuessNum.TabIndex = 2;
            this.tbGuessNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.tbGuessNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatusValue.Location = new System.Drawing.Point(12, 95);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(41, 13);
            this.lblStatusValue.TabIndex = 4;
            this.lblStatusValue.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(263, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.showNumberToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menuToolStripMenuItem.Text = "Меню";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newGameToolStripMenuItem.Text = "Новая Игра";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // showNumberToolStripMenuItem
            // 
            this.showNumberToolStripMenuItem.Name = "showNumberToolStripMenuItem";
            this.showNumberToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.showNumberToolStripMenuItem.Text = "Показать число";
            this.showNumberToolStripMenuItem.Click += new System.EventHandler(this.showNumberToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 117);
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.tbGuessNum);
            this.Controls.Add(this.lblEnterNumber);
            this.Controls.Add(this.lblGuessDescription);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Угадай число!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGuessDescription;
        private System.Windows.Forms.Label lblEnterNumber;
        private System.Windows.Forms.TextBox tbGuessNum;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showNumberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

