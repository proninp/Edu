using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._7kyu
{
    /*
     * You Got Change?
     * 
     * Create a function that will take any amount of money and break it down to the smallest number of bills as possible.
     * Only integer amounts will be input, NO floats.
     * This function should output a sequence, where each element in the array represents the amount of a certain bill type.
     * The array will be set up in this manner:
     * 
     * array[0] ---> represents $1 bills
     * array[1] ---> represents $5 bills
     * array[2] ---> represents $10 bills
     * array[3] ---> represents $20 bills
     * array[4] ---> represents $50 bills
     * array[5] ---> represents $100 bills
     * In the case below, we broke up $365 into 1 $5 bill, 1 $10 bill, 1 $50 bill, and 3 $100 bills:
     * 365 =>  [0,1,1,0,1,3]
     * 
     */
    internal class YouGotChange
    {
        public static int[] GiveChange(int amount)
        {
            int[] dividors = { 100, 50, 20, 10, 5, 1 };
            int[] result = new int[dividors.Length];
            for (int i = 0; i < dividors.Length; i++)
            {
                if (amount >= dividors[i])
                {
                    int n = amount;
                    n /= dividors[i];
                    result[dividors.Length - 1 - i] = n;
                    amount -= n * dividors[i];
                }
            }
            return result;
        }
    }
}
