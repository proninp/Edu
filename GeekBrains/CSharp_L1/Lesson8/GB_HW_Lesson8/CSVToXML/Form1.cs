using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Diagnostics;

namespace CSVToXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML файл|*.xml|Все файлы|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                try
                {
                    ToXml(saveFileDialog.FileName, Fill("students.csv"));
                    Process.Start("notepad.exe", saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
        /// <summary>
        /// Заполняем лист экземплярами Student из students.csv
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Лист экземпляров Student</returns>
        private List<Student> Fill(string fileName)
        {
            List<Student> list = new List<Student>();
            using (StreamReader sr = new StreamReader(fileName))
                while (!sr.EndOfStream)
                    list.Add(new Student(sr.ReadLine().Split(';')));
            return list;
        }
        /// <summary>
        /// Преобразуем список в .xml файл
        /// </summary>
        /// <param name="fileName">Имя файла для сохранения</param>
        /// <param name="list">Список Student</param>
        private void ToXml(string fileName, List<Student> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                xmlSerializer.Serialize(fs, list);
        }
    }
}
