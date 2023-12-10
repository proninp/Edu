using System.Linq;

namespace CodeWars._7kyu
{
    /*
     * Sum of differences between products and LCMs
     * 
     * In this kata you need to create a function that takes a 2D array/list of non-negative integer pairs
     * and returns the sum of all the "saving" that you can have getting the LCM of each couple of number compared to their simple product.
     * 
     * For example, if you are given:
     * [[15,18], [4,5], [12,60]]
     * Their product would be:
     * [270, 20, 720]
     * While their respective LCM would be:
     * [90, 20, 60]
     * Thus the result should be:
     * (270-90)+(20-20)+(720-60)==840
     */
    public class SumOfDifferencesBetweenProductsAndLCMs
    {
        public static int SumDifferencesBetweenProductsAndLCMs(int[][] pairs) => pairs.Select(p => p[0] * p[1] - Lcm(p[0], p[1])).Sum();            
        
        static int Gcd(int a, int b) => a == 0 ? b : Gcd(b % a, a);
        
        static int Lcm(int a, int b) => a == 0 || b == 0 ? 0 : (a / Gcd(a, b)) * b;
    }
}
