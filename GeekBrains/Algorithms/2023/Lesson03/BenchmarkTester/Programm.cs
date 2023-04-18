using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BenchmarkTester
{
    internal class Programm
    {
        static void Main(string[] a)
        {

            BenchmarkRunner.Run<MyBenchmark>();
        }
    }
}
