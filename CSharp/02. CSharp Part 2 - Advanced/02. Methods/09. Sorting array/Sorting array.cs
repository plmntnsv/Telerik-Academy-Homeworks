using System;
using System.Linq;

namespace _01._09.Sorting_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
            int[] arr2 = new int[2];
            int rotations = size,
                tempHolder = 0;
            for (int i = size-1; i >= 0; i--)
            {
                FindMaxElement(rotations, arr, arr2);
                rotations--;
                tempHolder = arr[i];
                arr[i] = arr2[0];
                arr[arr2[1]] = tempHolder;
            }

            PrintSortedArray(arr);
        }
        static int[] FindMaxElement(int rotations, int[] arr, int[]arr2)
        {
            int maxElement = 0;
            for (int i = 0; i < rotations; i++)
            {
                if (i == 0)
                {
                    maxElement = arr[i];
                    arr2[0] = arr[i];
                    arr2[1] = i;
                }
                else if (arr[i] > maxElement)
                {
                    maxElement = arr[i];
                    arr2[0] = arr[i];
                    arr2[1] = i;
                }
            }
            return arr2;
        }
        
        static void PrintSortedArray(int[] arr)
        {
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
/*Description

Write a method that returns the maximal element in a portion of array 
of integers starting at given index. Using it write another method that 
sorts an array in ascending / descending order. Write a program that 
sorts a given array.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers separated by spaces - the array
Output

Print the sorted array
Elements must be separated by spaces
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                        Output
6
3 4 1 5 2 6	                    1 2 3 4 5 6
10
36 10 1 34 28 38 31 27 30 20	1 10 20 27 28 30 31 34 36 38
*/