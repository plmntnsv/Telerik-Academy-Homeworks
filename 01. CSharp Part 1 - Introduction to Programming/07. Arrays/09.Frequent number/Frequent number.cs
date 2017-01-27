using System;

namespace _07._09.Frequent_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
                currentNum = 0,
                biggestNum = 0,
                currentCount = 1,
                maxCount = 0;
            int[] nArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                nArr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                currentNum = nArr[i];
                currentCount = 1;
                for (int z = i + 1; z < n; z++)
                {
                    if (nArr[z] == currentNum)
                    {
                        currentCount++;
                    }
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        biggestNum = currentNum;
                    }
                }
            }
            Console.WriteLine("{0} ({1} times)", biggestNum, maxCount);
        }
    }
}
/*Description

Write a program that finds the most frequent number in an array of N elements.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the most frequent number and how many time it is repeated
Output should be REPEATING_NUMBER (REPEATED_TIMES times)
Constraints

1 <= N <= 1024
0 <= each number in the array <= 10000
There will be only one most frequent number
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
13      4 (5 times)
4
1
1
4
2
3
4
4
1
2
4
9
3	
*/
