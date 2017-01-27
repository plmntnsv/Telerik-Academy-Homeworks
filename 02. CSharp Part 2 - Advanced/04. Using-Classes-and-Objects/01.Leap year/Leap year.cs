﻿using System;

namespace _04._01.Leap_year
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isLeap = DateTime.IsLeapYear(int.Parse(Console.ReadLine()));
            Console.WriteLine(isLeap ? "Leap" : "Common");
        }
    }
}
/*Description

Write a program that reads a year from the console and checks whether it is a leap one.

Hint: Use System.DateTime.

Input

On the only line you will receive a number - the year
Output

Print "Leap" or "Common" on a single line depending on the year
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
2016	Leap
1996	Leap
1900	Common
2000	Leap
681	    Common
3400	Common
*/