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

        private int targetIndex = 0;
        private int currentIndex = 0;

        private T targetData;
        private T currentData;

        public int Count { get; private set; } = 0;

        public MyPriorityQueue()
        {
            dataArr = new T[capacity];
        }

        public void Enqueue(T data)
        {
            if(capacity <= Count)
            {
                Resize();
            }

            dataArr[Count] = data;

            if (Count != 0)
            {
                MoveUpNode(Count);

                while(IsHighCurrentNodePriority(targetData, currentData))
                {
                    Swap(targetIndex, currentIndex);

                    MoveUpNode(targetIndex);
                }
            }

            Count++;
        }

        private void MoveUpNode(int index)
        {
            currentIndex = index;
            targetIndex = (currentIndex - 1) / 2;

            currentData = dataArr[currentIndex];
            targetData = dataArr[targetIndex];
        }

        private bool IsHighCurrentNodePriority(T target, T current)
        {
            if (target.CompareTo(current) < 0)
            {
                return true;
            }

            return false;
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
