using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 소수 찾기 문제 링크 https://programmers.co.kr/learn/courses/30/lessons/42839
    /// </summary>
    class FindPrimeNumber
    {
        private char[] inputDataArr = null;
        private List<string> permList = new List<string>();

        public FindPrimeNumber()
        {
            Console.WriteLine("\nFindPrimeNumber\n");

            List<string> defalutInputList = new List<string>();

            defalutInputList.Add("17");
            defalutInputList.Add("011");

            for (int i = 0; i < defalutInputList.Count; i++)
            {
                permList = new List<string>();
                Console.WriteLine(Solution(defalutInputList[i]));
            }
        }

        public int Solution(string numbers)
        {
            inputDataArr = numbers.ToArray();

            int result = 0;

            for (int i = 1; i < numbers.Length + 1; i++)
            {
                CreatePermutation(i, new char[i], 0, new bool[numbers.Length]);
            }

            permList = permList.Distinct().ToList();

            for (int i = 0; i < permList.Count; i++)
            {
                if (IsPrimeNumber(permList[i]))
                {
                    result++;
                }
            }

            return result;
        }

        public void CreatePermutation(int pickCount, char[] tempArr, int current, bool[] visited)
        {
            if (pickCount == current)
            {
                string num = null;
                bool isNumber = false;

                for (int i = 0; i < tempArr.Length; i++)
                {
                    if(tempArr[i] != '0')
                    {
                        isNumber = true;
                    }

                    num += tempArr[i].ToString();
                }

                if(isNumber)
                {
                    permList.Add(num.TrimStart(new char[] { '0' }));
                }
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

        private bool IsPrimeNumber(string strNumber)
        {
            int number = int.Parse(strNumber);
            int count = number / 2;

            if (number == 2)
            {
                //Console.WriteLine(number);
                return true;
            }

            if (number < 2 || number % 2 == 0)
            {
                return false;
            }

            for (int i = 2; i < count; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            //Console.WriteLine(number);
            return true;
        }

        private bool IsPrimeNumber(int number)
        {
            int count = number / 2;

            if (number == 2)
            {
                //Console.WriteLine(number);
                return true;
            }

            if (number < 2 || number % 2 == 0)
            {
                return false;
            }

            for (int i = 2; i < count; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }

            }

            //Console.WriteLine(number);
            return true;
        }
    }
}
