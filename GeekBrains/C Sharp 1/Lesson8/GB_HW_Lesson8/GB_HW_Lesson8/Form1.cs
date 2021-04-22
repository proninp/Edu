using System;
using System.Windows.Forms;
using System.Drawing;

namespace GB_HW_Lesson8
{
    public partial class Form1 : Form
    {
        static Boolean isCorrectPass = false;
        TrueFalse database;
        private int qCount = 0;
        private int ticks = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnabledControls(false);
            VisibleGameControls(false);
        }

        #region Создать БД
        /// <summary>
        /// Создать БД - кнопка меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Constants.FILE_FILTER;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(saveFileDialog.FileName);
                database.Add("Пробный вопрос", true);
                database.Save();
                sbQuestionNum.Minimum = 1;
                sbQuestionNum.Maximum = 1;
                sbQuestionNum.Value = 1;
                ShowQuestionNumber();
                sbQuestionNum_Scroll(sender, null);
                EnabledControls(true);
            }
        }

        /// <summary>
        /// Создать БД - кнопка на панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createToolStripButton_Click(object sender, EventArgs e)
        {
            createToolStripMenuItem_Click(sender, e);
        }
        #endregion

        #region Сохранить БД
        /// <summary>
        /// Сохранить БД - кнопка меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else SendMessage(Constants.DB_DOES_NOT_CREATE, Constants.DESCR_MESSAGE);
        }

        /// <summary>
        /// Сохранить - кнопка на панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        /// <summary>
        /// Сохранить как = кнопка меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (database != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = Constants.FILE_FILTER;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    database.FileName = save.FileName;
                    database.Save();
                }
            }
            else
                SendMessage(Constants.DB_DOES_NOT_CREATE, Constants.DESCR_MESSAGE);
        }
        #endregion

        #region Открыть БД
        /// <summary>
        /// Открыть БД - кнопка меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = Constants.FILE_FILTER;
            if (open.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(open.FileName);
                database.Load();
                sbQuestionNum.Minimum = 1;
                sbQuestionNum.Maximum = database.Count;
                sbQuestionNum.Value = 1;
                ShowQuestionNumber();
                sbQuestionNum_Scroll(sender, null);
                EnabledControls(true);
            }
        }

        /// <summary>
        /// Открыть БД - кнопка панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }
        #endregion

        #region Выход из БД
        /// <summary>
        /// Выход из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти?", "Верю - Не верю", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                this.Close();
        }
        #endregion

        #region Кнопки для работы с элементами базы данных
        /// <summary>
        /// Добавить вопрос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
                MessageBox.Show("Создайте новую базу данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            database.Add((database.Count + 1).ToString(), true);
            SetRadioButtons(true);
            sbQuestionNum.Maximum = database.Count;
            lblTotalCountQuestVal.Text = sbQuestionNum.Maximum.ToString();
            sbQuestionNum.Value = database.Count;
            sbQuestionNum_Scroll(sender, null);
        }

        /// <summary>
        /// Удалить вопрос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (sbQuestionNum.Maximum == 1 && database == null)
            {
                MessageBox.Show("Нет элемента для удаления!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show(String.Format("Вы точно хотите удалить вопрос № {0}?", (sbQuestionNum.Value)), "Внимание!", 
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                database.Remove(sbQuestionNum.Value - 1);
                sbQuestionNum.Maximum--;
                lblTotalCountQuestVal.Text = sbQuestionNum.Maximum.ToString();
                if (sbQuestionNum.Value > 1) sbQuestionNum_Scroll(sender, null);
            }
        }

        /// <summary>
        /// Сохранить вопрос
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            database[sbQuestionNum.Value - 1].Text = rtb.Text;
            database[sbQuestionNum.Value - 1].TrueFalse = rbYes.Checked;
        }
        #endregion

        #region Scroll Bar
        /// <summary>
        /// Событие прокручивания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbQuestionNum_Scroll(object sender, ScrollEventArgs e)
        {
            if (e != null && e.OldValue < e.NewValue)
            {
                rtb.Text = database[sbQuestionNum.Value].Text;
                SetRadioButtons(database[sbQuestionNum.Value].TrueFalse);
                lblCurrQustVal.Text = sbQuestionNum.Value.ToString();
            }
            else
            {
                rtb.Text = database[sbQuestionNum.Value - 1].Text;
                SetRadioButtons(database[sbQuestionNum.Value - 1].TrueFalse);
                lblCurrQustVal.Text = sbQuestionNum.Value.ToString();
            }
        }
        #endregion

        #region Radio Buttons
        /// <summary>
        /// Собтие клик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbYes_Click(object sender, EventArgs e)
        {
            if (database != null) database[sbQuestionNum.Value - 1].TrueFalse = true;
        }

        /// <summary>
        /// Событие клик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbNo_Click(object sender, EventArgs e)
        {
            if (database != null) database[sbQuestionNum.Value - 1].TrueFalse = false;
        }

        /// <summary>
        /// Установка значение для radio buttons
        /// </summary>
        /// <param name="value"></param>
        private void SetRadioButtons(bool value)
        {
            rbYes.Checked = value;
            rbNo.Checked = !value;
        }
        #endregion

        #region Вставка
        private void insertToolStripButton_Click(object sender, EventArgs e)
        {
            rtb.Text += Clipboard.GetText();
        }
        #endregion

        #region Форма справки
        /// <summary>
        /// Вызов справки из меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Вызов справки кнопкой панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }
        #endregion

        #region Переключение вкладок TabPage
        /// <summary>
        /// Событие для вызова формы пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 1) // База данных
                if (database != null && !isCorrectPass)
                {
                    PassForm passForm = new PassForm();
                    passForm.ShowDialog();
                    EnableBaseTabControls(isCorrectPass);
                }
        }
        #endregion

        #region Игра
        /// <summary>
        /// Событие таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (++ticks == Constants.TIMER) NextQuestion();
            pbProgress.Value = ticks;
        }

        /// <summary>
        /// Функция переключения вопроса
        /// </summary>
        /// <param name="i"></param>
        /// <param name="qCount"></param>
        private void ChangeQuestion(int i, int qCount)
        {
            if (i != -1)
            {
                rtbGame.Text = database[i].Text;
                lblQuestGame.Text = Constants.QUESTION_NUM + qCount;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                pbProgress.Value = 1;
                MessageBox.Show(Constants.GO_PART_1 + database.GetCorrectedCount() + Constants.GO_PART_2 + database.Count + ".",
                    Constants.GO_PART_3, MessageBoxButtons.OK);
                VisibleGameControls(false);
                btnStartGame.Visible = true;
            }
        }

        /// <summary>
        /// Начать игру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            database.ClearAnswers();
            btnStartGame.Visible = false;
            VisibleGameControls(true);
            qCount = database.GetNewQuestion();
            ChangeQuestion(qCount, qCount + 1);
        }

        #region Кнопки "Верю" и "Не верю"
        /// <summary>
        /// Выбор ответа - Верю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrue_Click(object sender, EventArgs e)
        {
            database[qCount].IsCorrect = database[qCount].TrueFalse == true;
            NextQuestion();
        }

        /// <summary>
        /// Выбор ответа - Не верю
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFalse_Click(object sender, EventArgs e)
        {
            database[qCount].IsCorrect = database[qCount].TrueFalse == false;
            NextQuestion();
        }
        #endregion
        #endregion

        #region Вспомогательные функции
        /// <summary>
        /// Отображение номера вопроса
        /// </summary>
        private void ShowQuestionNumber()
        {
            lblCurrQustVal.Text = sbQuestionNum.Value.ToString();
            lblTotalCountQuestVal.Text = sbQuestionNum.Maximum.ToString();
            pnlLabels.Visible = true;
        }

        /// <summary>
        /// Управление активностью элементов
        /// </summary>
        /// <param name="enable"></param>
        private void EnabledControls(bool enable)
        {
            saveToolStripButton.Enabled = enable;
            saveAsToolStripMenuItem.Enabled = enable;
            saveAsToolStripMenuItem.Enabled = enable;
            insertToolStripButton.Enabled = enable;
            copyToolStripButton.Enabled = enable;
            cutToolStripButton.Enabled = enable;
            printToolStripButton.Enabled = enable;
            aboutToolStripButton.Enabled = enable;
            btnStartGame.Visible = enable;

            if (tabControl1.SelectedIndex == 1 && !isCorrectPass)
            {
                PassForm passForm = new PassForm();
                passForm.ShowDialog();
            }
            EnableBaseTabControls(isCorrectPass);
        }

        /// <summary>
        /// Управление кнопками работы с элементами БД
        /// </summary>
        /// <param name="enable"></param>
        private void EnableBaseTabControls(Boolean enable)
        {
            btnAdd.Enabled = enable;
            btnDel.Enabled = enable;
            rbYes.Visible = enable;
            rbNo.Visible = enable;
            rtb.Enabled = enable;
            sbQuestionNum.Enabled = enable;
        }

        /// <summary>
        /// Отображение панелей "БД" и "Игра"
        /// </summary>
        /// <param name="visible"></param>
        private void VisibleGameControls(Boolean visible)
        {
            panelGame.Visible = visible;
            pbProgress.Visible = visible;
        }

        // Отправка сообщения
        public static void SendMessage(String message, String head)
        {
            MessageBox.Show(message, head, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        // Установка значения результата ввода пароля
        public static void SetIsCorrectPass(Boolean isCorrect)
        {
            isCorrectPass = isCorrect;
        }

        // Переключение вопроса
        private void NextQuestion()
        {
            database[qCount].IsAnswered = true;
            qCount = database.GetNewQuestion();
            pbProgress.Value = 1;
            ChangeQuestion(qCount, qCount + 1);
            ticks = 0;
        }
        #endregion
    }
}