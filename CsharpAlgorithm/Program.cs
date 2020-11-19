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
        PriorityQueue<PriorityData> priorityQueue = new PriorityQueue<PriorityData>();
        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();

        string[] dataArr = new string[100000];
        int[] priorityArr = new int[100000];

        for (int i = 0; i < priorityArr.Length; i++)
        {
            int priority = random.Next(0, priorityArr.Length * 2);

            priorityArr[i] = priority;
            dataArr[i] = i.ToString();
        }

        for (int i = 0; i < priorityArr.Length; i++)
        {
            myPriorityQueue.Enqueue(new PriorityData(dataArr[i], priorityArr[i]));
            priorityQueue.Enqueue(new PriorityData(dataArr[i], priorityArr[i]));

            var myData = myPriorityQueue.Peek();
            var data = priorityQueue.Peek();

            if (myData.data != data.data)
            {
                Console.WriteLine("data가 다르다" + myData.data + ", " + data.data);
            }

            if (myData.priority != data.priority)
            {
                Console.WriteLine("priority 다르다" + myData.priority + ", " + data.priority);
            }
        }

        for (int i = 0; i < priorityArr.Length; i++)
        {
            var myData = myPriorityQueue.Dequeue();
            var data = priorityQueue.Dequeue();

            if (myData.data != data.data)
            {
                Console.WriteLine(" Dequeue data가 다르다" + myData.data + ", " + data.data);
            }

            if (myData.priority != data.priority)
            {
                Console.WriteLine("Dequeue priority 다르다" + myData.priority + ", " + data.priority);
            }
        }

        Console.ReadLine();
    }
}
