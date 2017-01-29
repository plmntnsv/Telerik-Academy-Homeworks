using System;

namespace _05._05.Biggest_of_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine()),
                   b = double.Parse(Console.ReadLine()),
                   c = double.Parse(Console.ReadLine());

            if ((a >= b && b >= c) || (a >= c && c >= b))
            {
                Console.WriteLine(a);
            }
            else if ((b >= a && a >= c) || (b >= c && c >= a))
            {
                Console.WriteLine(b);
            }
            else if ((c >= a && a >= b) || (c >= b && b >= a))
            {
                Console.WriteLine(c);
            }
        }
    }

}
/*Description

Write a program that finds the biggest of three numbers that are read from the console.

Input

On the first three lines you will receive the three numbers, each on a separate line.
Output

On the only output line, write the biggest of the three numbers.
Constraints

The three numbers will always be valid floating-point numbers in the range [-200, 200].
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
4
4
4	4
-0.5
-10
0	0
*/
