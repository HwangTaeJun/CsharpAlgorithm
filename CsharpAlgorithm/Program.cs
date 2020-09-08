using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using CsharpAlgorithm.Source;

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
            NumberCase numberCase = new NumberCase();
            Console.WriteLine("\n조합");
            numberCase.CreateCombination(2,new int[2],0,0);
            Console.WriteLine("\n중복조합");
            numberCase.CreateRepeatedCombination(2,new int[2],0,0);
            Console.WriteLine("\n순열");
            numberCase.CreatePermutation(2, new int[2], 0, new bool[5]);
            Console.WriteLine("\n중복순열");
            numberCase.CreateRepeatePermutation(2, new int[2], 0);
            
        }
    }
}
