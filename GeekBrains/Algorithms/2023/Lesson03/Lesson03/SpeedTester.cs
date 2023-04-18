using System.Text;

namespace Lesson03
{
    public class SpeedTester
    {
        public static PointClass pointClassOne = new PointClass(4, 12);
        public static PointClass pointClassTwo = new PointClass(-2, 4);
        public static PointStruct pointStructOne = new PointStruct(12, -8);
        public static PointStruct pointStructTwo = new PointStruct(2, 9);
        static void Main(string[] args)
        {
            
        }
        public static string ConcatString(string what, string with, int times)
        {
            for (int i = 0; i < times; i++)
            {
                if (what.Length > 0)
                    what += ", ";
                what += with;
            }
            return what;
        }
        public static string AppendString(string what, string with, int times)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(what);
            for (int i = 0; i < times; i++)
            {
                if (builder.Length > 0)
                    builder.Append(with);
            }
            return builder.ToString();
        }
        public static int CatchParse(string str)
        {
            int result;
            try
            {
                result = int.Parse(str);
            }
            catch (Exception e)
            {
                result = 0;
            }
            return result;
        }
        public static int TryParse(string str)
        {
            int result;
            int.TryParse(str, out result);
            return result;
        }
        public static float FloatDistanceStruct()
        {
            return PointStruct.PointDistanceFloat(pointStructOne, pointStructTwo);
        }
        public static double DoubleDistanceStruct()
        {
            return PointStruct.PointDistanceDouble(pointStructOne, pointStructTwo);
        }
        public static float FloatDistanceClass()
        {
            return PointClass.PointDistanceFloat(pointClassOne, pointClassTwo);
        }
        public static double DoubleDistanceClass()
        {
            return PointClass.PointDistanceDouble(pointClassOne, pointClassTwo);
        }
    }
}