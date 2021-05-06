using System;
using System.Linq;

namespace CodeWars._7kyu
{
    /*
     * Product of Array Items
     * Calculate the product of all elements in an array.
     * In C#, if the array is null, you should throw ArgumentNullException and if the array is empty, you should throw InvalidOperationException.
     * In JavaScript, if the array is null or is empty, the function should return null.
     * In PHP, if the array is NULL or empty, return NULL.
     * In Ruby, if the array is nil or is empty, the function should return nil.
     * In Haskell, if the array is empty then return Nothing, else return Just product.
     * As a challenge, try writing your method in just one line of code. It's possible to have only 36 characters within your method.
     */
    public class ProductOfArrayItems
    {
        public static int Product(int[] values)
        {
            if (values == null) throw new ArgumentNullException();
            else if (values.Length == 0) throw new InvalidOperationException();
            else return values.Aggregate(1, (a, b) => a * b);
        }
    }
}
