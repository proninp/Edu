using System;

namespace CodeWars._7kyu
{
    /*
     * Elapsed Seconds
     * Complete the function so that it returns the number of seconds that have elapsed between the start and end times given.
     */
    public class ElapsedSecondsCW
    {
        public static int ElapsedSeconds(DateTime startDate, DateTime endDate) => (int) (endDate - startDate).TotalSeconds;
    }
}
