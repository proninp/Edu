using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05
{
    [Serializable]
    public class ToDo
    {
        private static int count;
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public int Id { get; set; }
        public ToDo()
        {

        }
        public ToDo(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
            Id = ++count;
        }
        public override string ToString() => string.Concat(string.Format($"{Id}. "), ((IsDone) ? "[x] " : ""), Title);
    }
}
