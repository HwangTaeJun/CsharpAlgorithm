using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source.Others
{
    class Permutation
    {
        private int num;
        private int[] arr;

        public Permutation(int num)
        {
            Console.WriteLine("\nPermutation\n");

            this.num = num;
            arr = null;
        }

        public int[] next()
        {   // 다음 순열 못찾으면 null 리턴
            //---------------------------------------------
            //  첫번째 순열
            //---------------------------------------------
            if (arr == null)
            {
                arr = new int[num];
                for (int k = 0; k < num; k++) arr[k] = k;
                return arr;
            }

            //---------------------------------------------
            //  Find i
            //---------------------------------------------
            int i, j;
            bool found;
            found = false;
            for (i = num - 1 - 1; i >= 0; i--)
            {
                if (arr[i] < arr[i + 1])
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
                return null;

            //---------------------------------------------
            //  Find j
            //---------------------------------------------
            found = false;
            for (j = num - 1; j >= 1; j--)
            {
                if (arr[j] > arr[i])
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
                return null;

            //---------------------------------------------
            //  swap i, j
            //---------------------------------------------
            swap(ref arr[i], ref arr[j]);

            //---------------------------------------------
            //  sorting from i+1
            //---------------------------------------------
            int m, n, imin;
            for (m = i + 1; m < num - 1; m++)
            {
                imin = m;
                for (n = m + 1; n < num; n++)
                {
                    if (arr[n] < arr[imin]) imin = n;
                }
                swap(ref arr[m], ref arr[imin]);
            }

            return arr;
        }

        //========================================================
        //  swap
        //========================================================
        private static void swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
