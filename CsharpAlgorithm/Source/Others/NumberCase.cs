using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    class NumberCase
    {
        private int[] result;
        private Stack<int> stack;
        private int r, n;
        private List<int> resultList = new List<int>();
        private int[] testArr = new int[5] { 1, 2, 3,4,5};

        public NumberCase()
        {

        }

        public void CreateCombination(int r, int[] temp, int current, int start)
        {
            if (r == current)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    Console.Write(temp[i]);
                }

                Console.Write(", ");
            }
            else
            {
                for (int i = start; i < testArr.Length; i++)
                {
                    temp[current] = testArr[i];
                    CreateCombination(r, temp, current + 1, i + 1);
                }
            }
        }

        public void CreateRepeatedCombination(int r, int[] temp, int current, int start)
        {
            if (r == current)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    Console.Write(temp[i]);
                }

                Console.Write(", ");
            }
            else
            {
                for (int i = start; i < testArr.Length; i++)
                {
                    temp[current] = testArr[i];
                    CreateCombination(r, temp, current + 1, i);
                }
            }
        }

        public void CreatePermutation(int r, int[] temp, int current, bool[] visited)
        {
            if (r == current)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    Console.Write(temp[i]);
                }

                Console.Write(", ");
            }
            else
            {
                for (int i = 0; i < testArr.Length; i++)
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        temp[current] = testArr[i];
                        CreatePermutation(r, temp, current + 1, visited);
                        visited[i] = false;
                    }
                }
            }
        }

        public void CreateRepeatePermutation(int r, int[] temp, int current)
        {
            if (r == current)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    Console.Write(temp[i]);
                }

                Console.Write(", ");
            }
            else
            {
                for (int i = 0; i < testArr.Length; i++)
                {
                    temp[current] = testArr[i];
                    CreateRepeatePermutation(r, temp, current + 1);
                }
            }
        }
    }
}
