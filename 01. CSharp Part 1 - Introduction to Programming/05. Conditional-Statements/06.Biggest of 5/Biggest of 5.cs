using System;

namespace _05._06.Biggest_of_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine()),
                   b = double.Parse(Console.ReadLine()),
                   c = double.Parse(Console.ReadLine()),
                   d = double.Parse(Console.ReadLine()),
                   e = double.Parse(Console.ReadLine());
            if (a >= b && a >= c && a >= d && a >= e)
            {
                Console.WriteLine(a);
            }
            else if (b >= a && b >= c && b >= d && b >= e)
            {
                Console.WriteLine(b);
            }
            else if (c >= a && c >= b && c >= d && c >= e)
            {
                Console.WriteLine(c);
            }
            else if (d >= a && d >= b && d >= c && d >= e)
            {
                Console.WriteLine(d);
            }
            else
            {
                Console.WriteLine(e);
            }
        }
    }
}
/*Description

Write a program that finds the biggest of 5 numbers that are read from the console, using only 5 if statements.

Input

On the first 5 lines you will receive the 5 numbers, each on a separate line
Output

On the only output line, write the biggest of the 5 numbers
Constraints

The 5 numbers will always be valid floating-point numbers in the range [-200, 200]
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
4
4
4
4
4	4
-0.5
-10
0
-1
-3	0
*/
