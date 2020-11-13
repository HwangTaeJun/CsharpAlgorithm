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

        mySingleLinkedList.AddLast(1);
        mySingleLinkedList.AddLast(2);
        mySingleLinkedList.AddLast(3);

        var data = mySingleLinkedList.Find(3);
        data = mySingleLinkedList.Find(5);

        mySingleLinkedList.Remove(2);
        mySingleLinkedList.Remove(1);
        mySingleLinkedList.Remove(3);

        mySingleLinkedList.AddFirst(1);
        mySingleLinkedList.AddFirst(2);
        mySingleLinkedList.RemoveLast();
        mySingleLinkedList.RemoveLast();

        mySingleLinkedList.AddLast(1);
        mySingleLinkedList.AddLast(2);
        mySingleLinkedList.RemoveFirst();
        mySingleLinkedList.RemoveFirst();

        System.Console.ReadLine();
    }
}
