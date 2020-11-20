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

        public MyPriorityQueue(int capacity)
        {
            this.capacity = capacity;
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

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                T data = dataArr[0];

                dataArr[0] = dataArr[Count - 1];
                dataArr[Count - 1] = default(T);

                if (Count > 1)
                {
                    int currentNodeIndex = 0;

                    int childIndex = currentNodeIndex * 2 + 1;
                    int lastIndex = Count - 2;

                    //자식이 있는지 체크
                    while (childIndex <= lastIndex)
                    {
                        int rightChildIndex = childIndex + 1;

                        //자식 간 우선순위 비교
                        if (rightChildIndex <= lastIndex && dataArr[childIndex].CompareTo(dataArr[rightChildIndex]) == 1)
                        {
                            childIndex = rightChildIndex;
                        }

                        //현재 노드와 우선순위가 높은 자식과 우선순위 비교
                        if (dataArr[currentNodeIndex].CompareTo(dataArr[childIndex]) == 1)
                        {
                            Swap(childIndex, currentNodeIndex);

                            currentNodeIndex = childIndex;
                            childIndex = currentNodeIndex * 2 + 1;
                        }
                        else //현재 노드가 자식보다 우선순위가 높을 때
                        {
                            break;
                        }
                    }
                }

                Count--;
                return data;
            }
        }

        public T Peek()
        {
            return dataArr[0];
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
