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

        private T frontData;

        private int front = -1;
        private int rear = -1;

        private int capacity = 3;

        public int Count { get; private set; } = 0;

        public MyQueue()
        {
            dataArr = new T[capacity];
        }

        public void Enqueue(T data)
        {
            if(IsFull())
            {
                Resize();
            }

            if(front == rear)
            {
                frontData = data;
            }

            rear = (rear + 1) % capacity;
            Count++;

            dataArr[rear] = data;
        }

        public T Dequeue()
        {
            if(IsEmpty())
            {
                throw new Exception("Empty");
            }

            front = (front + 1) % capacity;
            Count--;

            if (!IsEmpty())
            {
                frontData = dataArr[front + 1];
            }

            return dataArr[front];
        }

        public T Peek()
        {
            if(IsEmpty())
            {
                throw new Exception("Empty");
            }

            return frontData;
        }

        private bool IsFull()
        {
            if(front == rear + 1 || capacity <= Count)
            {
                return true;
            }

            return false;
        }

        private bool IsEmpty()
        {
            if(rear == front)
            {
                frontData = default(T);

                return true;
            }

            return false;
        }

        private void Resize()
        {
            capacity *= 2;

            T[] newDataArr = new T[capacity];

            dataArr.CopyTo(newDataArr, 0);
            dataArr = newDataArr;
        }
    }
}
