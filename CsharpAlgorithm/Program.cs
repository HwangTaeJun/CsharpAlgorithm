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
        Stack<int> tests = new Stack<int>();

        for (int i = 0; i < 5; i++)
        {
            myQueue.Enqueue(i);
        }

        Console.WriteLine(myQueue.Peek());

        Console.WriteLine(myQueue.Dequeue());
        Console.WriteLine(myQueue.Dequeue());

        myQueue.Enqueue(5);
        myQueue.Enqueue(6);

        Console.WriteLine(myQueue.Peek());

        for (int i = 1; i < 6; i++)
        {
            myQueue.Enqueue(i * 10);
        }

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(myQueue.Dequeue());
        }

        for (int i = 1; i < 10; i++)
        {
            myQueue.Enqueue(i * 100);
        }

        for (int i = 0; i < 10; i++)
        {
            myQueue.Dequeue();
        }

        for (int i = 0; i < 10; i++)
        {
            myQueue.Enqueue((i+1) * 1000);
        }

        System.Console.ReadLine();
    }
}
