using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpAlgorithm.Source
{
    class Route : IComparable<Route>
    {
        public string StartPoint { get; private set; } = null;
        public string DestPoint { get; private set; } = null;

        public Route(string startPoint, string destPoint)
        {
            StartPoint = startPoint;
            DestPoint = destPoint;
        }

        public int CompareTo(Route other)
        {
            return this.DestPoint.CompareTo(other.DestPoint);
        }
    }

    /// <summary>
    /// 여행경로 https://programmers.co.kr/learn/courses/30/lessons/43164
    /// </summary>
    class TravelRoute
    {
        private List<Route> routeList = null;
        private Stack<string> resultStack = null;

        private bool[] visitedArr = null;

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
            Init(ticketArr);

            DFS("ICN");

            resultStack.Push("ICN");

            return resultStack.ToArray();
        }

        private void Init(string[,] ticketArr)
        {
            int count = ticketArr.GetLength(0);

            resultStack = new Stack<string>();
            routeList = new List<Route>(count);
            visitedArr = new bool[count];

            for (int i = 0; i < count; i++)
            {
                routeList.Add(new Route(ticketArr[i, 0], ticketArr[i, 1]));
            }

            routeList.Sort();
        }

        private void DFS(string startPoint)
        {
            int count = routeList.Count;

            for (int i = 0; i < count; i++)
            {
                if(!visitedArr[i] && startPoint == routeList[i].StartPoint)
                {
                    visitedArr[i] = true;
                    DFS(routeList[i].DestPoint);
                    resultStack.Push(routeList[i].DestPoint);
                }
            }
        }
    }
}
