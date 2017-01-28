using System;
using System.Numerics;

namespace _06._07.Catalan_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger factorialN = 1,
                       factorialN2 = 1,
                       factorialNPlus1 = 1;
            for (int i = 1; i <= n *2; i++)
            {
                if (i <= n)
                {
                    factorialN *= i;
                }
                if (i <= n+1)
                {
                    factorialNPlus1 *= i;
                }
                factorialN2 *= i;
            }
            
            Console.WriteLine(factorialN2 / (factorialNPlus1 * factorialN));
        }
    }
}
/*Description

In combinatorics, the Catalan numbers are calculated by the following formula: 

    Cn = 1/n+1 * (2n / n) = (2n)! / (n+1)!n! = П(otgore n, otdolu k=2) * n+k/k for n>=0

Write a program to calculate the Nth Catalan number by given N
Input

On the only line, you will receive the number N
Output

Output a single number - the Nth Catalan number
Constraints

N will always be a valid integer number in the range [0, 100]
Hint: overflow is possible.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
0	1
5	42
10	16796
15	9694845
*/
