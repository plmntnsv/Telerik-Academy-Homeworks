using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._02.Moon_Gravity
{
    class Program
    {
        static void Main(string[] args)
        {
            float W = float.Parse(Console.ReadLine());
            float WOnMoon = W * 0.17f;
            //float WOnMoon = W * (17f / 100f);
            Console.WriteLine("{0:F3}",WOnMoon);
        }
    }
}
/*Description

The gravitational field of the Moon is approximately 17% of that on the Earth.

Write a program that calculates the weight of a man on the moon by a given weight W(as a floating-point number) on the Earth.
The weight W should be read from the console.
Input

The input will consist of a single line containing a single floating-point number - the weight W.
Output

Output a single floating-point value - how much a man with the weight W on Earth will weigh on the Moon. Output all values with exactly 3-digit precision after the floating point.
Hint: You can use the built-in .NET functionality
Constraints

The input weight will always be a valid floating-point number, always between 0 and 1000, exclusive.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
86	14.620
74.6	12.682
53.7	9.129
*/