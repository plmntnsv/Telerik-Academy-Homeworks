using System;
using System.Linq;

namespace _01._05.Larger_than_neighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int count = 0;
            Console.WriteLine(LargerThanNeighbours(size, arr, count));
        }
        static int LargerThanNeighbours (int size, int[] arr, int count)
        {
            for (int i = 1; i < size-1; i++)
            {
                if (arr[i] > arr[i-1] && arr[i] > arr[i+1])
                {
                    count++;
                }
            }
            return count;
        }
    }
}
/*Description

Write a method that checks if the element at given position in given array of integers 
is larger than its two neighbours (when such exist). Write program that reads an array 
of numbers and prints how many of them are larger than their neighbours.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers separated by spaces - the array
Output

Print how many numbers in the array are larger than their neighbours
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                Output
6
-26 -25 -28 31 2 27	    2
*/