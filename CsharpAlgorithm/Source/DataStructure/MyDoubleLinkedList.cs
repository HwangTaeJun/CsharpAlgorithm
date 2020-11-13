using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class DoubleNode<T>
    {
        public DoubleNode<T> prev = null;
        public DoubleNode<T> next = null;

        public T data;

        public DoubleNode(T data)
        {
            this.data = data;
        }
    }

    class MyDoubleLinkedList<T>
    {
        private DoubleNode<T> head = null;
        private DoubleNode<T> tail = null;

        public int Count { get; private set; } = 0;

        public void AddFirst(T data)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
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
                tail = newNode;
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
                tail = newNode;
            }

            Count++;
        }
    }
}
