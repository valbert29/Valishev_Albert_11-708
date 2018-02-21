using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new MyList();
            for (int i = 0; i < 5; i++) c.Push(i);
            Console.WriteLine(c.Search(2));
            Console.WriteLine(c.Count());
            c.PrintOut();



        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class MyList
    {
        public Node tail;
        public Node head;
        public Node Element;

        public void Push(int data)
        {
            if (head == null)
            {
                tail = head = new Node(data);
            }
            else
            {
                Element = new Node(data);
                tail.Next = Element;
                tail = Element;
            }

        }

        public int Pop()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            var result = head.Data;
            head = head.Next;
            if (head == null) tail = null;
            return result;
        }

        public int Search(int value)
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }
            int i = 0;
            Element = head;
            while (value != Element.Data)
            {
                Element = Element.Next;
                i++;
            }
            return i+1;
        }

        public int Count()
        {
            Element = head;
            int i = 0;
            while (Element.Next != null)
            {
                i++;
                Element = Element.Next;
            }
            return i;
        }

        public void PrintOut()
        {
            Element = head;
            if (Element == null)
            {
                throw new InvalidOperationException();
            }
            Console.WriteLine(Element.Data);
            while (Element.Next != null)
            {
                Element = Element.Next;
                Console.WriteLine(Element.Data);
                
            }
            
        }
        /*public int Insert()
        {
            return
        }*/


    }


}
