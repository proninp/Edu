using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01
{
    public class TestCase
    {
        public int X { get; set; }
        public int ExpectedInt { get; set; }
        public bool ExpectedBool { get; set; }
        public Exception ExpectedException { get; set; }
    }
}
