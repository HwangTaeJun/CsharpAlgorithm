using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.Algospot
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
            Init(new List<int>() { 0, 1 }, 2, 1);
            Init(new List<int>() { 0, 1, 1, 2, 2, 3, 3, 0, 0, 2, 1, 3 }, 4, 6);
            Init(new List<int>() { 0, 1, 0, 2, 1, 2, 1, 3, 1, 4, 2, 3, 2, 4, 3, 4, 3, 5, 4, 5 }, 6, 10);
        }

        private void Init(List<int> pairList, int studentCount, int friendCount)
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

            Console.WriteLine(GetPairCount(0, studentCount));
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
