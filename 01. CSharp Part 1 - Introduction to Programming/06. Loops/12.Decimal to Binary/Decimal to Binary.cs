﻿using System;

namespace _06._12.Decimal_to_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            long decNum = long.Parse(Console.ReadLine());
            string result = "";

            while (decNum > 0)
            {
                if (decNum % 2 == 0)
                {
                    result = '0' + result;
                    decNum /= 2;
                }
                else
                {
                    result = '1' + result;
                    decNum /= 2;
                }
            }
            Console.WriteLine(result);
        }
    }
}
/*Description

Using loops write a program that converts an integer number to its binary representation.

The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality.
Input

On the only input line you will receive the decimal integer number.
Output

Output a single string - the representation of the input decimal number in it's binary representation.
Constraints

All numbers will always be valid 32-bit integers.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
0	        0
3	        11
43691	    1010101010101011
236476736	1110000110000101100101000000
*/