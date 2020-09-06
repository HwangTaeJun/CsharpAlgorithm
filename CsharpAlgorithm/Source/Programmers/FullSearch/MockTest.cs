using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.Programmers.FullSearch
{
    /// <summary>
    /// 모의고사 문제 링크 https://programmers.co.kr/learn/courses/30/lessons/42840
    /// </summary>
    class MockTest
    {
        private List<List<int>> correctList = new List<List<int>>();
        private List<int> correctCountList = new List<int>() { 0, 0, 0 };

        public MockTest()
        {
            Console.WriteLine("\nProgrammers_MockTest\n");

            correctList.Add(new List<int>() { 1, 2, 3, 4, 5 });
            correctList.Add(new List<int>() { 2, 1, 2, 3, 2, 4, 2, 5 });
            correctList.Add(new List<int>() { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 });

            List<int[]> inputList = new List<int[]>();

            inputList.Add(new int[5] { 1, 2, 3, 4, 5 });
            inputList.Add(new int[5] { 1, 3, 2, 4, 2 });

            for (int i = 0; i < inputList.Count; i++)
            {
                int[] result = Solution(inputList[i]);

                for (int j = 0; j < result.Length; j++)
                {
                    Console.WriteLine(result[j]);

                    if (j == result.Length - 1)
                    {
                        Console.WriteLine("\n");
                    }
                }
            }
        }

        private int[] Solution(int[] answerArr)
        {
            int[] resultArr = null;
            correctCountList = new List<int>() { 0, 0, 0 };

            for (int i = 0; i < answerArr.Length; i++)
            {
                for (int j = 0; j < correctList.Count; j++)
                {
                    if (correctList[j][i % correctList[j].Count] == answerArr[i])
                    {
                        correctCountList[j]++;
                    }
                }
            }

            int maxIndex = 0;
            int maxCount = correctCountList[maxIndex];

            List<int> indexList = new List<int>();


            for (int i = 0; i < correctCountList.Count; i++)
            {
                if (maxCount < correctCountList[i])
                {
                    indexList = new List<int>();
                    indexList.Add(i + 1);

                    maxCount = correctCountList[i];
                }
                else if (maxCount == correctCountList[i])
                {
                    indexList.Add(i + 1);
                }
            }

            resultArr = indexList.ToArray();

            return resultArr;
        }
    }
}
