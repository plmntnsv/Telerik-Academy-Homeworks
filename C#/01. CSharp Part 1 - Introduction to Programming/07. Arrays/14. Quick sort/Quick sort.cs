using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._14.Quick_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;// int.Parse(Console.ReadLine());
            //int[] arr = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            int[] arr = { 3, 6, 1, 5, 2, 4 },
                  arr2 = new int[n],
                  arr3 = new int[n];
            for (int j = 0; j < n; j++)
            {
                arr3[j] = int.MaxValue;
            }
            int pivot = n - 1,
                checker = pivot -1,
                temp;
            while (true)
            {
                if (arr[pivot] < arr[checker])
                {
                    temp = arr[checker];
                    arr[checker] = arr[pivot];
                    arr[pivot] = temp;
                }
                checker--;
            }
        }
    }
}
/*Description

Write a program that sorts an array of integers using the Quick sort algorithm.
https://en.wikipedia.org/wiki/Quicksort

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
6	    6

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
20	    38
*/
