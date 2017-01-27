using System;
using System.Linq;

namespace _01._02.Get_largest_number
{
    class Program
    {
        static void Main()
        {
            string[] arr = Console.ReadLine().Split(' ').ToArray();
            int max = int.Parse(arr[0]) > int.Parse(arr[1]) ? int.Parse(arr[0]) : int.Parse(arr[1]);
            GetMax(int.Parse(arr[2]), max);
        }
        static void GetMax(int c, int max)
        {
            if (c > max)
            {
                max = c;
            }
            Console.WriteLine(max);
        }
    }
}
/*Description

Write a method GetMax() with two parameters that returns the larger of two integers. 
Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

Input

On the first line you will receive 3 integers separated by spaces
Output

Print the largest of them
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
8 3 6	    8
7 19 19	    19
*/