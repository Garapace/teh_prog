using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class ChainList
    {
        private class Node
        {
            public int Data { set; get; }
            public Node Next { set; get; }

            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head;
        private int quantity;

        private Node Find(int index)
        {
            if (index < 0 || index >= quantity) { return null; }

            int i = 0;
            Node CurrentNode = head;
            while (CurrentNode != null && i < index)
            {
                CurrentNode = CurrentNode.Next;
                i++;
            }

            if (i == index) { return CurrentNode; }
            else { return null; }
        }

        public void Add(int digit) 
        {
            Node NewNode = new Node(digit, null);

            if (head == null) { head = NewNode; } // проверка что голова не ведёт в null
            else
            {
                Node tail = Find(quantity - 1);
                tail.Next = NewNode;
            }
            quantity++;
        }

        public void Insert(int digit, int index)
        {
            if (index < 0 || index > quantity) { Console.WriteLine("Индекс вне диапазона"); return; }
            if (index == 0)
            {
                Node NewNode = new Node(digit, null);
                NewNode.Next = head;
                head = NewNode;
            }
            else
            {
                Node CurrentNode = Find(index - 1);
                Node NewNode = new Node(digit, null);
                NewNode.Next = CurrentNode.Next;
                CurrentNode.Next = NewNode;
            }
            quantity++;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= quantity) { Console.WriteLine("Индекс вне диапазона"); return; }
            if (index == 0 && head != null)
            {
                head = head.Next;
                quantity--;
                return;
            }

            Node PreviousNode = Find(index - 1);
            Node CurrentNode = Find(index);

            if (CurrentNode != null)
            {
                PreviousNode.Next = CurrentNode.Next;
                quantity--;
            }
        }

        public void Clear()
        {
            head = null;
            quantity = 0;
        }

        public int Count
        {
            get { return quantity; }
        }

        public int this[int index]
        {
            get
            {
                if (index < quantity || index >= 0)
                {
                    Node CurrentNode = Find(index);
                    return CurrentNode.Data;
                }
                return 0;
            }
            set
            {
                if (index < quantity || index >= 0)
                {
                    Node CurrentNode = Find(index);
                    CurrentNode.Data = value;
                }
            }
        }

        public void Print()
        {
            Node CurrentNode = head;
            while (CurrentNode != null)
            {
                Console.Write(CurrentNode.Data + " ");
                CurrentNode = CurrentNode.Next;
            }
            Console.WriteLine();
        }
    }
}