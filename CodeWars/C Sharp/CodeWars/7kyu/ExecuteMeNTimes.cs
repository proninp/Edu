using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    class Worker
    {

        public void Execute(Action a, int nTimes)
        {
            Parallel.For(1, nTimes + 1, i => a());
        }
    }
}
