﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._6kyu
{
    /*
     * A man has a rather old car being worth $2000. He saw a secondhand car being worth $8000.
     * He wants to keep his old car until he can buy the secondhand one.
     * He thinks he can save $1000 each month but the prices of his old car and of the new one decrease of 1.5 percent per month.
     * Furthermore the percent of loss increases by a fixed 0.5 percent at the end of every two months.
     * Can you help him? Our man finds it difficult to make all these calculations.
     * How many months will it take him to save up enough money to buy the car he wants, and how much money will he have left over?
     * Parameters and return of function:
     * parameter (positive int, guaranteed) startPriceOld (Old car price)
     * parameter (positive int, guaranteed) startPriceNew (New car price)
     * parameter (positive int, guaranteed) savingperMonth 
     * parameter (positive float or int, guaranteed) percentLossByMonth
     * nbMonths(2000, 8000, 1000, 1.5) should return [6, 766] or (6, 766)
     * where 6 is the number of months at the end of which he can buy the new car and 766 is the nearest integer to '766.158...' .
     * Note: Selling, buying and saving are normally done at end of month.
     * Calculations are processed at the end of each considered month but if, by chance from the start,
     * the value of the old car is bigger than the value of the new one or equal there is no saving to be made,
     * no need to wait so he can at the beginning of the month buy the new car:
     * nbMonths(12000, 8000, 1000, 1.5) should return [0, 4000]
     * nbMonths(8000, 8000, 1000, 1.5) should return [0, 0]
     * We don't take care of a deposit of savings in a bank:-)
     */
    public class BuyingACar
    {
        public static int[] nbMonths(int startPriceOld, int startPriceNew, int savingperMonth, double percentLossByMonth)
        {
            int months = 0;
            if (startPriceOld >= startPriceNew) return new int[] { months, startPriceOld - startPriceNew };
            double save = 0;
            double oldp = startPriceOld;
            double newp = startPriceNew;
            while(save + oldp < newp)
            {
                if (++months %2 == 0) percentLossByMonth += 0.5;
                oldp *= (100 - percentLossByMonth)/100;
                newp *= (100 - percentLossByMonth)/100;
                save += savingperMonth;
            }
            return new int[] { months, (int)Math.Round(save + oldp - newp) };
        }
    }
}
