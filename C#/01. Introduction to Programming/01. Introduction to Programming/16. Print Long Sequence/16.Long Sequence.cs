﻿using System;

namespace Long_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 2; i <= 1001; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(-i);
                }
            }
        }
    }
}
/*Description

Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …

You might need to learn how to use loops in C# (search in Internet).
Input

There is no input for this task.
Output

Output the first 1000 members of the sequence, each on a separate line.
2
-3
4
-5
6
...
Constraints

Time limit: 0.1s
Memory limit: 16MB
*/