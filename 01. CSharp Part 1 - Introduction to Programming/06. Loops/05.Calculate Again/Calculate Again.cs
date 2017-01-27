﻿using System;
using System.Numerics;

namespace _06._05.Calculate_Again
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine()),
                  x = BigInteger.Parse(Console.ReadLine()),
                  rotationN = 1,
                  rotationX = 1,
                  factorialN = 1,
                  factorialX = 1,
                  factor = 1;

            while (rotationN <= n || rotationX <=x)
            {
                if (rotationN <= n)
                {
                    factorialN *= factor;
                    rotationN++;
                }
                if (rotationX <= x)
                {
                    factorialX *= factor;
                    rotationX++;
                }
                factor++;
            }
            Console.WriteLine(factorialN / factorialX);
        }
    }
}
/*Description

Write a program that calculates N! / K! for given N and K.

Use only one loop.
Input

On the first line, there will be only one number - N
On the second line, there will be only one number - K
Output

Output a single line, consisting of the result from the calculation described above.
Constraints

1 < K < N < 100
Hint: overflow is possible
N and K will always be valid integer numbers
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
5
2	    60
6
5	    6
8
3	    6720
*/
