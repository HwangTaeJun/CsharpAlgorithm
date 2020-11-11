using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class Node<T>
    {
        public Node<T> next = null;
        public T data;

        public Node(T data)
        {
            this.data = data;
        }
    }

    class MySingleLinkedList<T>
    {
        private Node<T> head = null;

        public int Count { get; private set; }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);

            newNode.next = head;
            head = newNode;

            Count++;
        }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);

            if(head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> curNode = head;

                while (curNode.next != null)
                {
                    curNode = curNode.next;
                }

                curNode.next = newNode;
            }

            Count++;
        }
    }
}
