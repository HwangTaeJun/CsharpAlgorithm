using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CsharpAlgorithm.Source;
using CsharpAlgorithm.Source.DataStructure;

public class Test
{
    public int num = 0;
    public Test(int q)
    {
        num = q;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        MyPriorityQueue<PriorityData> myPriorityQueue = new MyPriorityQueue<PriorityData>();
        Random random = new Random();
        int[] priorityArr = new int[10];

        for (int i = 0; i < 10; i++)
        {
            string data = i.ToString();
            int priority = random.Next(0, 15);
            priorityArr[i] = priority;

            myPriorityQueue.Enqueue(new PriorityData(data,priorityArr[i]));
        }

        Console.ReadLine();
    }
}
