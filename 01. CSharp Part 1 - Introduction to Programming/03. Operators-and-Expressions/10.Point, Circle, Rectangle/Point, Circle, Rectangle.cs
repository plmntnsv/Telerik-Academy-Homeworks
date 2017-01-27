using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._10.Point__Circle__Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine()),
                y = double.Parse(Console.ReadLine());
            bool inCircle = Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 1.5d,
                inRectangle = (y <= 1 && y >= -1) && (x <= 5 && x >= -1);
            if (inCircle && inRectangle)
            {
                Console.WriteLine("inside circle inside rectangle");
            }
            else if(inCircle != true && inRectangle)
            {
                Console.WriteLine("outside circle inside rectangle");
            }
            else if(inCircle && inRectangle != true)
            {
                Console.WriteLine("inside circle outside rectangle");
            }
            else
            {
                Console.WriteLine("outside circle outside rectangle");
            }
            //Console.WriteLine((isInCircle ? "inside circle" : "outside circle") + " " + (isInRectangle ? "inside rectangle" : "outside rectangle"));
        }
    }
}
/*Description

Write a program that reads a pair of coordinates x and y and uses an expression to checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).

Input

You will receive the pair of coordinates on the two lines of the input - on the first line you will find x, and on the second - y.
Output

Print inside circle if the point is inside the circle and outside circle if it's outside. Then print a single whitespace followed by inside rectangle if the point is inside the rectangle and outside rectangle otherwise. See the sample tests for a visual description.
Constraints

The coordinates x and y will always be valid floating-point numbers in the range [-1000, 1000].
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
2.5
2	outside circle outside rectangle
0
1	inside circle inside rectangle
2.5
1	inside circle inside rectangle
1
2	inside circle outside rectangle
*/