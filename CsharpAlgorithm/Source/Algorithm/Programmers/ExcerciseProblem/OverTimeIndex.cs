using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 야근 지수 https://programmers.co.kr/learn/courses/30/lessons/12927
    /// </summary>
    class OverTimeIndex
    {
        public OverTimeIndex()
        {
            List<int> inputOverTimeCountList = new List<int>() { 4, 1, 3 };
            List<int[]> inputWorkArrList = new List<int[]>();
            List<int> resultList = new List<int>() { 12, 6, 0 };

            inputWorkArrList.Add(new int[] { 4, 3, 3 });
            inputWorkArrList.Add(new int[] { 2, 1, 2 });
            inputWorkArrList.Add(new int[] { 1, 1 });

            for (int i = 0; i < inputOverTimeCountList.Count; i++)
            {
                if (resultList[i] == Solution(inputOverTimeCountList[i], inputWorkArrList[i]))
                {
                    Console.WriteLine("입력에 따른 결과값이 일치함");
                }
            }
        }

        private long Solution(int overTimeCount, int[] workArr)
        {
            long result = 0;

            Array.Sort(workArr);
            Array.Reverse(workArr);

            int maxWorkAmount = workArr[0];
            int maxIndex = 0;
            int secondMaxIndex = 0;

            while (overTimeCount > 0)
            {
                if (workArr[workArr.Length - 1] <= 0)
                {
                    return 0;
                }

                if (maxWorkAmount > workArr[maxIndex + 1])
                {
                    int diff = maxWorkAmount - workArr[maxIndex + 1];

                    if (diff > overTimeCount)
                    {
                        diff = overTimeCount;
                    }

                    overTimeCount -= diff;
                    workArr[maxIndex] -= diff;
                    maxWorkAmount -= diff;
                }
                else
                {
                    secondMaxIndex = workArr.Length;

                    for (int i = maxIndex; i < workArr.Length; i++)
                    {
                        if (maxWorkAmount > workArr[i])
                        {
                            secondMaxIndex = i;
                            break;
                        }
                    }

                    for (int i = maxIndex; i < secondMaxIndex; i++)
                    {
                        overTimeCount--;
                        workArr[i]--;

                        if (overTimeCount == 0)
                        {
                            break;
                        }
                    }

                    maxWorkAmount--;
                }
            }

            for (int i = 0; i < workArr.Length; i++)
            {
                int num = workArr[i];
                result += num * num;
            }

            return result;
        }
    }
}
