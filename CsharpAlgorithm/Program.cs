using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CsharpAlgorithm.Source.Algospot;
using CsharpAlgorithm.Source.BackJoon;
using CsharpAlgorithm.Source.NYPC._2019;
using CsharpAlgorithm.Source.Programmers.FullSearch;
using CsharpAlgorithm.Source.Programmers.DynamicProgramming;
using CsharpAlgorithm.Source.Others;

namespace CsharpAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# 알고리즘 문제 풀이");

            Picnic picnic = new Picnic();
            SugarDelivery sugarDelivery = new SugarDelivery();
            //MabinogiInventory mabinogiInventory = new MabinogiInventory();
            MockTest mockTest = new MockTest();

            int n = 3;
            int cnt = 0;
            Permutation perm = new Permutation(n);
            List<string> number = new List<string>();

            while (true)
            {
                int[] c = perm.next();

                string str = null;

                if (c == null) break;
                for (int i = 0; i < c.Length; i++)
                {
                    str += c[i].ToString();
                }

                number.Add(str);
            }

            FindPrimeNumber findPrimeNumber = new FindPrimeNumber();
        }
    }
}
