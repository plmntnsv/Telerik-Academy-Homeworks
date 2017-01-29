using System;

namespace _07._05.Maximal_increasing_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
                counter = 1,
                maxCount = 0;
            int[] intArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                intArr[i] = int.Parse(Console.ReadLine());
                if (i > 0)
                {
                    if (intArr[i] > intArr[i-1])
                    {
                        counter++;
                        if (counter > maxCount)
                        {
                            maxCount = counter;
                        }
                    }
                    else
                    {
                        counter = 1;
                    }
                }
            }
            Console.WriteLine(maxCount);
        }
    }
}
/*Description

Write a program that finds the length of the maximal increasing sequence in an array of N integers.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the length of the maximal increasing sequence
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
8       3
7
3
2
3
4
2
2
4	    
*/
