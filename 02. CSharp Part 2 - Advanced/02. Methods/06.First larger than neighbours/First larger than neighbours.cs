using System;
using System.Linq;

namespace _01._06.First_larger_than_neighbours
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            Console.WriteLine(FirstLargerIndex(size, arr));
        }
        static int FirstLargerIndex (int size, int[] arr)
        {
            for (int i = 1; i < size-1; i++)
            {
                if (arr[i] > arr[i-1] && arr[i] > arr[i+1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
/*Description

Write a method that returns the index of the first element in array that is larger than its neighbours, or -1, if there is no such element.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers sepated by spaces - the array
Output

Print the index of the first element that is larger than its neighbours or -1 if none are
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
6
-26 -25 -28 31 2 27	1
*/