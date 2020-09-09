using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class NumberCase
    {
        private int[] inputDataArr = null;
        public List<int> resultList = new List<int>();

        public NumberCase(int[] inputDataArr)
        {
            this.inputDataArr = inputDataArr;
        }

        public void CreateCombination(int pickCount, int[] tempArr, int current, int start)
        {
            if (pickCount == current)
            {
                for (int i = 0; i < tempArr.Length; i++)
                {
                    Console.Write(tempArr[i]);
                }

                Console.Write(", ");
            }
            else
            {
                for (int i = start; i < inputDataArr.Length; i++)
                {
                    tempArr[current] = inputDataArr[i];
                    CreateCombination(pickCount, tempArr, current + 1, i + 1);
                }
            }
        }

        public void CreateRepeatedCombination(int pickCount, int[] tempArr, int current, int start)
        {
            if (pickCount == current)
            {
                for (int i = 0; i < tempArr.Length; i++)
                {
                    Console.Write(tempArr[i]);
                }

                Console.Write(", ");
            }
            else
            {
                for (int i = start; i < inputDataArr.Length; i++)
                {
                    tempArr[current] = inputDataArr[i];
                    CreateCombination(pickCount, tempArr, current + 1, i);
                }
            }
        }

        public void CreatePermutation(int pickCount, int[] tempArr, int current, bool[] visited)
        {
            if (pickCount == current)
            {
                string num = null;

                for (int i = 0; i < tempArr.Length; i++)
                {
                    Console.Write(tempArr[i]);
                    num += tempArr[i];
                }

                resultList.Add(int.Parse(num));
                Console.Write(", ");
            }
            else
            {
                for (int i = 0; i < inputDataArr.Length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        tempArr[current] = inputDataArr[i];
                        CreatePermutation(pickCount, tempArr, current + 1, visited);
                        visited[i] = false;
                    }
                }
            }
        }

        public void CreateRepeatePermutation(int pickCount, int[] tempArr, int current)
        {
            if (pickCount == current)
            {
                for (int i = 0; i < tempArr.Length; i++)
                {
                    Console.Write(tempArr[i]);
                }

                Console.Write(", ");
            }
            else
            {
                for (int i = 0; i < inputDataArr.Length; i++)
                {
                    tempArr[current] = inputDataArr[i];
                    CreateRepeatePermutation(pickCount, tempArr, current + 1);
                }
            }
        }
    }
}
