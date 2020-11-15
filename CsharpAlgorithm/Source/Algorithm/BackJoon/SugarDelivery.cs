using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 설탕 배달 https://www.acmicpc.net/problem/2839
    /// </summary>
    class SugarDelivery
    {
        private int bigBagSize = 5;
        private int smallBagSize = 3;
        public SugarDelivery()
        {
            Console.WriteLine("\nBackJoon_SugarDelivery\n");

            List<int> exampleResultList = new List<int>() { 4, -1, 2, 3, 3 };
            List<int> defaultInputList = new List<int>() { 18, 4, 6, 9, 11 };


            for (int i = 0; i < defaultInputList.Count; i++)
            {
                Console.WriteLine("예제 출력 : " + exampleResultList[i] + " Result : " + GetResult(defaultInputList[i]));
            }
        }

        public int GetResult(int mass)
        {
            if (mass < 3 || mass > 5000)
            {
                return -1;
            }

            int bigShareCount = mass / bigBagSize;

            if (mass % bigBagSize == 0)
            {
                return bigShareCount;
            }
            else
            {
                int extraMass = mass - (bigShareCount * bigBagSize);
                int smallShareValue = extraMass % smallBagSize;

                if (smallShareValue == 0)
                {
                    return bigShareCount + (extraMass / smallBagSize);
                }
                else
                {
                    for (int i = bigShareCount - 1; i >= 0; i--)
                    {
                        extraMass = (mass - (i * bigBagSize));
                        int smallModuloValue = extraMass % smallBagSize;

                        if (smallModuloValue == 0)
                        {
                            return i + (extraMass / smallBagSize);
                        }
                    }

                    return -1;
                }
            }
        }
    }
}
