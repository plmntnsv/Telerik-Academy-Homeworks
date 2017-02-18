using System;
using System.Linq;

namespace _01._04.Appearance_count
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int x = int.Parse(Console.ReadLine());
            int count = 0;
            Console.WriteLine(CountAppearances(arr, size, x, count));
        }
        static int CountAppearances (int[] arr, int size, int x, int count)
        {
            for (int i = 0; i < size; i++)
            {
                if (arr[i] == x)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
/*Description

Write a method that counts how many times given number appears in a given array. 
Write a test program to check if the method is working correctly.

Input

On the first line you will receive a number N - the size of the array
On the second line you will receive N numbers separated by spaces - the numbers in the array
On the third line you will receive a number X
Output

Print how many times the number X appears in the array
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                        Output
8                               2
28 6 21 6 -7856 73 73 -56
73	                            
*/
