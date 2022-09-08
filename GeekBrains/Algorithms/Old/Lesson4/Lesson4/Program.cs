using System;

namespace Lesson4
{
    /*
     * Dev. by Pronin P.S.
     */
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();

            //Task2();

            Task3();

            Console.ReadLine();
        }

        #region Task1
        static void Task1()
        {
            Console.WriteLine("1. Routes with obstacles count\n");
            int[,] a = new int[3,3] { {1, 1, 1 }, { 0, 1, 0 } , {0, 1, 0 } };
            for (int i = 1; i < a.GetLength(0); i++)
                for (int j = 1; j < a.GetLength(1); j++)
                    a[i, j] = (a[i, j] == 0) ? 0 : a[i - 1, j] + a[i, j - 1];


            Console.WriteLine("Routes count: " + a[a.GetLength(0) - 1, a.GetLength(1) - 1]);
        }
        #endregion

        #region Task2
        static void Task2()
        {
            Console.WriteLine("\n2. Matrix solution for searching the longest common subsequence\n");
            Console.WriteLine("Enter first sequence:");
            string s1 = Console.ReadLine();
            Console.WriteLine("Enter second sequence:");
            string s2 = Console.ReadLine();
            Console.WriteLine("LCS is: {0}\nLCS length is: {1}", Lcs(s1, s2), Lcs(s1, s2).Length);
        }

        /// <summary>
        /// Matrix solution for searching the longest common subsequence
        /// </summary>
        /// <param name="s1">First sequence</param>
        /// <param name="s2">Second sequence</param>
        /// <returns></returns>
        static string Lcs(string s1, string s2)
        {
            if (s1.Length == 0 || s2.Length == 0) return string.Empty;
            int[,] a = new int[s1.Length, s2.Length];
            string lcs = string.Empty;
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = lcs.Length; j < a.GetLength(1); j++)
                    if (s1[i] == s2[j]) { lcs += s1[i]; break; }
            return lcs;
        }
        #endregion

        #region Task3
        static void Task3()
        {
            Console.WriteLine("\nKnight's tour task solution\n");
            Console.WriteLine("Enter board's rows count:");
            int rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter board's columns count:");
            int cols = int.Parse(Console.ReadLine());
            long stpsCnt = 0;                   // total steps count
            int[,] board = new int[rows, cols];
            FillArrWithZ(board);               // Fill array with zeros
            int[,] rules = new int[8, 2] { { 1, 2 }, { 2, 1 }, { 1, -2 }, { -1, 2 }, { -1, -2 }, { 2, -1 }, { -2, 1 }, { -2, -1 } }; // Horse's move rules
            if (HorseStart(board, rules, 1, ref stpsCnt)) PrintArr(board);
            else Console.WriteLine("Can't complete task with chessboard size {0}x{1}... ", rows, cols);
            Console.WriteLine("\nApproximate number of steps: {0}", stpsCnt);
        }

        /// <summary>
        /// Set start position
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rules">shows how horse can move</param>
        /// <param name="n">cell index (starts with 1)</param>
        /// <param name="stpsCnt">Total steps count</param>
        /// <returns></returns>
        static bool HorseStart(int[,] board, int[,] rules, int n, ref long stpsCnt)
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] == 0)
                    {
                        stpsCnt++;
                        board[i, j] = n;
                        if (HorseMove(board, rules, n + 1, i, j, ref stpsCnt)) return true;
                        board[i, j] = 0;
                    }
            return false;
        }

        /// <summary>
        /// Chess horse move task solution
        /// </summary>
        /// <param name="board">Chess board array</param>
        /// <param name="rules">Horse move rules</param>
        /// <param name="n">number of step</param>
        /// <param name="row">chess board row</param>
        /// <param name="col">chess board column</param>
        /// <returns></returns>
        static bool HorseMove(int[,] board, int[,] rules, int n, int row, int col, ref long stpsCnt)
        {
            if (n == board.Length + 1) return true;
            for (int i = 0; i < rules.GetLength(0); i++) // Check moves by rules
            {
                stpsCnt++;
                int nR = row + rules[i, 0];
                int nC = col + rules[i, 1];
                if (nR >= 0 && nR < board.GetLength(0) && nC >= 0 && nC < board.GetLength(1) && board[nR, nC] == 0)
                {
                    board[nR, nC] = n;
                    if (HorseMove(board, rules, n + 1, nR, nC, ref stpsCnt)) return true;
                    board[nR, nC] = 0;
                }
            }
            return false;
        }

        /// <summary>
        /// Fill board with zeros
        /// </summary>
        /// <param name="a"></param>
        static void FillArrWithZ(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    a[i, j] = 0;
        }

        /// <summary>
        /// Pront board
        /// </summary>
        /// <param name="a"></param>
        static void PrintArr(int[,] a)
        {
            Console.WindowWidth = 150;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\t");
            for (int i = 0; i < a.GetLength(1); i++)
                Console.Write("\t{0}\t", i + 1);
            Console.WriteLine("\n");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("{0}\t", i+1);
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 == 0) Console.ForegroundColor = ConsoleColor.White;
                    else Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\t{0}\t", a[i, j]);
                }
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        #endregion
    }
}