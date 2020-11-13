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

        myDoubleLinkedList.AddLast(1);
        myDoubleLinkedList.AddLast(2);
        myDoubleLinkedList.AddLast(3);


        myDoubleLinkedList.AddFirst(4);
        myDoubleLinkedList.AddFirst(5);

        System.Console.ReadLine();
    }
}
