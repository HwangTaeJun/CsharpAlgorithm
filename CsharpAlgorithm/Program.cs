using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CsharpAlgorithm.Source;
using CsharpAlgorithm.Source.DataStructure;
using CsharpAlgorithm.Source.Algorithm.Programmers.Challenge;

public class Program
{
    static void Main(string[] args)
    {
        SealedSpell shortestMap = new SealedSpell();

        //shortestMap.Result(30, new string[] { "d", "e", "bb", "aa", "ae" } );
        shortestMap.solution(7388,new string[] { "gqk", "kdn", "jxj", "jxi", "fug", "jxg", "ewq", "len", "bhc" } );
        Console.ReadLine();
    }
}
