using System;

namespace _05._04.Multiplication_sign
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine()),
                   b = double.Parse(Console.ReadLine()),
                   c = double.Parse(Console.ReadLine());
            if (a == 0 || b == 0 || c == 0)
            {
                Console.WriteLine("0");
            }
            else if (a < 0 || b < 0 || c < 0)
            {
                if ((a < 0 && (b > 0 && c > 0)) || (b < 0 && (a > 0 && c > 0)) || (c < 0 && (a > 0 && b > 0)) || (a < 0 && b < 0 && c < 0))
                {
                    Console.WriteLine("-");
                }
                else 
                {
                    Console.WriteLine("+");
                }
            }
            else
            {
                Console.WriteLine("+");
            }

        }
    }
}
/*Description

Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it.

Use a sequence of if operators.
Input

On the first three lines, you will receive the three numbers, each on a separate line
Output

Output a single line - the sign of the product of the three numbers
Constraints

The input will always consist of valid floating-point numbers
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
2
5
2	+
2
5
-2	-
-0.5
0
-2	0
*/
