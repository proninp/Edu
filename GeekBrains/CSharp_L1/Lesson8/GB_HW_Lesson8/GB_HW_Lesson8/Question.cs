using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB_HW_Lesson8
{
    [Serializable]
    public class Question
    {
        string text;
        bool trueFalse;
        bool answered;
        bool isCorrect;

        public string Text { get => text; set => text = value; }
        public bool TrueFalse { get => trueFalse; set => trueFalse = value; }
        public bool IsAnswered { get => answered; set => answered = value; }
        public bool IsCorrect { get => isCorrect; set => isCorrect = value; }

        public Question() { }
        public Question(String text, Boolean trueFalse)
        {
            Text = text;
            TrueFalse = trueFalse;
            IsAnswered = false;
            IsCorrect = false;
        }
    }
}
