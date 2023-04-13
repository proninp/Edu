using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    internal class Node : ILinkedList
    {
        private static Node? StartNode { get; set; }
        private static Node? EndNode { get; set; }
        public static int Count { get; private set; }

        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
        
        public Node(int value)
        {
            Value = value;
        }

        // добавляет новый элемент списка
        public void AddNode(int value)
        {
            Node newNode = new Node(value);
            if (StartNode == null)
            {
                StartNode = newNode;
                EndNode = newNode;
            } else
            {
                var node = EndNode;
                node.NextNode = newNode;
                newNode.PrevNode = node;
                newNode.NextNode = null;
                EndNode = newNode;
            }
            Count++;
        }
        // добавляетновый элемент списка после определённого элемента
        public void AddNodeAfter(Node node, int value)
        {
            var nextNode = node.NextNode;
            if (nextNode != null)
            {
                Node newNode = new Node(value);
                newNode.PrevNode = node;
                newNode.NextNode = nextNode;
                node.NextNode = newNode;
                nextNode.PrevNode = newNode;
                Count++;
            }
            else
                AddNode(value);
        }
        
        // ищет элемент по его значению
        public Node FindNode(int searchValue)
        {
            Node node = StartNode;
            for (int i = 0; i < Count; i++)
            {
                if (node == null)
                    return null;
                if (node.Value == searchValue)
                    return node;
                node = node.NextNode;
            }
            return null;
        }

        public int GetCount() => Count;
        
        // удаляет элемент по порядковому номеру
        public void RemoveNode(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException("index");
            if (index == 0)
            {
                var newStartNode = StartNode.NextNode;
                newStartNode.PrevNode = null;
                StartNode = newStartNode;
            } else
            {
                if (index == Count - 1)
                {
                    var prevNode = EndNode.PrevNode;
                    prevNode.NextNode = null;
                    EndNode = prevNode;
                }
                else
                {
                    int i = 1;
                    var currentNode = StartNode.NextNode;
                    while (i != index)
                    {
                        currentNode = currentNode.NextNode;
                    }
                    currentNode.NextNode.PrevNode = currentNode.PrevNode;
                    currentNode.PrevNode.NextNode = currentNode.NextNode;
                    currentNode.NextNode = null;
                    currentNode.PrevNode = null;
                }
            }
            Count--;

        }

        public void RemoveNode(Node node)
        {
            if (node == null || Count == 0)
                return;
            Node current = StartNode;
            for (int i = 0; i < Count; i++)
            {
                if (node.Value == current.Value)
                    RemoveNode(i);
                current = current.NextNode;
            }
            
        }
    }
}
