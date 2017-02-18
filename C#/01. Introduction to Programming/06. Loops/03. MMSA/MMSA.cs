using System;

namespace _06._03.MMSA
{
    class MMSA
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine()),
                min = double.MaxValue, max = double.MinValue, sum = 0, avg = 0;
            for (double i = 1; i <= n; i++)
            {
                double m = double.Parse(Console.ReadLine());
                if (m > max)
                {
                    max = m;
                }
                if (m < min)
                {
                    min = m;
                }
                sum += m;
                avg = sum / n;
            }
            Console.WriteLine("min={0:F2}\nmax={1:F2}\nsum={2:F2}\navg={3:F2}", min, max, sum, avg);
        }
    }
}
/*Description

Write a program that reads from the console a sequence of N integer numbers and returns the minimal, 
the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).

The input starts by the number N (alone in a line) followed by N lines, each holding an integer number.
The output is like in the examples below.
Input

On the first line, you will receive the number N.
On each of the next N lines, you will receive a single integer number.
Output

You output must always consist of exactly 4 lines - the minimal element on the first line, 
the maximal on the second, the sum on the third and the average on the fourth, in the following format:
min=3.00
max=6.00
sum=9.00
avg=4.50
Constraints

1 <= N <= 1000
All numbers will be valid integer numbers that will be in the range [-10000, 10000]
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
3
2
5
1	    min=1.00
        max=5.00
        sum=8.00
        avg=2.67
3
2
-1
4	    min=-1.00
        max=4.00
        sum=5.00
        avg=1.67
*/