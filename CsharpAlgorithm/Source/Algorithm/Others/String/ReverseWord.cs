using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 단어 뒤집기 (프로그래밍 면접 이렇게 준비한다. p211)
    /// </summary>
    class ReverseWord
    {
        public ReverseWord()
        {
            string exampleStr = "Do or do not, there is no try.";

            Console.WriteLine(Solution(exampleStr));
        }

        public string Solution(string str)
        {
            Stack<StringBuilder> reverseWordSBStack = new Stack<StringBuilder>();
            reverseWordSBStack.Push(new StringBuilder(str.Length, str.Length));

            for (int i = 0; i < str.Length; i++)
            {
                reverseWordSBStack.Peek().Append(str[i]);

                if (str[i] == ' ')
                {
                    reverseWordSBStack.Push(new StringBuilder(str.Length, str.Length));
                }
            }

            StringBuilder resultSB = new StringBuilder(str.Length, str.Length);

            foreach (var item in reverseWordSBStack)
            {
                resultSB.Append(item);
            }

            return resultSB.ToString();
        }
    }
}
