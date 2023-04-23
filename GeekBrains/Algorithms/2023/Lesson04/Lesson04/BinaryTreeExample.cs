using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson04
{
    internal class BinaryTreeExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Binary Search Tree\n");
            BinaryTree tree = new BinaryTree();
            tree.Insert(75);
            tree.Insert(57);
            tree.Insert(90);
            tree.Insert(32);
            tree.Insert(7);
            tree.Insert(44);
            tree.Insert(60);
            tree.Insert(86);
            tree.Insert(93);
            tree.Insert(99);

            Console.WriteLine("\nIn Order Traversal: Left -> Root -> Right");
            tree.InOrderTraversal();
            Console.WriteLine("\nPre Order Traversal: Root -> Left -> Right");
            tree.PreorderTraversal();
            Console.WriteLine("\nPre Order Traversal: Left -> Right -> Root");

            Console.WriteLine("\nFind 99");
            var nodeR = tree.Find(99);
            Console.WriteLine(nodeR.Data);

            Console.WriteLine("\nFind Recursive 99");
            var nodeRR = tree.FindRecursive(99);
            Console.WriteLine(nodeRR.Data);

            Console.WriteLine("\nDelete a Leaf Node (44)");
            tree.Remove(44);

            Console.WriteLine("\nDelete a Leaf Node (93)");
            tree.Remove(93);

            Console.WriteLine("\nDelete a Leaf Node (75)");
            tree.Remove(75);

            tree.Insert(75);
            tree.Insert(44);
            tree.Insert(93);

            Console.WriteLine("\nSoft Delete a Node with one child (93)");
            tree.SoftDelete(93);

            Console.WriteLine("\nGet Smallest node");
            Console.WriteLine(tree.Smallest());

            Console.WriteLine("\nGet Largest node");
            Console.WriteLine(tree.Largest());

            Console.WriteLine("\nGet the number of leaf nodes");
            Console.WriteLine(tree.NumberOfLeafNodes());

            Console.WriteLine("\nGet the height of the tree");
            Console.WriteLine(tree.Height());
        }
    }
}
