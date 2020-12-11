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
        private List<int> workList = null;

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
                Console.WriteLine(Solution(inputOverTimeCountList[i], inputWorkArrList[i]));
            }
        }

        private int Solution(int overTimeCount, int[] workArr)
        {
            int result = 0;

            return result;
        }
    }
}
