using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class NumberCase
    {
        public int[] inputDataArr = null;
        public List<int> resultList = new List<int>();

        public NumberCase(int[] inputDataArr)
        {
            this.inputDataArr = inputDataArr;
        }

        public void CreateCombination(int pickCount, int[] tempResultArr, int current, int start)
        {
            if (pickCount == current)
            {
                string num = null;

                for (int i = 0; i < tempResultArr.Length; i++)
                {
                    Console.Write(tempResultArr[i]);
                    num += tempResultArr[i];
                }

                resultList.Add(int.Parse(num));
                Console.Write(", ");
            }
            else
            {
                for (int i = start; i < inputDataArr.Length; i++)
                {
                    tempResultArr[current] = inputDataArr[i];
                    CreateCombination(pickCount, tempResultArr, current + 1, i + 1);
                }
            }
        }

        public void CreateRepeatedCombination(int pickCount, int[] tempResultArr, int current, int start)
        {
            if (pickCount == current)
            {
                string num = null;

                for (int i = 0; i < tempResultArr.Length; i++)
                {
                    Console.Write(tempResultArr[i]);
                    num += tempResultArr[i];
                }

                resultList.Add(int.Parse(num));
                Console.Write(", ");
            }
            else
            {
                for (int i = start; i < inputDataArr.Length; i++)
                {
                    tempResultArr[current] = inputDataArr[i];
                    CreateCombination(pickCount, tempResultArr, current + 1, i);
                }
            }
        }

        public void CreatePermutation(int pickCount, int[] tempResultArr, int current, bool[] visited)
        {
            if (pickCount == current)
            {
                string num = null;

                for (int i = 0; i < tempResultArr.Length; i++)
                {
                    Console.Write(tempResultArr[i]);
                    num += tempResultArr[i];
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
                        tempResultArr[current] = inputDataArr[i];
                        CreatePermutation(pickCount, tempResultArr, current + 1, visited);
                        visited[i] = false;
                    }
                }
            }
        }

        public void CreateRepeatePermutation(int pickCount, int[] tempResultArr, int current)
        {
            if (pickCount == current)
            {
                string num = null;

                for (int i = 0; i < tempResultArr.Length; i++)
                {
                    Console.Write(tempResultArr[i]);
                    num += tempResultArr[i];
                }

                resultList.Add(int.Parse(num));
                Console.Write(", ");
            }
            else
            {
                for (int i = 0; i < inputDataArr.Length; i++)
                {
                    tempResultArr[current] = inputDataArr[i];
                    CreateRepeatePermutation(pickCount, tempResultArr, current + 1);
                }
            }
        }
    }
}
