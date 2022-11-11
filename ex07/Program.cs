using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackQueue
{
    class Node
    {
        public int data;
        public Node Next;

        public Node(int data, Node next)
        {
            this.data = data; this.Next = next;
        }
    }

    class SQ // base class
    {
        protected Node Head = null, Tail = null;

        //Lấy ra từ phía đầu
        public Node Pop()
        {
            if (Head == null) return null;
            Node kq = Head ;
            Head  = Head .Next;
            if (Head == null) Tail = null;
            return kq;
        }

        public bool isEmpty()
        {
            return Head == null;
        }

    }

    class Stack : SQ
    {
        // Thêm vào từ đỉnh
        public void Push( int data)
        {
            // Tạo ra Node x và nối và đầu Stack
            Node x = new Node(data, Head);
            //Cập nhật: Đầu Satck là nút x
            Head = x;

            //Nếu ds cũ rỗng (Tail == null_ thì x cũng là nút cuối
            if (Tail == null) Tail = x;
        }
    }

    class Queue : SQ
    {
        // Thêm vào ở phía cuối
        public void Add(int data)
        {
            // Tạo ra Node x và x sẽ là nút cuối (mới) 
            Node x = new Node(data, null);
           
            //Nếu ds cũ rỗng thì x cũng là nút đầu
            if (Head == null)      Head = x;
            else Tail.Next = x;     //nối x vào cuối
            //x trở thành nút cuối
            Tail = x;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            while (!s.isEmpty())
            {
                Node x = s.Pop();
                Console.WriteLine(x.data);
            }

            Queue q = new Queue();
            q.Add(10);
            q.Add(20);
            q.Add(30);
            while (!q.isEmpty())
            {
                Node x = q.Pop();
                Console.WriteLine(x.data);
            }

            Console.ReadLine();
        }
    }
}