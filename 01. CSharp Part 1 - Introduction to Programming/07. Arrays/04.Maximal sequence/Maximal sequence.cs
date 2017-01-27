using System;

namespace _07._04.Maximal_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
                counter = 1,
                maxLenght = 0;
            int[] intArr = new int[n];
            for (int i = 0; i < n; i++)
            {
                intArr[i] = int.Parse(Console.ReadLine());
                if (i > 0)
                {
                    if (intArr[i] == intArr[i - 1])
                    {
                        counter++;
                        if (counter > maxLenght)
                        {
                            maxLenght = counter;
                        }
                    }
                    else
                    {
                        counter = 1;
                    }
                }
            }
            Console.WriteLine(maxLenght);
        }
    }
}
/*Description

Write a program that finds the length of the maximal sequence of equal elements in an array of N integers.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the length of the maximal sequence
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10
2
1
1
2
3
3
2
2
2
1	    3

*/