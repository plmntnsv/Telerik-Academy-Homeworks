using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._04.Sub_string_in_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine().ToLower();
            string input = Console.ReadLine().ToLower();
            string[] splitted = input.Split(new[] { pattern },StringSplitOptions.None);
            Console.WriteLine(splitted.Length-1);
        }
    }
}
/*Description

Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

Input

On the first line you will receive a string - the pattern
On the second line you will receive a string - the text
Output

Print a number on a single line
The number of occurrences
Constraints

The length of the two strings will be <= 4096
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                                Output
in
We are living in an yellow submarine. We don't have anything else.      9
inside the submarine is very tight. So we are drinking all the day. 
We will move out of it in 5 days.	
*/
