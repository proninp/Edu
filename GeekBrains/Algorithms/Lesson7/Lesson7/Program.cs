using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    /*
     * Dev. by Pronin P.S.
     */
    class Program
    {
        /// <summary>
        /// Matrix (graph)
        /// </summary>
        static int[,] graph = new int[,] { { int.MinValue, 5, 8, int.MinValue, int.MinValue, int.MinValue, int.MinValue },
                { 5, int.MinValue, int.MinValue, 12, int.MinValue, 9, int.MinValue },
                { 8, int.MinValue, int.MinValue, int.MinValue, 8, 4, 2 },
                { int.MinValue, 12, int.MinValue, int.MinValue, 3, 6, int.MinValue },
                { int.MinValue, int.MinValue, 8, 3, int.MinValue, int.MinValue, 7 },
                { int.MinValue, 9, 4, 6, int.MinValue, int.MinValue, int.MinValue },
                { int.MinValue, int.MinValue, 2, int.MinValue, 7, int.MinValue, int.MinValue } };

        static void Main(string[] args)
        {
            Task1();

            Task2_3();

            StartDijkstra();

            Console.ReadLine();
        }

        #region Task1
        static void Task1()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Task 1");
            Console.ForegroundColor = ConsoleColor.White;
            if (File.Exists("sample.txt"))
            {
                string txt = File.ReadAllText("sample.txt");
                string[] stringSeparators = new string[] { "\r\n" };
                string[] s = txt.Split(stringSeparators, StringSplitOptions.None);
                int[,] a = new int[int.Parse(s[0]), int.Parse(s[0])]; // get value of first element
                // Fill array
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    string[] ss = s[i+1].Split(' ');
                    for (int j = 0; j < a.GetLength(1); j++)
                        a[i, j] = int.Parse(ss[j]);
                }
                // Print array
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                        Console.Write(a[i, j] + " ");
                    Console.WriteLine();
                }
            }
            else Console.WriteLine("File does't exist!");
        }
        #endregion

        #region Task2/3
        static void Task2_3()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nTask 2 & Task3");
            Console.ForegroundColor = ConsoleColor.White;
            int[] b = new int[graph.GetLength(0)]; // 0 - not found, 1 - checked
            Stack<int> s = new Stack<int>();
            s.Push(0);
            Console.WriteLine("Depth-First Search:");
            DFS(graph, b, s);

            b = new int[7];
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            Console.WriteLine("\n\nBreadth-First Search:");
            BFS(graph, b, q);

        }

        /// <summary>
        ///  Depth-First Search
        /// </summary>
        /// <param name="a">Incidence matrix</param>
        /// <param name="b">Status</param>
        /// <param name="s">Stack</param>
        static void DFS(int[,] a, int[] b, Stack<int> s)
        {
            if (s.Count == 0) return;
            int i = s.Pop();
            Console.Write(i + "\t");
            for (int j = 0; j < a.GetLength(0); j++)
                if (a[i, j] != int.MinValue)
                    if (b[j] < 1) { s.Push(j); b[j]++; }
            b[i]++;
            DFS(a, b, s);
        }

        /// <summary>
        ///  Breadth-First Search
        /// </summary>
        /// <param name="a">Incidence matrix</param>
        /// <param name="b">Status</param>
        /// <param name="q">Queue</param>
        static void BFS(int[,] a, int[] b, Queue<int> q)
        {
            if (q.Count == 0) return;
            int i = q.Dequeue();
            Console.Write(i + "\t");
            for (int j = 0; j < a.GetLength(0); j++)
                if (a[i, j] != int.MinValue)
                    if (b[j] < 1) { q.Enqueue(j); b[j]++; }
            b[i]++;
            BFS(a, b, q);
        }
        #endregion

        #region Dijkstra
        static void StartDijkstra()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nDijkstra's algorithm implementation");
            Console.ForegroundColor = ConsoleColor.White;
            int[] steps = new int[graph.GetLength(0)];  // steps for each node
            int[] status = new int[steps.Length];       // status of the node
            for (int i = 0; i < steps.Length; i++)      // fill steps array by max of int
                steps[i] = int.MaxValue;
            Queue<int> q = new Queue<int>();
            q.Enqueue(0);
            steps[0] = 0;                               // for step into the first node we need zero steps
            int totalSteps = 0;

            Dijkstra(status, steps, q, totalSteps);

            Console.WriteLine("Path length for each node: ");
            for (int i = 0; i < steps.Length; i++) Console.Write(steps[i] + " ");

            Console.WriteLine("\nNodes with shortest path:");
            ShortestPath(steps, steps.Length - 1);      // by default we would searsh path from first to last node
        }

        /// <summary>
        /// Dijkstra's algorithm implementation
        /// </summary>
        /// <param name="a">matrix</param>
        /// <param name="status">status of each node</param>
        /// <param name="steps">steps count gor each node</param>
        /// <param name="q">queue</param>
        /// <param name="totalSteps"></param>
        static void Dijkstra(int[] status, int[] steps, Queue<int> q, int totalSteps)
        {
            if (q.Count == 0) { Console.WriteLine("Total steps: " + totalSteps + "\n"); return; }
            int i = q.Dequeue();
            for (int j = 0; j < graph.GetLength(0); j++)
            {
                totalSteps++;
                if (graph[i, j] != int.MinValue)
                {
                    if (status[j] < 1) q.Enqueue(j);
                    if (steps[j] > graph[i, j] + steps[i]) steps[j] = graph[i, j] + steps[i];
                }
            }
            status[i]++;
            Dijkstra(status, steps, q, totalSteps);
        }

        /// <summary>
        /// Finding shortest path
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="lastNode"></param>
        static void ShortestPath(int[] steps, int lastNode)
        {
            Console.Write(lastNode + ((lastNode != 0) ? " -> " : ""));
            if (lastNode == 0) return;
            for (int i = 0; i < graph.GetLength(0); i++)
                if (graph[lastNode, i] != int.MinValue)
                    if (steps[i] == steps[lastNode] - graph[lastNode, i]) ShortestPath(steps, i);
        }
        #endregion
    }
}
