using System;

namespace _07._06.Maximal_K_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
                k = int.Parse(Console.ReadLine()),
                biggestNum = 0,
                sum = 0,
                indexOfBiggest = 0;
            int[] intArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                intArr[i] = int.Parse(Console.ReadLine());
            }

            for (int z = 0; z < k; z++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        biggestNum = intArr[i];
                        indexOfBiggest = 0;
                    }
                    else if (biggestNum < intArr[i])
                    {
                        biggestNum = intArr[i];
                        indexOfBiggest = i;
                    }

                }
                intArr[indexOfBiggest] = int.MinValue;

                sum += (biggestNum);
            }
            Console.WriteLine(sum);
        }
    }
}
/*Description

Write a program that reads two integer numbers N and K and an array of N elements from the console. 
Find the maximal sum of K elements in the array.

Input

On the first line you will receive the number N
On the second line you will receive the number K
On the next N lines the numbers of the array will be given
Output

Print the maximal sum of K elements in the array
Constraints

1 <= N <= 1024
1 <= K <= N
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
8       16
3
3
2
3
-2
5
4
2
7	
*/
