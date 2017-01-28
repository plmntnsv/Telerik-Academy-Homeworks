using System;
using System.Numerics;

namespace _01._10.N_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(FactorialResult(n));
        }
        static BigInteger FactorialResult(int n)
        {
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
/*Description

Write a method that multiplies a number represented as an array of digits by a given integer number. Write a program to calculate N!.

Input

On the first line you will receive the number N
Output

Print N!
Constraints

0 <= N <= 100
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
5	120
*/