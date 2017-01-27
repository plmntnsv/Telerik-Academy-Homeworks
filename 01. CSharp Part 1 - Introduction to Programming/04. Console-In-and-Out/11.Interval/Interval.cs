using System;

namespace _04._11.Interval
{
    class Interval
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
                m = int.Parse(Console.ReadLine()),
                result = 0;
            for (int i = Math.Min(n, m)+1; i < Math.Max(n,m); )
            {
                if (i % 5 == 0)
                {
                    result++;
                    i += 5;
                }
                else
                {
                    i++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
/*Description

Write a program that reads two positive integer numbers N and M and prints how many numbers exist between them such that the reminder of the division by 5 is 0.

Input

On the first two lines you will receive two integers - N on the first and M on the second.
Output

Output a single value - the amount of numbers divisible by 5 without remainder.
Constraints

0 <= N <= M <= 2000
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output	Explanation
6
11	1	10
20
37	3	25, 30, 35
2
2	0	think why
*/