using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 문제 링크 https://algospot.com/judge/problem/read/PICNIC
    /// </summary>
    class Picnic
    {
        private Dictionary<int, bool> pairDict = new Dictionary<int, bool>();
        private Dictionary<int, List<bool>> canPairListDict = new Dictionary<int, List<bool>>();

        public Picnic()
        {
            Console.WriteLine("\nAlgospot_Picnic\n");

            List<int> exampleResultList = new List<int>() { 1, 3, 4 };
            List<int> myResultList = new List<int>();

            myResultList.Add(GetResult(new List<int>() { 0, 1 }, 2, 1));
            myResultList.Add(GetResult(new List<int>() { 0, 1, 1, 2, 2, 3, 3, 0, 0, 2, 1, 3 }, 4, 6));
            myResultList.Add(GetResult(new List<int>() { 0, 1, 0, 2, 1, 2, 1, 3, 1, 4, 2, 3, 2, 4, 3, 4, 3, 5, 4, 5 }, 6, 10));


            for (int i = 0; i < myResultList.Count; i++)
            {
                Console.WriteLine("예제 출력 : " + exampleResultList[i] + " 내 출력 : " + myResultList[i]);
            }
        }

        private int GetResult(List<int> pairList, int studentCount, int friendCount)
        {
            for (int i = 0; i < studentCount; i++)
            {
                pairDict[i] = false;
                canPairListDict[i] = new List<bool>();

                for (int j = 0; j < studentCount; j++)
                {
                    canPairListDict[i].Add(false);
                }
            }

            for (int i = 0; i < pairList.Count; i += 2)
            {
                canPairListDict[pairList[i]][pairList[i + 1]] = true;
                canPairListDict[pairList[i + 1]][pairList[i]] = true;
            }

            return GetPairCount(0, studentCount);
        }

        private int GetPairCount(int studentIndex, int studentCount)
        {
            int curStudentIndex = -1;

            for (int i = 0; i < studentCount; i++)
            {
                if (!pairDict[i])
                {
                    curStudentIndex = i;
                    break;
                }
            }

            if (curStudentIndex == -1)
            {
                return 1;
            }

            int count = 0;

            for (int i = curStudentIndex + 1; i < studentCount; i++)
            {
                //각 index의 학생이 pair 할 수 있는 상태이며 각 학생끼리 pair 가능한지 체크
                if (!pairDict[curStudentIndex] && !pairDict[i] && canPairListDict[curStudentIndex][i])
                {
                    pairDict[curStudentIndex] = true;
                    pairDict[i] = true;

                    count += GetPairCount(curStudentIndex + 1, studentCount);

                    pairDict[curStudentIndex] = false;
                    pairDict[i] = false;

                }
            }

            return count;
        }
    }
}
