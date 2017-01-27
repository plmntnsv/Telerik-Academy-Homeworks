using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._03.Divide_by_7_and_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number % 5 == 0 && number % 7 == 0)
            {
                Console.WriteLine("true {0}", number);
            }
            else
            {
                Console.WriteLine("false {0}", number);
            }
        }
    }
}
/*Description

Write a program that does the following:

Reads an integer number from the console.
Stores in a variable if the number can be divided by 7 and 5 without remainder.
Prints on the console "true NUMBER" if the number is divisible without remainder by 7 and 5. Otherwise prints "false NUMBER". In place of NUMBER print the value of the input number.
Input

The input will consist of a single integer value.
Output

The output must always follow the format specified in the description. See the sample tests.
Constraints

The input will always consist of valid integers and follow the format in the description.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
3	false 3
0	true 0
5	false 5
7	false 7
35	true 35
140	true 140
*/