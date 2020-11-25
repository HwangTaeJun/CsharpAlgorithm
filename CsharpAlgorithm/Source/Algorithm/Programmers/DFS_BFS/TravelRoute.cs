using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 여행경로 https://programmers.co.kr/learn/courses/30/lessons/43164
    /// </summary>
    class TravelRoute
    {
        //알고리즘 문제에서 제공되는 input에 따른 결과값이 일치하는지 비교
        public TravelRoute()
        {
            List<string[,]> exampleInputList = new List<string[,]>();
            List<string[]> exampleOutputList = new List<string[]>();

            exampleInputList.Add(new string[,] { { "ICN", "JFK" }, { "HND", "IAD" }, { "JFK", "HND" } });
            exampleInputList.Add(new string[,] { { "ICN", "SFO" }, { "ICN", "ATL" }, { "SFO", "ATL" }, { "ATL", "ICN" }, { "ATL", "SFO" } });

            exampleOutputList.Add(new string[] { "ICN", "JFK", "HND", "IAD" });
            exampleOutputList.Add(new string[] { "ICN", "ATL", "ICN", "SFO", "ATL", "SFO" });

            for (int i = 0; i < exampleInputList.Count; i++)
            {
                string[] exampleOutput = exampleOutputList[i];
                string[] myOutput = Solution(exampleInputList[i]);

                Console.WriteLine(i + "번째 결과 " + exampleOutput.SequenceEqual(myOutput));
            }
        }

        public string[] Solution(string[,] ticketArr)
        {
            return null;
        }
    }
}
