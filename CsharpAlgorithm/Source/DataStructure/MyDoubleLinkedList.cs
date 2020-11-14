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
                InitNodes(newNode);
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

        public void Remove(T data)
        {
            if (head == null)
            {
                Console.WriteLine("데이터가 존재하지 않습니다.");
                return;
            }
            else
            {
                //head 처리
                if (head.data.Equals(data))
                {
                    if (Count == 1)
                    {
                        InitNodes(null);
                    }
                    else
                    {
                        head.next.prev = null;
                        head = head.next;
                    }

                    Count--;
                    return;
                }
                else
                {
                    DoubleNode<T> curNode = head;

                    while (curNode != null)
                    {
                        if (curNode.data.Equals(data))
                        {
                            if (curNode == tail)
                            {
                                tail = tail.prev;
                                tail.next = null;
                            }
                            else
                            {
                                curNode.next.prev = curNode.prev;
                                curNode.prev.next = curNode.next;
                            }

                            curNode = null;

                            Count--;
                            return;
                        }
                        else
                        {
                            curNode = curNode.next;
                        }
                    }
                }
            }
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                Console.WriteLine("데이터가 없습니다.");
            }
            else
            {
                head = head.next;

                if (head == null)
                {
                    tail = null;
                }

                Count--;
            }
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                Console.WriteLine("데이터가 없습니다.");
            }
            else
            {
                if (Count == 1)
                {
                    InitNodes(null);
                }
                else
                {
                    tail = tail.prev;
                    tail.next = null;
                }

                Count--;
            }
        }

        public void Reverse()
        {
            if (Count < 2)
            {
                return;
            }

            DoubleNode<T> curNode = head;

            DoubleNode<T> prevNode = null;
            DoubleNode<T> tempNode = null;

            for (int i = 0; i < Count; i++)
            {
                if (i == 0)
                {
                    tail = curNode;
                }

                tempNode = curNode.next;

                curNode.next = curNode.prev;
                curNode.prev = tempNode;

                prevNode = curNode;
                curNode = tempNode;
            }

            head = prevNode;
        }

        private void InitNodes(DoubleNode<T> node)
        {
            head = node;
            tail = node;
        }
    }
}
