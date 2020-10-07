using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsharpAlgorithm.Source;

public class Program
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int F { get { return G + H; } }
        public int G { get; private set; } // Start ~ Current
        public int H { get; private set; } // Current ~ End
        public Tile Parent { get; private set; }
        public void Execute(Tile parent, Tile endTile)
        {
            Parent = parent;
            G = CalcGValue(parent, this);
            int diffX = Math.Abs(endTile.X - X);
            int diffY = Math.Abs(endTile.Y - Y);
            H = (diffX + diffY) * 10;
        }
        public static int CalcGValue(Tile parent, Tile current)
        {
            int diffX = Math.Abs(parent.X - current.X);
            int diffY = Math.Abs(parent.Y - current.Y);
            int value = 10;
            if (diffX == 1 && diffY == 1)
            {
                value = 14;
            }
            return parent.G + value;
        }
    }

    public static int minimumDistance(int[,] area)
    {
        int result = -1; // distance
        int failResult = -1;
        int obstacle = 0;
        int target = 9;
        List<List<Tile>> tiles = new List<List<Tile>>();
        List<Tile> openList = new List<Tile>();
        List<Tile> closeList = new List<Tile>();
        List<Tile> path = new List<Tile>();
        Tile startTile = null;
        Tile targetTile = null;
        // Initial values
        for (int i = 0; i < area.GetLength(0); i++)
        {
            List<Tile> t = new List<Tile>();
            for (int j = 0; j < area.GetLength(1); j++)
            {
                Tile temp = new Tile();
                temp.X = i;
                temp.Y = j;
                t.Add(temp);
                if (i == area.GetLength(0) - 1 && j == area.GetLength(1) -1)
                {
                    targetTile = temp;
                }
            }
            tiles.Add(t);
        }
        // start (0, 0)
        startTile = tiles[0][0];
        openList.Add(startTile);
        if (targetTile == null)
        {
            // can not found target
            return failResult;
        }
        Tile currentTile = null;
        do
        {
            if (openList.Count == 0)
            {
                break;
            }
            currentTile = openList.OrderBy(o => o.F).First();
            openList.Remove(currentTile);
            closeList.Add(currentTile);
            if (currentTile == targetTile)
            {
                break;
            }
            for (int i = 0; i < area.GetLength(0); i++)
            {
                for (int j = 0; j < area.GetLength(1); j++)
                {
                    // 8 way
                    //bool near = (Math.Abs(currentTile.X - tiles[i][j].X) <= 1)
                    //         && (Math.Abs(currentTile.Y - tiles[i][j].Y) <= 1);
                    // 4 way
                    bool near = (Math.Abs(currentTile.X - tiles[i][j].X) <= 1)
                             && (Math.Abs(currentTile.Y - tiles[i][j].Y) <= 1)
                             && (currentTile.Y == tiles[i][j].Y || currentTile.X == tiles[i][j].X);
                    if (area[i, j] == obstacle
                     || closeList.Contains(tiles[i][j])
                     || (!near))
                    {
                        continue;
                    }
                    if (!openList.Contains(tiles[i][j]))
                    {
                        openList.Add(tiles[i][j]);
                        tiles[i][j].Execute(currentTile, targetTile);
                    }
                    else
                    {
                        if (Tile.CalcGValue(currentTile, tiles[i][j]) < tiles[i][j].G)
                        {
                            tiles[i][j].Execute(currentTile, targetTile);
                        }
                    }
                }
            }
        } while (currentTile != null);
        if (currentTile != targetTile)
        {
            // can not found root
            return failResult;
        }
        do
        {
            path.Add(currentTile);
            currentTile = currentTile.Parent;
        }
        while (currentTile != null);
        path.Reverse();
        result = path.Count;
        return result;
    }

    static void Main(string[] args)
    {
        //Example();
        //ShortestMap shortestMap = new ShortestMap();

        //FindNonRepeatedChar findNonRepeatedChar = new FindNonRepeatedChar();
        //RemoveSpecificChar removeSpecificChar = new RemoveSpecificChar();

        //ReverseWord reverseWord = new ReverseWord();
        NumberWordConversion numberWordConversion = new NumberWordConversion();

        System.Console.ReadLine();
    }

    public static void Example()
    {
        int[,] area = new int[,]
        {
            {1,0,1,1,1},
            {1,0,1,0,1},
            {1,0,1,1,1},
            {1,1,1,0,1},
            {0,0,0,0,9},
        };
        int num = minimumDistance(area);
        System.Console.WriteLine(num.ToString());
    }
}

