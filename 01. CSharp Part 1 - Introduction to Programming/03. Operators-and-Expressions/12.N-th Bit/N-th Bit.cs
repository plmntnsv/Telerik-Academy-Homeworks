using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._12.N_th_Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine()),
                n = int.Parse(Console.ReadLine());
                int mask = 1 << n;
                long nAndMask = p & mask;
                long bit = nAndMask >> n;
            Console.WriteLine(bit);
        }
    }
}
/*Description

Write a program that reads from the console two integer numbers P and N and prints on the console the value of P's N-th bit.

Input

On the first line you will receive the number P. On the second line you will receive the number N.
Output

Output a single value - the value of the N-th bit in P.
Constraints

N will be a positive integer and always smaller than 55.
0 <= P <= 255
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Binary representation	Output
5
2	00000000 00000000 00000101	1
0
9	00000000 00000000 00000000	0
15
1	00000000 00000000 00001111	1
5343
7	00000000 00010100 11011111	1
62241
11	00000000 11110011 00100001	0
985276
49	00001111 00001000 10111100	0
*/