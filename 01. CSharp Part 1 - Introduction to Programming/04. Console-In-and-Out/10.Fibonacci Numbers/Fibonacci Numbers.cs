using System;

namespace _04._10.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine()),
                num1 = 0, num2 = 1;
            if (n == 1)
            {
                Console.WriteLine("0");
            }
            else if (n == 2)
            {
                Console.WriteLine("0, 1");
            }
            else
            {
                Console.Write("0, 1");
                for (int i = 2; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        num1 += num2;
                        Console.Write(", {0}", num1);
                    }
                    else
                    {
                        num2 += num1;
                        Console.Write(", {0}", num2);
                    }
                }
            }
            
        }
    }
}
/*Description

Write a program that reads a number N and prints on the console the first N members of the Fibonacci sequence (at a single line, separated by comma and space - ", ") : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

Input

On the only line you will receive the number N
Output

On the only line you should print the first N numbers of the sequence, separated by ", " (comma and space)
Constraints

1 <= N <= 50
N will always be a valid positive integer number
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
1	0
3	0, 1, 1
10	0, 1, 1, 2, 3, 5, 8, 13, 21, 34
*/