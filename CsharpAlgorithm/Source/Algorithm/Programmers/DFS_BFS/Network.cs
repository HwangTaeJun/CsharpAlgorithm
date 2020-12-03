using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 네트워크 https://programmers.co.kr/learn/courses/30/lessons/43162
    /// </summary>
    class Network
    {
        public Network()
        {
            List<int> inputCountList = new List<int>() { 3, 3, 6 };
            List<int> resultList = new List<int>() { 2, 1, 1 };
            List<int[,]> inputComputerList = new List<int[,]>();

            inputComputerList.Add(new int[,] { { 1, 1, 0 }, { 1, 1, 0 }, { 0, 0, 1 } });
            inputComputerList.Add(new int[,] { { 1, 1, 0 }, { 1, 1, 1 }, { 0, 1, 1 } });
            inputComputerList.Add(new int[,] { { 1, 0, 1, 1, 0, 0 }, { 0, 1, 0, 0, 1, 1 }, { 1, 0, 1, 1, 1, 1 }, { 1, 0, 1, 1, 1, 1 }, { 0, 1, 1, 1, 1, 1 }, { 0, 1, 1, 1, 1, 1 } });

            for (int i = 0; i < inputComputerList.Count; i++)
            {
                if (resultList[i] == Solution(inputCountList[i], inputComputerList[i]))
                {
                    Console.WriteLine("입력에 따른 결과값이 일치함");
                }
                else
                {
                    Console.WriteLine("입력에 따른 결과값이 다름 result : " + resultList[i] + "myResult : " + Solution(inputCountList[i], inputComputerList[i]));
                }
            }
        }

        public int Solution(int count, int[,] computerArr)
        {
            return 0;
        }
    }
}
