using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CsharpAlgorithm.Source;
using CsharpAlgorithm.Source.DataStructure;

public class Program
{
    static void Main(string[] args)
    {
        MyHashTable<string, int> myHashTable = new MyHashTable<string, int>();
        Dictionary<string, int> dict = new Dictionary<string, int>(3);

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for (int i = 0; i < 102400; i++)
        {
            myHashTable.Add(i.ToString(),i);
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();

        for (int i = 0; i < 102400; i++)
        {
            dict.Add(i.ToString(), i);
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();

        for (int i = 0; i < 30000; i++)
        {
            myHashTable.Remove(i.ToString());
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();

        for (int i = 0; i < 30000; i++)
        {
            dict.Remove(i.ToString());
        }

        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);

        Console.ReadLine();
    }
}
