using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.DataStructure
{
    class MyStack<T>
    {
        private T[] dataArr = null;

        private int index = -1;
        private int capacity = 5;

        public int Count { get; private set; } = 0;

        public MyStack()
        {
            dataArr = new T[capacity];
        }

        public void Push(T data)
        {
            if(IsFull())
            {
                Resize();
            }

            index += 1;

            dataArr[index] = data;

            Count++;
        }


        public T Pop()
        {
            T data = dataArr[index];

            index--;
            Count--;

            return data;
        }

        public T Peek()
        {
            return dataArr[index];
        }

        public bool IsFull()
        {
            if(Count >= capacity)
            {
                return true;
            }

            return false;
        }

        public bool IsEmpty()
        {
            if(Count == 0)
            {
                return true;
            }

            return false;
        }

        public void Resize()
        {
            capacity *= 2;

            T[] newDataArr = new T[capacity];

            dataArr.CopyTo(newDataArr, 0);

            dataArr = newDataArr;
        }
    }
}
