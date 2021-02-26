using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Asteroids
{
    /// <summary>
    /// Класс для отображения счета игрока
    /// </summary>
    class Stat : BaseObject
    {
        Graphics Graphics { get; set; }
        public String StatText { get; set; }
        public string Description { get; set; }
        public int StatValue { get; set; }
        public Stat(Point pos, string text, int value) : base(pos, new Point(0, 0))
        {
            Graphics = Game.Buffer?.Graphics;
            StatValue = value;
            Description = text;
            StatText = $"{Description} {StatValue}";
        }
        /// <summary>
        /// Метод отрисовки счета
        /// </summary>
        public override void Draw()
        {
            StatText = $"{Description} {StatValue}";
            Graphics?.DrawString(StatText, new Font(Settings.MainFont, 10, FontStyle.Bold), Brushes.White, Pos);
        }
        public void WriteRecords()
        {
            string text = "";
            List<string> records = new List<string>();
            if (File.Exists(Settings.RecordsFile))
                text = File.ReadAllText(Settings.RecordsFile);
            if (text.Contains(Environment.NewLine))
                records = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Skip(1).ToList();
            for (int i = 0; i < records.Count; i++)
                if (records[i] == "" || StatValue > Convert.ToInt32(records[i])) {
                    if (records[i] == "") records[i] = StatValue.ToString();
                    else records.Insert(i, StatValue.ToString());
                    StatValue = 0;
                    break;
                }

            text = Settings.RecordsInitString + Environment.NewLine + string.Join(Environment.NewLine, records);
            if (File.Exists(Settings.RecordsFile) && text != "")
                File.WriteAllText(Settings.RecordsFile, text);
        }
    }
}
