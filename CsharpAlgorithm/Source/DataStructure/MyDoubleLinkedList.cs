using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class DoubleNode<T>
    {
        public DoubleNode<T> prev;
        public DoubleNode<T> next;

        public T data;

        public DoubleNode(T data)
        {
            this.data = data;

            next = null;
        }
    }

    class MyDoubleLinkedList<T>
    {
        private DoubleNode<T> head;

        public int Count { get; private set; } = 0;

        public void AddFirst(T data)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T data)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                DoubleNode<T> curNode = head;

                while (curNode.next != null)
                {
                    curNode = curNode.next;
                }

                newNode.prev = curNode;
                curNode.next = newNode;
            }

            Count++;
        }
    }
}
