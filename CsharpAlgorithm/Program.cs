using System;
using System.Collections.Generic;
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
        MyQueue<int> myQueue = new MyQueue<int>();
        Queue<int> test = new Queue<int>();

        for (int i = 0; i < 5; i++)
        {
            myQueue.Enqueue(i);
            myDoubleLinkedList.AddLast(i);
            mySingleLinkedList.AddLast(i);
        }

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(myQueue.Peek() + "count : " +myQueue.Count);
            myQueue.Dequeue();
        }

        myDoubleLinkedList.Reverse();
        mySingleLinkedList.Reverse();

        System.Console.ReadLine();
    }
}
