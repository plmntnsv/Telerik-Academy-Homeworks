using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._10.Unicode_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            foreach (char letter in input)
            {
                Console.Write("\\u" + ((int)letter).ToString("X4"));
            }
        }
    }
}
/*Description

Write a program that converts a string to a sequence of C# Unicode character literals.

Input

On the only input line you will receive a string
Output

Print the string in C# Unicode character literals on a single line
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
Hi!	    \u0048\u0069\u0021
*/