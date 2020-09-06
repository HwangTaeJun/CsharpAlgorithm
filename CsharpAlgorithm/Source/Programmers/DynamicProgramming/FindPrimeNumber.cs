using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.Programmers.DynamicProgramming
{
    /// <summary>
    /// 소수 찾기 문제 링크 https://programmers.co.kr/learn/courses/30/lessons/42839
    /// </summary>
    class FindPrimeNumber
    {
        private Dictionary<int, bool> isCheckedNumberDict = new Dictionary<int, bool>();
        private string number = null;

        public FindPrimeNumber()
        {
        }

        private int Solution(string numbers)
        {
            number = numbers;

            for (int i = 0; i < numbers.Length; i++)
            {

            }

            return 0;
        }

        private void CreateNumber(int selectableCount, int index)
        {
            
        }

        private bool IsPrimeNumber()
        {
            return false;
        }
    }

}
