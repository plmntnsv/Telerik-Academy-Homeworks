using System;

namespace _07._08.Maximal_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
                biggestSum = 0,
                currentSum = 0;
            int[] arr = new int[n];
            //int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            //s vlojeni cikli
            for (int i = 0; i < n; i++)
            {
                for (int z = i; z < n; z++)
                {
                    currentSum += arr[z];
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                    }
                }
                currentSum = 0;
            }
            //s 1 cikul
            int startPosition = 0;
            int indexOfNext = 0;
            while (startPosition < n)
            {
                currentSum += arr[indexOfNext];
                if (currentSum>biggestSum)
                {
                    biggestSum = currentSum;
                }
                indexOfNext++;
                if (indexOfNext == n)
                {
                    startPosition++;
                    indexOfNext = startPosition;
                    currentSum = 0;
                }
            }
            Console.WriteLine(biggestSum);
        }
    }
}
/*Description

Write a program that finds the maximal sum of consecutive elements in a given array of N numbers.

Can you do it with only one loop (with single scan through the elements of the array)?
Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the maximal sum of consecutive numbers
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10      11
 2
 3
-6
-1
 2
-1
 6
 4
-8
 8	
*/
