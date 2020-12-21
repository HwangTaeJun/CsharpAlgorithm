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
        int[] dataArr = new int[] { 5, 2, 1, 0, 4, 55, 234, 12, 35, 23, 6, 7, 4, 434, 764 };

        MySort mySort = new MySort();

        mySort.QuickSort(dataArr);
        mySort.InsertSort(dataArr);
        mySort.BubbleSort(dataArr);
        mySort.SelectSort(dataArr);

        Console.ReadLine();
    }
}
