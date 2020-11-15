using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class MyQueue<T>
    {
        private T[] dataArr = null;

        private int front = -1;
        private int rear = -1;

        private int capacity = 5;

        public int Count { get; private set; } = 0;

        public MyQueue()
        {
            dataArr = new T[capacity];
        }

        public void Enqueue(T data)
        {
            if (IsFull())
            {
                Resize();
            }

            rear = (rear + 1) % capacity;
            Count++;

            dataArr[rear] = data;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty");
            }

            front = (front + 1) % capacity;
            Count--;

            return dataArr[front];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty");
            }
            else
            {
                return dataArr[front + 1];
            }
        }

        private bool IsFull()
        {
            if ((Count > 0 && front == rear) || capacity <= Count)
            {
                return true;
            }

            return false;
        }

        private bool IsEmpty()
        {
            if (Count == 0)
            {
                return true;
            }

            return false;
        }

        private void Resize()
        {
            T[] newDataArr = new T[capacity * 2];

            for (int i = 0; i < capacity; i++)
            {
                int index = (rear + 1 + i) % capacity;

                newDataArr[i] = dataArr[index];
            }

            rear = Count - 1;
            front = -1;
            capacity *= 2;
            dataArr = newDataArr;
        }
    }
}
