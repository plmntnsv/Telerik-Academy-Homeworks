using System;

namespace _04._06.Quadratic_Equation
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine()),
                b = double.Parse(Console.ReadLine()),
                c = double.Parse(Console.ReadLine());
            if (Math.Pow(b, 2)-4*a*c < 0)
            {
                Console.WriteLine("no real roots");
            }
            else if (Math.Pow(b, 2) - 4 * a * c == 0)
            {
                double answer = (-b + (Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)))) / (2 * a);
                Console.WriteLine("{0:F2}",answer);
            }
            else
            {
                double answer = (-b + (Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)))) / (2 * a);
                double answer2 = (-b - (Math.Sqrt(Math.Pow(b, 2) - (4 * a * c)))) / (2 * a);
                if (answer > answer2)
                {
                    Console.WriteLine("{0:F2}\n{1:F2}",answer2,answer);
                    
                }
                else
                {
                    Console.WriteLine("{0:F2}\n{1:F2}", answer, answer2 );
                }
            }
        }
    }
}
/*Description

Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).

Input

On the first three lines, you will receive the coefficients a, b, and c, each on a separate line in the same order
Output

If two different real roots exist, print them on two separate lines
Print the smaller root on the first line
If only one real root exists, print it on the only output line
If no real root exists, print the string "no real roots"
The roots, should they exist, must be printed with precision exactly two digits after the floating point
Constraints

The input will always consist of valid real numbers in the range [-1000, 1000] and will follow the described format
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
2
5
-3	-3.00
0.50
-1
3
0	0.00
3.00
-0.5
4
-8	4.00
5
2
8	no real roots
*/