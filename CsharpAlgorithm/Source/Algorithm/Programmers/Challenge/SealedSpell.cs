using System.Linq;
using System.Text;

namespace CsharpAlgorithm.Source.Algorithm.Programmers.Challenge
{
    //봉인된 주문
    //https://school.programmers.co.kr/learn/courses/30/lessons/389481

    class SealedSpell
    {
        public string Solution(long n, string[] bans)
        {
            var list = bans.Select(x => CalcBanNumber(x)).OrderBy(x=>x).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= n)
                    n++;
            }

            var spell = CalcSpell(n);
            return spell;
        }

        private long CalcBanNumber(string ban)
        {
            long value = 0;

            foreach (char c in ban)
            {
                long numberValue = c - 'a' + 1;
                value = value * 26 + numberValue;
            }

            return value;
        }

        private string CalcSpell(long value)
        {
            var sb = new StringBuilder();

            while (value > 0)
            {
                value--;
                char charValue = (char)('a' + (value % 26));
                sb.Insert(0, charValue);
                value /= 26;
            }

            return sb.ToString();
        }
    }
}