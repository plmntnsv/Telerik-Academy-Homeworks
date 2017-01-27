﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._01.Odd_or_Even
{
    class Program
    {
        static void Main(string[] args)
        {
            int InputNum = int.Parse(Console.ReadLine());
            if (InputNum % 2 == 0)
            {
                Console.WriteLine("even {0}",InputNum);
            }
            else
            {
                Console.WriteLine("odd {0}", InputNum);
            }
        }
    }
}
/*Odd or Even
Description

Write a program that reads an integer from the console, uses an expression to check if given integer is odd or even, and prints "even NUMBER" or "odd NUMBER", where you should print the input number's value instead of NUMBER.

Input

On the single input line you will receive an integer number.
Output

Output a single line - if the number is even, output even, followed by a whitespace and the value of the number. Otherwise, print odd, again followed by a whitespace and the number's value. See the sample tests.
Constraints

The input number will always be a valid integer number.
The input number will always be in the range [-30, 30].
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
3	odd 3
2	even 2
-2	even -2
-1	odd -1
0	even 0
*/