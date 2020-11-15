using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    /// <summary>
    /// 가장 먼 노드 https://programmers.co.kr/learn/courses/30/lessons/49189
    /// </summary>
    class FarthestRoute
    {
        private Dictionary<int, Vertex> vertexDict = new Dictionary<int, Vertex>();
        private Dictionary<int, List<Edge>> edgeListDict = new Dictionary<int, List<Edge>>();

        private int vertexCount = 0;
        private int edgeCount = 0;
        private int startIndex = 0;

        public FarthestRoute()
        {
            Console.WriteLine(Solution(6, new int[7, 2] { { 3, 6 }, { 4, 3 }, { 3, 2 }, { 1, 3 }, { 1, 2 }, { 2, 4 }, { 5, 2 } }));
            Console.WriteLine(Solution(9, new int[8, 2] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 5 }, { 1, 6 }, { 1, 7 }, { 1, 8 }, { 1, 9 } }));
            Console.WriteLine(Solution(12, new int[13, 2] { { 1, 2 }, { 1, 3 }, { 1, 4 }, { 1, 12 }, { 2, 6 }, { 12, 6 }, { 2, 5 }, { 6, 7 }, { 6, 8 }, { 5, 9 }, { 10, 4}, { 5, 7 }, { 5, 11 } }));
        }

        public int Solution(int n, int[,] edge)
        {
            vertexCount = n;
            startIndex = 1;
            edgeCount = edge.GetLength(0);

            for (int i = 1; i < vertexCount + 1; i++)
            {
                edgeListDict[i] = new List<Edge>();
                vertexDict[i] = new Vertex(i, int.MinValue);
            }

            vertexDict[startIndex].distance = 0;

            for (int i = 0; i < edgeCount; i++)
            {
                int vertexIndex = edge[i, 0];
                int vertexIndex2 = edge[i, 1];

                edgeListDict[vertexIndex].Add(new Edge(vertexIndex2, 1));
                edgeListDict[vertexIndex2].Add(new Edge(vertexIndex, 1));
            }

            var priorityqueue = new PriorityQueue<Vertex>();

            priorityqueue.Enqueue(vertexDict[startIndex]);

            while (!priorityqueue.IsEmpty())
            {
                var curVertex = priorityqueue.Dequeue();

                int curIndex = curVertex.index;

                if (curVertex.distance < vertexDict[curIndex].distance)
                    continue;

                foreach (var edgeData in edgeListDict[curIndex])
                {
                    if (vertexDict[edgeData.destIndex].distance == int.MinValue)
                    {
                        if (curVertex.distance < curVertex.distance + edgeData.weight)
                        {
                            vertexDict[edgeData.destIndex].distance = curVertex.distance + edgeData.weight;
                            priorityqueue.Enqueue(new Vertex(edgeData.destIndex, curVertex.distance + edgeData.weight));
                        }
                    }
                }
            }

            int farDistance = -1;
            int farthestCount = 0;

            foreach (var vertex in vertexDict)
            {
                int curDistance = vertex.Value.distance;

                if (farDistance < curDistance)
                {
                    farDistance = curDistance;
                    farthestCount = 1;
                }
                else if (farDistance == curDistance)
                {
                    farthestCount++;
                }
            }

            return farthestCount;
        }
    }
}
