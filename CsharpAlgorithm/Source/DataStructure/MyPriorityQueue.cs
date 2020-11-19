using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.DataStructure
{
    class PriorityData : IComparable<PriorityData>
    {
        public string data = null;
        public int priority = 0;

        public PriorityData(string data, int priority)
        {
            this.data = data;
            this.priority = priority;
        }

        public int CompareTo(PriorityData other)
        {
            return this.priority.CompareTo(other.priority);
        }
    }

    class MyPriorityQueue<T> where T : IComparable<T>
    {
        private T[] dataArr = null;

        private int capacity = 100;

        public int Count { get; private set; } = 0;

        public MyPriorityQueue()
        {
            dataArr = new T[capacity];
        }

        public void Enqueue(T data)
        {
            if (capacity <= Count)
            {
                Resize();
            }

            dataArr[Count] = data;

            if (Count != 0)
            {
                int currentNodeIndex = Count;
                int parentIndex = (currentNodeIndex - 1) / 2;

                while (dataArr[parentIndex].CompareTo(dataArr[currentNodeIndex]) == 1)
                {
                    Swap(parentIndex, currentNodeIndex);

                    currentNodeIndex = parentIndex;
                    parentIndex = (currentNodeIndex - 1) / 2;
                }
            }

            Count++;
        }

        private void Swap(int parentIndex, int currentIndex)
        {
            T temp = dataArr[parentIndex];

            dataArr[parentIndex] = dataArr[currentIndex];
            dataArr[currentIndex] = temp;
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
