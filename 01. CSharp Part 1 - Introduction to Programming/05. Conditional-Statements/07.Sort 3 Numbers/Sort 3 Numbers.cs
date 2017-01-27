using System;

namespace _05._07.Sort_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine()),
                   b = double.Parse(Console.ReadLine()),
                   c = double.Parse(Console.ReadLine());

            if (a >= b && a >= c)
            {
                Console.Write("{0} ", a);
                if (b >= c)
                {
                    Console.Write("{0} {1}", b, c);
                }
                else if (c >= b)
                {
                    Console.Write("{0} {1}", c, b);
                }
            }
            else if (b >= a && b >= c)
            {
                Console.Write("{0} ", b);
                if (a >= c)
                {
                    Console.Write("{0} {1}", a, c);
                }
                else if (c >= a)
                {
                    Console.Write("{0} {1}", c, a);
                }
            }
            else
            {
                Console.Write("{0} ", c);
                if (a >= b)
                {
                    Console.Write("{0} {1}", a, b);
                }
                else if (b >= a)
                {
                    Console.Write("{0} {1}", b, a);
                }
            }
            
        }
    }
}

/*Description

Write a program that enters 3 real numbers and prints them sorted in descending order.

Use nested if statements.
Don’t use arrays and the built-in sorting functionality.
Input

On the first three lines, you will receive the three numbers, each on a separate line.
Output

Output a single line on the console - the sorted numbers, separated by a whitespace
Constraints

The three numbers will always be valid integer numbers in the range [-1000, 1000]
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
3
2
1	3 2 1
-5
3
-5	3 -5 -5
1
2
20	20 2 1
*/