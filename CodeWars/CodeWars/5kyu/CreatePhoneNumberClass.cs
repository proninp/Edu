using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars._5kyu
{
    class CreatePhoneNumberClass
    {
        /*
         *Write a function that accepts an array of 10 integers (between 0 and 9), that returns a string of those numbers in the form of a phone number.
         * Example:
         * Kata.CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) // => returns "(123) 456-7890"
         * The returned format must be correct in order to complete this challenge. 
         * Don't forget the space after the closing parentheses!
         */
        public static string CreatePhoneNumber(int[] numbers)
        {
            return string.Join("", numbers).Insert(0, "(").Insert(4, ") ").Insert(9, "-");
            //return long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");

        }
    }
}
