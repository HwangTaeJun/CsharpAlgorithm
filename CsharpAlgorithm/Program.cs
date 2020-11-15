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
        MyStack<int> myStack = new MyStack<int>();

        for (int i = 0; i < 5; i++)
        {
            myStack.Push(i);
        }

        Console.WriteLine(myStack.Pop());
        Console.WriteLine(myStack.Peek());
        Console.WriteLine(myStack.Pop());
        Console.WriteLine(myStack.Peek());

        for (int i = 0; i < 5; i++)
        {
            myStack.Push((i + 1)*10);
        }

        System.Console.ReadLine();
    }
}
