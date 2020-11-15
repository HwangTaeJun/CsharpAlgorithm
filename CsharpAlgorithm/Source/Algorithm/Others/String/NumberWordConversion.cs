using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 정수/문자열 변환 (프로그래밍 면접 이렇게 준비한다. p217)
    /// </summary>
    class NumberWordConversion
    {
        public NumberWordConversion()
        {
            Console.WriteLine("492");
            Console.WriteLine(492);

            Console.WriteLine("-492");
            Console.WriteLine(-492);

            Console.WriteLine(int.MaxValue.ToString());
            Console.WriteLine(int.MaxValue);

            Console.WriteLine(int.MinValue.ToString());
            Console.WriteLine(int.MinValue);

            Console.WriteLine("0");
            Console.WriteLine(0);
        }

        public int Soulution(string numberStr)
        {
            int resultNumber = 0;
            bool isMinus = false;

            if(numberStr[0] == '-')
            {
                numberStr = numberStr.Remove(0);
                isMinus = true;
            }

            for (int i = 0; i < numberStr.Length; i++)
            {
                resultNumber += ((int)Math.Pow(10, numberStr.Length - i - 1)) * (numberStr[i] - '0');
            }

            if(isMinus)
            {
                resultNumber *= -1;
            }

            return resultNumber;
        }

        public string Soulution(int number)
        {
            bool isMinus = false;

            if(number == 0)
            {
                return "0";
            }
            else if(number == int.MinValue)
            {
                return "-2147483648";
            }

            if(number < 0)
            {
                number *= -1;
                isMinus = true;
            }

            StringBuilder stringBuilder = new StringBuilder(10, 10);
            Stack<char> charStack = new Stack<char>();

            if (isMinus)
            {
                stringBuilder.Append('-');
            }

            while (number != 0)
            {
                charStack.Push((char)(number % 10 + '0'));
            }

            foreach (var item in charStack)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }
    }
}
