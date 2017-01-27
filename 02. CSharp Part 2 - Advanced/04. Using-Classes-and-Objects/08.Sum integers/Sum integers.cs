﻿using System;
using System.Linq;

namespace _04._08.Sum_integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Sum findSum = new Sum(arr);
            Console.WriteLine(findSum.GetSum);
        }
    }
    class Sum
    {
        public Sum(params int[] array)
        {
            foreach (int num in array)
            {
                GetSum += num;
            }
        }
        public int GetSum { get; private set; }

    }
}
/*Description

You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Write a program that reads a string of positive integers separated by spaces and prints their sum.

Input

On the only line you will receive a string consisted of positive integers
Output

Print the sum of the integers
Constraints

Each number will be in the interval [ 1, 1000 ]
There will not be more than 1000 numbers
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
43 68 9 23 318	461
*/