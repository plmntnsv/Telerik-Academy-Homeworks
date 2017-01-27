using System;

namespace _07._07.Selection_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
                numToSwap = 0,
                smallestNum = 0,
                indexOfSmallestNum = 0;
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                numToSwap = arr[i];
                indexOfSmallestNum = i;
                smallestNum = arr[i];
                for (int z = i+1; z < n; z++)
                {
                    if (arr[z] < smallestNum)
                    {
                        smallestNum = arr[z];
                        indexOfSmallestNum = z;
                    }
                }
                arr[i] = smallestNum;
                arr[indexOfSmallestNum] = numToSwap;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
/*Description

Sorting an array means to arrange its elements in increasing order. 
Write a program to sort an array. Use the Selection sort algorithm: 
Find the smallest element, move it at the first position, 
find the smallest from the rest, move it at the second position, etc.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the sorted array
Each number should be on a new line
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
6
3       1
4       2
1       3
5       4
2       5
6       6

10
36      1
10      10
1       20
34      27
28      28
38      30
31      31
27      34
30      36
20      38
*/
