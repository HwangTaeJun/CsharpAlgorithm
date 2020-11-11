using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CsharpAlgorithm.Source;

public class Program
{
    static void Main(string[] args)
    {
        MySingleLinkedList<int> mySingleLinkedList = new MySingleLinkedList<int>();

        for (int i = 0; i < 10; i++)
        {
            if(i <= 5)
            {
                mySingleLinkedList.AddLast(i);
            }
            else
            {
                mySingleLinkedList.AddFirst(i);
            }
        }

        System.Console.ReadLine();
    }
}
