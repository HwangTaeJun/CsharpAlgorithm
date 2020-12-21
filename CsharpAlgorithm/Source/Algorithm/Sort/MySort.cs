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
