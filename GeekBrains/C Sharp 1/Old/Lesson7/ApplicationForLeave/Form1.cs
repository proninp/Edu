using System;
using System.IO;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace ApplicationForLeave
{
    public partial class Form1 : Form
    {
        readonly string fileName = @"..\..\Data\template.docx";
        readonly string newFileName = @"..\..\Data\NewDoc.docx";

        public Form1()
        {
            InitializeComponent();
        }

        #region События формы
        private void btnPositions_Click(object sender, EventArgs e)
        {
            cMSPositions.Show(btnPositions, new System.Drawing.Point(0, btnPositions.Height));
        }
        private void programmerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPositions.Text = "Программиста";
        }
        private void buhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPositions.Text = "Бухгалтера";
        }
        private void hhrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPositions.Text = "Кадровика";
        }
        private void ekonomistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPositions.Text = "Экономиста";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetControls();
        }

        #region Работа с MS Word
        private void btnGen_Click(object sender, EventArgs e)
        {
            if (dtPFrom.Value >= dtPTo.Value)
            {
                MessageBox.Show("Дата окончания должна быть больше даты начала!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                Word.Application wordApp = new Word.Application();
                wordApp.Visible = false; // Чтобы не видеть формирование
                try
                {
                    Word.Document doc = wordApp.Documents.Open(Path.GetFullPath(fileName));
                    // Заменяем параметры значениями
                    ReplaceWords("<organizationName>", tbOrgName.Text, doc); // Наименование организации
                    ReplaceWords("<dirName>", tbDirName.Text, doc); // Кому ФИО
                    ReplaceWords("<employeePosition>", btnPositions.Text, doc); // От кого Должность
                    ReplaceWords("<employeeName>", tbFIO.Text, doc); // От кого ФИО
                    ReplaceWords("<dateFrom>", dtPFrom.Value.ToLongDateString(), doc); // До даты
                    ReplaceWords("<days>", (dtPTo.Value - dtPFrom.Value).Days.ToString(), doc); // Кол-во дней
                    ReplaceWords("<today>", DateTime.Now.ToLongDateString(), doc); // Подписываем сегодняшней датой

                    doc.SaveAs2(Path.GetFullPath(newFileName)); // Сохраняем новый документ
                    wordApp.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Ошибка!");
                    wordApp.Quit(); // Освобождаем процесс
                }
            }
        }
        /// <summary>
        /// метод поиска по документу и замены
        /// </summary>
        /// <param name="stub">Заменяемый фрагмент</param>
        /// <param name="text">Текст, который заменяем</param>
        /// <param name="document">Документ</param>
        private void ReplaceWords(string stub, string text, Word.Document document)
        {
            var range = document.Content; // Содержимое документа
            range.Find.ClearFormatting(); // очищаем все предыдущие поиски
            range.Find.Execute(FindText: stub, ReplaceWith: text); // Используем именованые параметры
        }
        #endregion

        #endregion

        /// <summary>
        /// Сброс всех элеменов управления в изначаольное состояние
        /// </summary>
        private void ResetControls()
        {
            btnPositions.Text = "";
            tbOrgName.Text = "";
            tbDirName.Text = "";
            tbFIO.Text = "";
            dtPFrom.Value = DateTime.Now;
            dtPTo.Value = DateTime.Now.AddDays(14);

        }
    }
}
