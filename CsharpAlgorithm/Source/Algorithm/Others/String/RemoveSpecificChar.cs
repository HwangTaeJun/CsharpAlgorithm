using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 특정 문자 제거 (프로그래밍 면접 이렇게 준비한다. p207)
    /// </summary>
    class RemoveSpecificChar
    {
        public RemoveSpecificChar()
        {
            string exampleStr = "Battle of the Vowels: Hawaii vs. Grozny";
            string removeStr = "aeiou";

            Console.WriteLine(Solution(exampleStr, removeStr));
        }

        public string Solution(string str, string remove)
        {
            Dictionary<char, bool> strDict = new Dictionary<char, bool>();

            for (int i = 0; i < str.Length; i++)
            {
                strDict[str[i]] = true;
            }

            for (int i = 0; i < remove.Length; i++)
            {
                if(strDict.ContainsKey(remove[i]))
                {
                    strDict[remove[i]] = false;
                }
            }

            StringBuilder stringBuilder = new StringBuilder(str.Length, str.Length);

            for (int i = 0; i < str.Length; i++)
            {
                bool isAdd = strDict[str[i]];

                if(isAdd)
                {
                    stringBuilder.Append(str[i]);
                }
            }

            return stringBuilder.ToString();
        }
    }
}
