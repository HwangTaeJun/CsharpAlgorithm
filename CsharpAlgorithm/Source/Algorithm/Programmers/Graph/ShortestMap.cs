using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpAlgorithm.Source
{
    public class Tile : IComparable<Tile>
    {
        public int x = 0;
        public int y = 0;

        public int index = 0;

        public int f = 0;
        public int g = 0;
        public int h = 0;

        public Tile parentTile = null;

        public Tile(int x, int y, int index, int destX, int destY)
        {
            this.x = x;
            this.y = y;

            this.index = index;

            h = (Math.Abs(destX - x) + Math.Abs(destY - y)) * 10;
        }

        public int CompareTo(Tile target)
        {
            return this.f.CompareTo(target.f);
        }

        public void SetParentTile(Tile parent, bool is8thDir)
        {
            parentTile = parent;

            int diffX = Math.Abs(parent.x - x);
            int diffY = Math.Abs(parent.y - y);

            if (is8thDir && diffX == 1 && diffY == 1)
            {
                g = parent.g + 14;
            }
            else
            {
                g = parent.g + 10;
            }

            f = g + h;
        }

    }

    /// <summary>
    /// 게임 맵 최단거리 https://programmers.co.kr/learn/courses/30/lessons/1844
    /// </summary>
    class ShortestMap
    {
        private Dictionary<int, Tile> tileDict = new Dictionary<int, Tile>();
        private Dictionary<int, Tile> openTileDict = new Dictionary<int, Tile>();
        private Dictionary<int, Tile> closeTileDict = new Dictionary<int, Tile>();

        private Dictionary<int, bool> openTileIndexDict = new Dictionary<int, bool>();

        private PriorityQueue<Tile> priorityTileQueue = new PriorityQueue<Tile>();

        private int[,] dirArr = null;

        private int width = 0;
        private int height = 0;

        private int destX = 0;
        private int destY = 0;

        private int dirCount = 0;

        private bool is8thDir = false;

        public ShortestMap(bool is8thDir = false)
        { 
            int[,] test = new int[,] { { 1, 2, 3, 4, 5 }, 
                                        { 6, 7, 8, 9, 10 } };
            int tn = test[0, 1];
            int tn2 = test[1, 2];

            int[,] area = new int[,] {

                {1,0,1,1,1},
                {1,0,1,0,1},
                {1,0,1,1,1},
                {1,1,1,0,1},
                {0,0,0,0,1},
            };

            this.is8thDir = is8thDir;

            if (is8thDir)
            {
                dirArr = new int[,] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { -1, 0 }, { 1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 } };
            }
            else
            {
                dirArr = new int[,] { { 0, 1 }, { -1, 0 }, { 1, 0 }, { 0, -1 } };
            }

            dirCount = dirArr.GetLength(0);

            Console.WriteLine(Solution(area));
        }

        public int Solution(int[,] maps)
        {
            int movedCount = 0;

            width = maps.GetLength(0);
            height = maps.GetLength(1);

            destX = width - 1;
            destY = height - 1;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (maps[i, j] == 1)
                    {
                        int index = (i * width) + j;
                        Tile tile = new Tile(i, j, index, destX, destY);

                        tileDict[index] = tile;
                    }
                }
            }

            Tile startTile = tileDict[0];

            UpdateOpenTile(startTile.x, startTile.y);

            closeTileDict[startTile.index] = startTile;

            return movedCount;
        }

        private void UpdateOpenTile(int x, int y)
        {
            for (int i = 0; i < dirCount; i++)
            {
                int adjacentX = x + dirArr[i, 0];
                int adjacentY = y + dirArr[i, 1];

                int adjacentIndex = adjacentX * width + adjacentY;

                if (!openTileDict.ContainsKey(adjacentIndex) && tileDict.ContainsKey(adjacentIndex))
                {
                    if (adjacentX >= 0 && adjacentX <= width)
                    {
                        if (adjacentY >= 0 && adjacentY <= height)
                        {
                            Tile openTile = new Tile(adjacentX, adjacentY, adjacentIndex, destX, destY);

                            openTileIndexDict[adjacentIndex] = true;
                            priorityTileQueue.Enqueue(openTile);
                        }
                    }
                }
            }
        }
    }
}
