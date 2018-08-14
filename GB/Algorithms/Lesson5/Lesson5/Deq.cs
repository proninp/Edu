using System;

namespace Lesson5
{
    public class Node<T>
    {
        public T Val { get; set; }
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }

        public Node(T val) => Val = val;
    }

    public class Deq<T>
    {
        int count;
        Node<T> head;
        Node<T> tail;

        public int Count { get { return count; } }

        public void AddFirst(T val)
        {
            Node<T> t = head;
            Node<T> node = new Node<T>(val);
            node.Next = t;
            head = node;
            if (count != 0) t.Prev = node;
            else tail = head;
            count++;
        }
        public void AddLast(T val)
        {
            Node<T> node = new Node<T>(val);
            if (head != null)
            {
                tail.Next = node;
                node.Prev = tail;
            } else { head = node; }
            tail = node;
            count++;
        }
        public T PopFirst()
        {
            if (count != 0)
            {
                T pop = head.Val;
                if (count != 1)
                {
                    head = head.Next;
                    head.Prev = null;
                } else  head = tail = null;
                count--;
                return pop;
            }
            throw new Exception("Nothing to Pop!");
        }
        public T PopLast()
        {
            if (count != 0)
            {
                T pop = tail.Val;
                if (count != 1)
                {
                    tail = tail.Prev;
                    tail.Next = null;
                }
                else head = tail = null;
                count--;
                return pop;
            }
            throw new Exception("Nothing to Pop!");
        }
    }
}
