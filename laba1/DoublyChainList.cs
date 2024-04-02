using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1
{
    internal class DoublyChainList
    {
        private class Node
        {
            public int Data { set; get; }
            public Node Next { set; get; }
            public Node Prev { set; get; }

            public Node(int data, Node next, Node prev)
            {
                Data = data;
                Next = next;
                Prev = prev;
            }
        }

        private Node head;
        private Node tail;
        private int quantity;

        private Node Find(int index)
        {
            if (index < 0 || index >= quantity) { return null; }

            int StartIndex = 0;
            int EndIndex = quantity - 1;

            while (StartIndex <= EndIndex)
            {
                int MidIndex = StartIndex + (EndIndex - StartIndex) / 2;
                Node CurrentNode = GetNode(MidIndex);

                if (MidIndex == index)
                {
                    return CurrentNode;
                }
                else if (MidIndex < index)
                {
                    StartIndex = MidIndex + 1;
                }
                else
                {
                    EndIndex = MidIndex - 1;
                }
            }
            return null;
        }

        private Node GetNode(int index)
        {
            int i = 0;
            Node CurrentNode = head;
            while (CurrentNode != null && i < index)
            {
                CurrentNode = CurrentNode.Next;
                i++;
            }

            return CurrentNode;
        }

        public void Add(int digit)
        {
            Node NewNode = new Node(digit, null, null);

            if (head == null) { head = NewNode; }
            else
            {
                Node tail = Find(quantity - 1);
                tail.Next = NewNode;
                NewNode.Prev = tail;
            }
            quantity++;
        }

        public void Insert(int digit, int index)
        {
            if (index < 0 || index > quantity) { Console.WriteLine("Индекс вне диапазона"); return; }
            if (index == 0)
            {
                Node NewNode = new Node(digit, head, null);
                if (head != null)
                {
                    head.Prev = NewNode; // Устанавливаем новый элемент как предыдущий для головного
                }
                head = NewNode;
            }
            else
            {
                Node CurrentNode = Find(index - 1);
                Node NewNode = new Node(digit, CurrentNode.Next, CurrentNode);
                CurrentNode.Next = NewNode;
                if (NewNode.Next != null)
                {
                    NewNode.Next.Prev = NewNode; // Устанавливаем новый элемент как предыдущий для следующего элемента
                }
            }
            quantity++;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= quantity) { Console.WriteLine("Индекс вне диапазона"); return; }
            if (index == 0)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null; // Снимаем связь с предыдущего элемента
                }
                quantity--;
            }
            else
            {
                Node СurrentNode = Find(index);
                Node PrevNode = СurrentNode.Prev;
                PrevNode.Next = СurrentNode.Next;
                if (СurrentNode.Next != null)
                {
                    СurrentNode.Next.Prev = PrevNode; // Изменяем ссылку на предыдущий узел для следующего элемента
                }
                quantity--;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
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
