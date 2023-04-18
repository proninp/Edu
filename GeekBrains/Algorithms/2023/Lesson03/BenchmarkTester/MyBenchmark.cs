using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Lesson03;

namespace BenchmarkTester
{
    [MemoryDiagnoser]
    [RankColumn]
    public class MyBenchmark
    {
        private const string STRING_TO_CONCAT = "a";
        private const string STRING_TO_PARSE = "555";
        private const string STRING_TO_PARSE_W_ERR = "5aa55aa";
        private string what = "";

        private readonly SpeedTester tester = new SpeedTester();

        [Benchmark]
        public void TestStringConcatination()
        {
            what = "";
            string s = SpeedTester.ConcatString(what, STRING_TO_CONCAT, 100);
        }
        [Benchmark]
        public void TestStringAppend()
        {
            what = "";
            string s = SpeedTester.AppendString(what, STRING_TO_CONCAT, 100);
        }
        [Benchmark]
        public void CatchParse()
        {
            int a = SpeedTester.CatchParse(STRING_TO_PARSE);
        }
        [Benchmark]
        public void TryParse()
        {
            int a = SpeedTester.TryParse(STRING_TO_PARSE);
        }
        [Benchmark]
        public void CatchParseWithError()
        {
            int a = SpeedTester.CatchParse(STRING_TO_PARSE_W_ERR);
        }
        [Benchmark]
        public void TryParseWithError()
        {
            int a = SpeedTester.TryParse(STRING_TO_PARSE_W_ERR);
        }
        [Benchmark]
        public void TestFloatDistanceStruct()
        {
            float f = SpeedTester.FloatDistanceStruct();
        }
        [Benchmark]
        public void TestDoubleDistanceStruct()
        {
            double d = SpeedTester.DoubleDistanceStruct();
        }
        [Benchmark]
        public void TestFloatDistanceClass()
        {
            float f = SpeedTester.FloatDistanceClass();
        }
        [Benchmark]
        public void TestDoubleDistanceClass()
        {
            double d = SpeedTester.DoubleDistanceClass();
        }
    }
}