using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class MySort
    {
        public int[] BubbleSort(int[] dataArr)
        {
            int count = dataArr.Length;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    Compare(dataArr, j, j + 1);
                }
            }

            return dataArr;
        }

        public int[] SelectSort(int[] dataArr)
        {
            int minData = default(int);

            int count = dataArr.Length;
            int minIndex = 0;
            bool needSwap = false;

            for (int i = 0; i < count - 1; i++)
            {
                minData = dataArr[i];
                minIndex = i;
                needSwap = false;

                for (int j = i + 1; j < count; j++)
                {
                    if (minData > dataArr[j])
                    {
                        minData = dataArr[j];
                        minIndex = j;
                        needSwap = true;
                    }
                }

                if (needSwap)
                {
                    Swap(dataArr, i, minIndex);
                }
            }

            return dataArr;
        }

        public int[] InsertSort(int[] dataArr)
        {
            int count = dataArr.Length;

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    Compare(dataArr, j - 1, j);
                }
            }

            return dataArr;
        }

        public int[] QuickSort(int[] dataArr)
        {
            Patition(dataArr, 0, dataArr.Length - 1);

            return dataArr;
        }

        private void Patition(int[] dataArr, int left, int right)
        {
            int count = dataArr.Length;
            int pivot = left;

            int high = left;
            int low = right;

            while (true)
            {
                while (high < count && dataArr[high] <= dataArr[pivot])
                {
                    high++;
                }

                while (low > 0 && dataArr[low] > dataArr[pivot])
                {
                    low--;
                }

                if(high > low)
                {
                    break;
                }

                if (high != low)
                {
                    Swap(dataArr, high, low);
                }
            }

            if(pivot != low)
            {
                Swap(dataArr, low, pivot);
            }

            pivot = low;

            if (pivot > left + 1)
            {
                Patition(dataArr, 0, pivot - 1);
            }

            if (right - pivot > 1)
            {
                Patition(dataArr, pivot + 1, right);
            }
        }

        private void Compare(int[] dataArr, int index, int index2)
        {
            if (dataArr[index] > dataArr[index2])
            {
                Swap(dataArr, index, index2);
            }
        }

        private void Swap(int[] dataArr, int index, int index2)
        {
            int tempData = dataArr[index];
            dataArr[index] = dataArr[index2];
            dataArr[index2] = tempData;
        }
    }
}
