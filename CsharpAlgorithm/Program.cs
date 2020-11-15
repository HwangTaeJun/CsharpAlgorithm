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

        for (int i = 0; i < 1024; i++)
        {
            myHashTable.Add(i.ToString(), i);
        }

        Console.ReadLine();
    }
}
