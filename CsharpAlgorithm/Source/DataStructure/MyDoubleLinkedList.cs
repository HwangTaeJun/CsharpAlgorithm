using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.Others
{
    class Node<T>
    {
        public T data;
        public Node<T> prev;
        public Node<T> next;

        public Node(T data)
        {
            this.data = data;

            next = null;
        }
    }

    class MyDoubleLinkedList<T>
    {
        private Node<T> head;

        public int Count { get; private set; } = 0;

        public void Add(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
                head.prev = null;
            }
            else
            {
            }
        }
    }
}
