using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._02.Reverse_string
{
    class Program
    {
        static void Main(string[] args)
        { 
            List<char> inputList = Console.ReadLine().ToList();
            inputList.Reverse();
            Console.WriteLine(string.Join("",inputList));
          
        }
    }
}
/*Description

Write a program that reads a string, reverses it and prints the result on the console.
Input

On the only line you will receive a string
Output

Print the string in reverse on a single line
Constraints

1 <= size of string <= 10000
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
sample	    elpmas
somestring	gnirtsemos
*/