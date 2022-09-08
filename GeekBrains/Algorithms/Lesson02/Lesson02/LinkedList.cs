using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    public class LinkedList : ILinkedList
    {
        private Node startNode = null;
        private static int count;

        /// <summary>
        /// Adding a node to linked list
        /// </summary>
        /// <param name="value"></param>
        public void AddNode(int value)
        {
            if (startNode != null)
            {
                var node = startNode;
                while (node.NexNode != null)
                    node = node.NexNode;
                AddNodeAfter(node, value);
                return;
            }
            startNode = new Node { Value = value };
            count++;
        }

        /// <summary>
        /// Adding a node after specified node
        /// </summary>
        /// <param name="node">The node after which the element should be added</param>
        /// <param name="value">A new node value</param>
        public void AddNodeAfter(Node node, int value)
        {
            if (node is null)
                throw new ArgumentNullException();
            var newNode = new Node
            {
                Value = value,
                NexNode = node.NexNode,
                PrevNode = node
            };;
            node.NexNode = newNode;
            if (newNode.NexNode != null)
                newNode.NexNode.PrevNode = newNode;
            count++;
        }

        /// <summary>
        /// Get a first node with specified value
        /// </summary>
        /// <param name="searchValue">Value to search</param>
        /// <returns>A node with a specified value</returns>
        public Node FindNode(int searchValue) => FindNode(startNode, searchValue);
            
        private Node FindNode(Node node, int searchValue)
        {
            if (node is null)
                return null;
            if (node.Value == searchValue)
                return node;
            return FindNode(node.NexNode, searchValue);
        }
        /// <summary>
        /// Nodes Count in list
        /// </summary>
        /// <returns>Count of nodes in current list</returns>
        public int GetCount() => count;

        /// <summary>
        /// Remove first node with specified index
        /// </summary>
        /// <param name="index">Node index</param>
        public void RemoveNode(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException();
            var node = startNode;
            for (int i = 0; i < index; i++)
                node = node.NexNode;
            RemoveNode(node);
        }

        /// <summary>
        /// Removing specified node
        /// </summary>
        /// <param name="node">Node to remove</param>
        public void RemoveNode(Node node)
        {
            if (node is null)
                throw new ArgumentNullException();
            var prevNode = node.PrevNode;
            prevNode.NexNode = node.NexNode;
            node.NexNode.PrevNode = prevNode;
            node.PrevNode = null;
            node.NexNode = null;
            count--;
        }
        /// <summary>
        /// Prints a linked list with specified header text
        /// </summary>
        /// <param name="header">Header text string</param>
        public void Print(string header)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine(header);

            var node = startNode;
            while(node != null)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append(", ").Append(node.Value);
                else
                    stringBuilder.Append(node.Value);
                node = node.NexNode;
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.WriteLine($"Elements count: {count}\n");
        }
    }
}
