using System;

namespace _07._11.Binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            //int[] arr = { 1, 2, 4, 8, 16, 31, 32, 64, 77, 99, 101 };

            int x = int.Parse(Console.ReadLine());
            bool foundIndex = false;
            int start = 0, end = n - 1, middle = (n - 1) / 2;

            while (true)
            {
                if (x == arr[middle])
                {
                    foundIndex = true;
                    break;
                }
                else if ((x > arr[middle] && x < arr[middle + 1]) || x > arr[end] || x < arr[start])
                {
                    break;
                }
                if (end - start == 1)
                {
                    middle += 1;
                }
                else if (x < arr[middle])
                {
                    end = middle;
                    middle = ((end - start) / 2);
                }
                else if (x > arr[middle])
                {
                    start = middle;
                    middle = ((end - start) / 2) + start;
                }
            }
            Console.WriteLine(foundIndex ? middle.ToString() : "-1");
        }
    }
}
/*Description

Write a program that finds the index of given element X in a sorted array of N integers by using the Binary search algorithm.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
On the last line you will receive the number X
Output

Print the index where X is in the array
If there is more than one occurence print the first one
If there are no occurences print -1
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10      6
1
2
4
8
16
31
32
64
77
99
32	
*/
