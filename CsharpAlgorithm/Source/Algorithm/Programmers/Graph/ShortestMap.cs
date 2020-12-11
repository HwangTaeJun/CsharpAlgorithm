using System;
using System.Collections.Generic;

namespace CsharpAlgorithm.Source
{
    public class Tile : IComparable<Tile>
    {
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;

        public int F { get; private set; } = 0;
        public int G { get; private set; } = 0;
        public int H { get; private set; } = 0;

        public int Index { get; private set; } = 0;

        public bool IsOpen { get; set; } = false;
        public bool IsClosed { get; set; } = false;

        public Tile ParentTile { get; private set; } = null;

        public Tile(int x, int y, int width, int destX, int destY)
        {
            X = x;
            Y = y;

            Index = X + (Y * width);

            int distanceX = Math.Abs(destX - X);
            int distanceY = Math.Abs(destY - Y);

            H = (distanceX + distanceY) * 10;
        }

        public int CompareTo(Tile target)
        {
            return this.F.CompareTo(target.F);
        }

        public void UpdateTile(Tile parent, bool is8thDir = true)
        {
            ParentTile = parent;

            int distanceX = Math.Abs(parent.X - X);
            int distanceY = Math.Abs(parent.Y - Y);

            if (is8thDir && distanceX == 1 && distanceY == 1)
            {
                G = parent.G + 14;
            }
            else
            {
                G = parent.G + 10;
            }

            F = G + H;
        }

        public void UpdateGCost(int g)
        {
            G = g;
        }
    }

    /// <summary>
    /// 게임 맵 최단거리 https://programmers.co.kr/learn/courses/30/lessons/1844
    /// </summary>
    class ShortestMap
    {
        private MyPriorityQueue<Tile> priorityTileQueue = null;
        private List<Tile> tileList = null;

        private int[,] dirArr = null;

        private int width = 0;
        private int height = 0;

        private int destX = 0;
        private int destY = 0;

        private int dirCount = 0;

        private bool is8thDir = false;

        public ShortestMap(bool is8thDir = false)
        {
            List<int[,]> inputMapList = new List<int[,]>();
            List<int> resultList = new List<int>() { 11, -1 };

            inputMapList.Add(new int[,]
            {
                {1,0,1,1,1},
                {1,0,1,0,1},
                {1,0,1,1,1},
                {1,1,1,0,1},
                {0,0,0,0,1}
            });

            inputMapList.Add(new int[,]
            {
                {1,0,1,1,1},
                {1,0,1,0,1},
                {1,0,1,1,1},
                {1,1,1,0,0},
                {0,0,0,0,1}
            });

            this.is8thDir = is8thDir;

            for (int i = 0; i < inputMapList.Count; i++)
            {
                Console.WriteLine(Solution(inputMapList[i]));
            }
        }

        public int Solution(int[,] mapArr)
        {
            if (is8thDir)
            {
                dirArr = new int[,] { { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1, 0 }, { -1, -1 } };
            }
            else
            {
                dirArr = new int[,] { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };
            }

            dirCount = dirArr.GetLength(0);

            int result = 0;

            priorityTileQueue = new MyPriorityQueue<Tile>();
            tileList = new List<Tile>();

            height = mapArr.GetLength(0);
            width = mapArr.GetLength(1);

            destX = width - 1;
            destY = height - 1;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tileList.Add(new Tile(j, i, width, destX, destY));
                }
            }

            Tile startTile = tileList[0];

            priorityTileQueue.Enqueue(startTile);

            Tile pathTile = FindShortestTile(mapArr);

            //경로가 없을 때
            if (pathTile == null)
            {
                return -1;
            }

            string path = "";

            Stack<string> pathStack = new Stack<string>();

            while (pathTile != null)
            {
                result++;
                pathStack.Push(pathTile.Index.ToString() + "-");
                pathTile = pathTile.ParentTile;
            }

            int count = pathStack.Count;

            for (int i = 0; i < count; i++)
            {
                path += pathStack.Pop();
            }

            Console.WriteLine(path);

            return result;
        }

        private Tile FindShortestTile(int[,] mapArr)
        {
            Tile curTile = null;

            while (priorityTileQueue.Count > 0)
            {
                curTile = priorityTileQueue.Dequeue();

                if (curTile.X == destX && curTile.Y == destY)
                {
                    return curTile;
                }

                curTile.IsOpen = false;
                curTile.IsClosed = true;

                for (int i = 0; i < dirCount; i++)
                {
                    int targetX = curTile.X + dirArr[i, 0];
                    int targetY = curTile.Y + dirArr[i, 1];

                    int index = targetY * width + targetX;

                    if (targetX >= 0 && targetX < width && targetY >= 0 && targetY < height)
                    {
                        if (mapArr[targetY, targetX] == 1)
                        {
                            if (!tileList[index].IsClosed)
                            {
                                Tile targetTile = tileList[index];

                                if (targetTile.IsOpen)
                                {
                                    int targetNewGCost = curTile.G + GetGCost(curTile.X, curTile.Y, targetX, targetY);

                                    //특정 노드를 갈 수 있는 최적의 경로를 확인
                                    if (targetNewGCost < targetTile.G)
                                    {
                                        targetTile.UpdateTile(curTile, is8thDir);
                                    }
                                }
                                else
                                {
                                    targetTile.UpdateTile(curTile, is8thDir);
                                    targetTile.IsOpen = true;

                                    priorityTileQueue.Enqueue(targetTile);
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }

        private int GetGCost(int x, int y, int targetX, int targetY)
        {
            int distanceX = Math.Abs(x - targetX);
            int distanceY = Math.Abs(y - targetY);

            if (is8thDir && distanceX == 1 && distanceY == 1)
            {
                return 14;
            }
            else
            {
                return 10;
            }
        }
    }
}
