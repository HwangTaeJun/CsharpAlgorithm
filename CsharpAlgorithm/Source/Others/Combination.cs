using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.Others
{
    class Combination
    {
        private int[] result;
        private Stack<int> stack;
        private int r, n;


        public Combination(int r, int n)
        {
            Console.WriteLine("\nCombination\n");
            // nCr 계산
            this.r = r;
            this.n = n;

            result = new int[r];
            stack = new Stack<int>();
            stack.Push(0);
        }

        public int[] next()
        {   
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == r)
                    {
                        return result;
                    }
                }
            }

            return null;
        }
    }
}
