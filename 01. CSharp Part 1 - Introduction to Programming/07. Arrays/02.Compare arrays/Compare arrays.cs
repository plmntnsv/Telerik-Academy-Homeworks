using System;

namespace _07._02.Compare_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] firstArr = new int[n];
            string isEqual = "Equal";
            for (int i = 0; i < n*2; i++)
            {
                if (i < n)
                {
                    firstArr[i] = int.Parse(Console.ReadLine());
                }
                else if (firstArr[i-n] != int.Parse(Console.ReadLine()))
                {
                    isEqual = "Not equal";
                }
            }
            Console.WriteLine(isEqual);
        }
    }
}
/*Description

Write a program that reads two integer arrays of size N from the console and compares them element by element.

Input

On the first line you will receive the number N
On the next N lines the numbers of the first array will be given
On the next N lines the numbers of the second array will be given
Output

Print Equal if the two arrays are the same and Not equal if they are not
Constraints

1 <= N <= 20
N will always be a valid integer number
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
3
---
1
2
3
---
1
2
3	    Equal
******
3
---
1
1
1
---
2
2
2	    Not equal
*/