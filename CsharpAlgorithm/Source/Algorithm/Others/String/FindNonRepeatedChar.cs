using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 반복되지 않는 첫 번째 문자 찾기 (프로그래밍 면접 이렇게 준비한다. p 201)
    /// </summary>
    class FindNonRepeatedChar
    {
        public FindNonRepeatedChar()
        {
            string exampleStr = "teraeterglr";

            Console.WriteLine(Solution(exampleStr));
        }

        private char Solution(string str)
        {
            char[] charArr = str.ToArray();

            Dictionary<char, int> isContainCharDict = new Dictionary<char, int>();

            for (int i = 0; i < charArr.Length; i++)
            {
                char curChar = charArr[i];

                if (isContainCharDict.ContainsKey(curChar))
                {
                    isContainCharDict[curChar]++;
                }
                else
                {
                    isContainCharDict[curChar] = 1;
                }
            }

            foreach (var containsChar in isContainCharDict)
            {
                int count = containsChar.Value;

                if(count == 1)
                {
                    return containsChar.Key;
                }
            }

            return ' ';
        }
    }
}
