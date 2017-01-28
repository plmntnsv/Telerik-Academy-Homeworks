using System;

namespace _04._03.Circle
{
    class Circle
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine()),
                perimeter = 2 * Math.PI * r,
                area = Math.PI * Math.Pow(r, 2);
            Console.WriteLine("{0:F2} {1:F2}",perimeter, area);

        }
    }
}
/*Description

Write a program that reads from the console the radius r of a circle and prints its perimeter and area, rounded and formatted with 2 digits after the decimal point.

Input

On the only line of the input you will receive the radius of the circle - r
Output

You should print one line only: the perimeter and the area of the circle, separated by a whitespace, and with 2 digits precision
Constraints

The radius r will always be a valid and positive real number
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
2	12.57 12.57
3.5	21.99 38.48
*/