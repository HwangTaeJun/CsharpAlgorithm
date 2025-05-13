using System.Collections.Generic;

namespace CsharpAlgorithm.Source.Algorithm.Programmers.DFS_BFS
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Count { get; set; } = 0;

        public Node(int x, int y, int count)
        {
            X = x;
            Y = y;
            Count = count;
        }
    }

    public class ShortestDistance
    {
        private int[,] _directions = new int[4, 2]
        {
            { 0, 1 }, // Right
            { 1, 0 }, // Down
            { 0, -1 }, // Left
            { -1, 0 } // Up
        };

        private int _x;
        private int _y;

        public int Solution(int[,] maps)
        {
            int answer = 0;
            
            _x = maps.GetLength(0);
            _y = maps.GetLength(1);

            var visited = new bool[_x, _y];

            visited[0, 0] = true;
            answer = Move(maps, visited, 0, 0, 1);

            return answer;
        }

        private int Move(int[,] maps, bool[,] visited, int x, int y, int count)
        {
            var queue = new Queue<Node>(); 

            queue.Enqueue(new Node(x, y, count));

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (_x - 1 == node.X && _y - 1 == node.Y)
                    return node.Count;

                for (int i = 0; i < 4; i++)
                {
                    var destX = node.X + _directions[i, 0];
                    var destY = node.Y + _directions[i, 1];

                    if (destX >= 0 && destY >= 0 && destX < _x && destY < _y && !visited[destX, destY] && maps[destX, destY] == 1)
                    {
                        visited[destX, destY] = true;
                        queue.Enqueue(new Node(destX, destY, node.Count + 1));
                    }
                }
            }

            return -1;
        }
    }
}