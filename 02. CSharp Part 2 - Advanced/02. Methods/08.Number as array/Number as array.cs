using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._08.Number_as_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray(),
                  arr1 = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray(),
                  arr2 = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            result(arr1, arr2);
        }
        static void result(int[] arr1, int[] arr2)
        {
            List<int> listResult = new List<int>();
            int operation = 0;
            bool addOne = false;
            for (int i = 0; i < Math.Max(arr1.Length, arr2.Length); i++)
            {
                if (addOne)
                {
                    operation += 1;
                    addOne = false;
                }
                if (i < arr1.Length)
                {
                    operation += arr1[i];
                }
                if (i < arr2.Length)
                {
                    operation += arr2[i];
                }
                if (operation > 9)
                {
                    operation -= 10;
                    addOne = true;
                }
                listResult.Add(operation);
                operation = 0;
            }
            if (addOne)
            {
                listResult.Add(1);
            }
            Console.WriteLine(string.Join(" ", listResult));

        }
    }
}
/*Description

Write a method that adds two positive integer numbers represented as arrays of digits 
(each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
Write a program that reads two arrays representing positive integers and outputs their sum.

Input

On the first line you will receive two numbers separated by spaces - the size of each array
On the second line you will receive the first array
On the third line you will receive the second array
Output

Print the sum as an array of digits (as described)
Digits should be separated by spaces
Constraints

Each of the numbers that will be added could have up to 10 000 digits.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
3 4
8 3 3
6 2 4 2	    4 6 7 2
            
5 5
0 3 9 3 2
5 9 5 1 7	5 2 5 5 9
*/
