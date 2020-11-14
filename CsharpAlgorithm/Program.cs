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
        MyDoubleLinkedList<int> myDoubleLinkedList = new MyDoubleLinkedList<int>();
        MySingleLinkedList<int> mySingleLinkedList = new MySingleLinkedList<int>();

        for (int i = 0; i < 5; i++)
        {
            myDoubleLinkedList.AddLast(i);
            mySingleLinkedList.AddLast(i);
        }

        myDoubleLinkedList.Reverse();
        mySingleLinkedList.Reverse();

        System.Console.ReadLine();
    }
}
