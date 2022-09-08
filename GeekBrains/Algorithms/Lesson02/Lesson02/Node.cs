using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    public class Node
    {
        public int Value { get; set; }
        public Node NexNode { get; set; }
        public Node PrevNode { get; set; }
    }
}
