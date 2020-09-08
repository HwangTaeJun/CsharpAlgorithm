using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.Programmers.DynamicProgramming
{
    /// <summary>
    /// 소수 찾기 문제 링크 https://programmers.co.kr/learn/courses/30/lessons/42839
    /// </summary>
    class FindPrimeNumber
    {
        List<string> lstNums = new List<string>();
        List<long> lstNums2 = new List<long>();


        public FindPrimeNumber()
        {
            Console.WriteLine("\nFindPrimeNumber\n");

            List<string> defalutInputList = new List<string>();

            defalutInputList.Add("123");

            for (int i = 0; i < defalutInputList.Count; i++)
            {
                Console.WriteLine(solution(defalutInputList[i]));
            }
        }

        public int solution(string numbers)
        {
            lstNums = new List<string>();
            lstNums2 = new List<long>();

            int answer = 0;
            Perm(numbers.ToArray(), 0);
            lstNums = lstNums.Distinct().ToList();
            for (int i = 0; i < numbers.Length; i++) 
            {
                foreach (long lNum in lstNums.Select(x => long.Parse(x.Substring(i))))
                {
                    lstNums2.Add(lNum);
                }
            }
            lstNums2 = lstNums2.Distinct().ToList();
            foreach (long lNum in lstNums2)
            {
                //Console.WriteLine(lNum.ToString());
                if (IsPrime(lNum)) answer++;
            }
            return answer;
        }

        public bool IsPrime(long candidate) // 소수 판정
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }

        public void Perm(char[] a, int k)   // 순열하기
        {
            if (k == a.Length - 1)//순열을 출력
            {
                lstNums.Add(new string(a));
            }
            else
            {
                for (int i = k; i < a.Length; i++)
                {
                    //a[k]와 a[i]를 교환
                    char temp = a[k];
                    a[k] = a[i];
                    a[i] = temp;

                    Perm(a, k + 1); //a[k+1],…,a[n-1]에 대한 모든 순열
                                    //원래 상태로 되돌리기 위해 a[k]와 a[i]를 다시 교환
                    temp = a[k];
                    a[k] = a[i];
                    a[i] = temp;
                }
            }
        }
        //private Dictionary<string, bool> primeNumberDict = new Dictionary<string, bool>();
        //private int primeNumberCount = 0;

        //public FindPrimeNumber()
        //{
        //    Console.WriteLine("\nBruteForce_FindPrimeNumber\n");

        //    List<string> defalutInputList = new List<string>();

        //    defalutInputList.Add("17");
        //    defalutInputList.Add("011");
        //    defalutInputList.Add("4011");
        //    defalutInputList.Add("3581");

        //}

        //public int Solution(string number)
        //{
        //    primeNumberCount = 0;

        //    for (int i = 0; i < number.Length; i++)
        //    {
        //        char[] numberArr = number.Remove(i).ToCharArray();

        //        Perm(numberArr, 0);
        //    }

        //    return primeNumberCount;
        //}

        //private void Perm(char[] arr, int index)
        //{
        //    if (index == arr.Length - 1)//순열을 출력
        //    {
        //        for (int i = 0; i < arr.Length; i++)
        //        {
        //            Console.WriteLine(arr[i]);
        //        }

        //        Console.WriteLine("\n");

        //        string curNumber = arr.ToString().TrimStart(new char[] { '0' });

        //        if(!primeNumberDict.ContainsKey(curNumber))
        //        {
        //            primeNumberDict[curNumber] = IsPrimeNumber(curNumber);

        //            if(primeNumberDict[curNumber])
        //            {
        //                primeNumberCount++;
        //            }
        //        }
        //    }
        //    else

        //    {
        //        for (int i = index; i < arr.Length; i++)
        //        {
        //            Swap(arr, index, i);

        //            Perm(arr, index + 1);

        //            Swap(arr, index, i);
        //        }
        //    }
        //}

        //private void Swap(char[] arr, int startIndex, int endIndex)
        //{
        //    char temp = arr[startIndex];

        //    arr[startIndex] = arr[endIndex];
        //    arr[endIndex] = temp;
        //}

        //private bool IsPrimeNumber(string strNumber)
        //{
        //    int number = int.Parse(strNumber);
        //    int count = number / 2;

        //    if (number == 2)
        //    {
        //        Console.WriteLine(number);
        //        return true;
        //    }

        //    if (number < 2 || number % 2 == 0)
        //    {
        //        return false;
        //    }

        //    for (int i = 2; i < count; i++)
        //    {
        //        if(number % i == 0)
        //        {
        //            return false;
        //        }

        //    }

        //    Console.WriteLine(number);
        //    return true;
        //}
    }
}
