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

        public void Remove(T data)
        {
            if (head == null)
            {
                return;
            }
            else
            {
                //head밖에 없을 때
                if(Count == 1)
                {
                    if(head.data.Equals(data))
                    {
                        head = null;
                        Count--;
                    }

                    return;
                }

                Node<T> curNode = head;
                Node<T> prevNode = null;

                while (curNode.next != null)
                {
                    if(curNode.data.Equals(data))
                    {
                        //head를 제거 할 때
                        if (prevNode == null)
                        {
                            head = head.next;
                        }
                        else
                        {
                            prevNode.next = curNode.next;
                            curNode = null;
                        }

                        Count--;
                        return;
                    }

                    prevNode = curNode;
                    curNode = curNode.next;
                }
            }
        }

        public void RemoveFirst()
        {
            if(head == null)
            {
                return;
            }

            head = head.next;

            Count--;
        }

        public void RemoveLast()
        {
            if(head == null)
            {
                return;
            }
            else
            {
                Node<T> curNode = head;
                Node<T> prevNode = null;

                while (curNode.next != null)
                {
                    prevNode = curNode;
                    curNode = curNode.next;
                }

                if (prevNode == null)
                {
                    head = null;
                }
                else
                {
                    prevNode.next = null;
                }

                Count--;
            }
        }

        public Node<T> Find(T data)
        {
            Node<T> curNode = head;

            while (curNode != null)
            {
                if(curNode.data.Equals(data))
                {
                    return curNode;
                }

                curNode = curNode.next;
            }

            Console.WriteLine("일치하는 데이터를 찾을 수 없습니다.");

            return null;
        }
    }
}
