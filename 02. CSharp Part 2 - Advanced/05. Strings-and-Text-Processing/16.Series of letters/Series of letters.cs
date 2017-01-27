using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._16.Series_of_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            StringBuilder result = new StringBuilder();
            result.Append(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i-1])
                {
                    result.Append(input[i]);
                }
            }
            Console.WriteLine(result);
        }
    }
}
/*Description

Write a program that reads a string from the console and replaces all 
series of consecutive identical letters with a single one.

Input

On the only input line you will receive a string
Output

Print the string without consecutive identical letters
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                Output
aaaaabbbbbcdddeeeedssaa	abcdedsa
*/