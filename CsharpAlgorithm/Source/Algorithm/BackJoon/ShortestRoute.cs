using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpAlgorithm.Source
{
    public class Vertex : IComparable<Vertex>
    {
        public int index;
        public int distance;

        public Vertex(int index, int distance)
        {
            this.index = index;
            this.distance = distance;
        }

        public int CompareTo(Vertex target)
        {
            return this.distance.CompareTo(target.distance);
        }
    }

    public class Edge
    {
        public int destIndex;
        public int weight;

        public Edge(int destIndex, int weight)
        {
            this.destIndex = destIndex;
            this.weight = weight;
        }
    }

    /// <summary>
    /// 최단경로 https://www.acmicpc.net/problem/1753
    /// </summary>
    class ShortestRoute
    {
        private List<Edge>[] edgeArr = null;
        private Vertex[] vertexArr = null;

        private string inf = "INF";

        private int vertexCount = 0;
        private int edgeCount = 0;

        private int startIndex = 0;

        public ShortestRoute(bool isSubmit = false)
        {
            if (isSubmit)
            {
                int[] inputData = Console.ReadLine().Split(' ').Select((e) => int.Parse(e)).ToArray();

                vertexCount = inputData[0];
                edgeCount = inputData[1];

                startIndex = int.Parse(Console.ReadLine());

                Init();

                for (int i = 0; i < edgeCount; i++)
                {
                    var input = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

                    edgeArr[input[0]].Add(new Edge(input[1], input[2]));
                }

            }
            else
            {
                vertexCount = 5;
                edgeCount = 6;
                startIndex = 1;

                Init();

                edgeArr[5].Add(new Edge(1,1));
                edgeArr[1].Add(new Edge(2,2));
                edgeArr[1].Add(new Edge(3,3));
                edgeArr[2].Add(new Edge(3,4));
                edgeArr[2].Add(new Edge(4,5));
                edgeArr[3].Add(new Edge(4,6));
            }

            Solution();
        }

        private void Init()
        {
            edgeArr = new List<Edge>[vertexCount + 1];
            vertexArr = new Vertex[vertexCount + 1];

            for (int i = 0; i < vertexCount + 1; i++)
            {
                edgeArr[i] = new List<Edge>();
                vertexArr[i] = new Vertex(i, int.MaxValue);
            }
            
            vertexArr[startIndex].distance = 0;
        }

        public void Solution()
        {
            var priorityqueue = new PriorityQueue<Vertex>();
            priorityqueue.Enqueue(vertexArr[startIndex]);

            while (!priorityqueue.IsEmpty())
            {
                var selectedVertex = priorityqueue.Dequeue();

                if (selectedVertex.distance > vertexArr[selectedVertex.index].distance)
                    continue;

                foreach (var edge in edgeArr[selectedVertex.index])
                {
                    if (vertexArr[edge.destIndex].distance > selectedVertex.distance + edge.weight)
                    {
                        vertexArr[edge.destIndex].distance = selectedVertex.distance + edge.weight;
                        priorityqueue.Enqueue(new Vertex(edge.destIndex, vertexArr[edge.destIndex].distance));
                    }
                }
            }

            for (int i = 1; i < vertexCount + 1; i++)
            {
                if (vertexArr[i].distance == int.MaxValue)
                {
                    Console.WriteLine(inf);
                }
                else
                {
                    Console.WriteLine(vertexArr[i].distance);
                }
            }
        }
    }
}
