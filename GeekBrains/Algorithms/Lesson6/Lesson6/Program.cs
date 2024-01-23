using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();

            Task2();

            Console.ReadLine();
        }

        #region Task1
        /* 
         * 1. My Simple HashFunction
         */
         static void Task1()
        {
            Console.WriteLine("******************** Task1 ********************");
            Console.WriteLine("Hash of \"Hello Algorithms\" is:");
            Console.WriteLine(MyHash("Hello Algorithms"));
            Console.WriteLine();
        }
        static string MyHash(string data)
        {
            GCHandle gCHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            string s = gCHandle.AddrOfPinnedObject().ToString()
                + gCHandle.AddrOfPinnedObject().ToString("X"); // getting sended parametr addres as a number + it's hex representation
            gCHandle.Free();
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                int j = (i > 0) ? (int) Char.GetNumericValue(s[i - 1]) : data.Length; // getting previous value for pseudo-random value
                j ^= i >> data.Length & 1;
                int val = (j * s[i]) % 125;         // the greatest character would be '}'
                val = (val < 48 ? val + 48 : val) ; // the smalest character would be "0"
                result.Append((char)val);           // appending into result
            }
            return result.ToString();
        }
        #endregion

        #region Task2
        /*
         * 2. Binary Tree realization
         * a) Traversing the binary tree         * b) Searching in sorted binary tree
         */
        static void Task2()
        {
            Console.WriteLine("******************** Task2 ********************");
            int[] tree = new int[16] {0, 10, 8, 15, 6, 9, 12, 16, 2, 4, 7, -1, 11, 14, 17, 20 };
            int[] sTree = new int[] { 0, 30, 20, 46, 10, 25, 42, 52, 8, 16, 21, 26, 38, 44, 49, 56,
                7, 9, 15, 19, 18, 23, 24, 28, 35, 40, 43, 45, 48, 51, 55, 58};
            PrintTree(tree, 1);
            Console.WriteLine();
            Console.WriteLine("\nNode - Left - Right -> ");
            NLR(tree, 1);
            Console.WriteLine();
            Console.WriteLine("\nLeft - Node - Right -> ");
            LNR(tree, 1);
            Console.WriteLine();
            Console.WriteLine("\nLeft - Right - Node -> ");
            LRN(tree, 1);
            Console.WriteLine();
            Console.WriteLine("\nRight - Left - Node -> ");
            RLN(tree, 1);
            Console.WriteLine();
            Console.WriteLine("\nBinary Tree search. Enter searching number:");
            BinaryTreeSearch(sTree, 1, int.Parse(Console.ReadLine()));
        }

        /// <summary>
        /// Print Tree
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        static void PrintTree(int[] a, int i)
        {
            Console.Write(a[i]);
            if (i * 2 < a.Length && (a[i * 2] != -1 || a[i * 2 + 1] != -1))
            {
                Console.Write("(");
                if (a[i * 2] != -1) PrintTree(a, i * 2);
                else Console.Write("*");
                Console.Write(",");
                if (a[i * 2 + 1] != -1) PrintTree(a, i * 2 + 1);
                else Console.Write("*");
                Console.Write(")");
            }
        }

        /// <summary>
        /// Node - Left - Right
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        static void NLR(int[] a, int i)
        {
            if (i < a.Length)
            {
                Console.Write(a[i] + " ");
                NLR(a, i * 2);
                NLR(a, i * 2 + 1);
            }
        }

        /// <summary>
        /// Left - Node - Right
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        static void LNR(int[] a, int i)
        {
            if (i < a.Length)
            {
                LNR(a, i * 2);
                Console.Write((a[i] != -1) ? a[i] + " " : "* ");
                LNR(a, i * 2 + 1);
            }
        }

        /// <summary>
        /// Left - Right - Node
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        static void LRN(int[] a, int i)
        {
            if (i < a.Length)
            {
                LNR(a, i * 2);
                LNR(a, i * 2 + 1);
                Console.Write(a[i] + " ");
            }
        }

        /// <summary>
        /// Right - Left - Node
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        static void RLN(int[] a, int i)
        {
            if (i < a.Length)
            {
                RLN(a, i * 2 + 1);
                LNR(a, i * 2);
                Console.Write(a[i] + " ");
            }
        }

        /// <summary>
        /// Binary Tree Search
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        /// <param name="searched"></param>
        static void BinaryTreeSearch(int[] a, int i, int searched)
        {
            if (i > a.Length - 1) { Console.WriteLine("404 - Not Found!"); return; }
            if (a[i] == searched) { Console.WriteLine("Element {0} at position: {1}", searched, i); return; }
            if (a[i] > searched) BinaryTreeSearch(a, i * 2, searched);
            else BinaryTreeSearch(a, i * 2 + 1, searched);
        }
        #endregion
    }
}
