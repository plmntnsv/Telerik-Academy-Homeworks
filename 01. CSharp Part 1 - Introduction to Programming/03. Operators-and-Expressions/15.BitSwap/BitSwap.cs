﻿using System;

namespace _03._15.BitSwap
{
    class BitSwap
    {
        static void Main(string[] args)
        {
            ulong n = ulong.Parse(Console.ReadLine());
            ulong p = ulong.Parse(Console.ReadLine());
            ulong q = ulong.Parse(Console.ReadLine());
            ulong k = ulong.Parse(Console.ReadLine());

            for (ulong i = 0; i < k; i++, p++, q++)
            {
                ulong mask = 1U << (int)p;
                ulong nAndMask = n & mask;
                ulong bit1 = nAndMask >> (int)p;


                ulong mask2 = 1U << (int)q;
                ulong nAndMask2 = n & mask2;
                ulong bit2 = nAndMask2 >> (int)q;

                if (bit1 == 0)
                {
                    mask = ~(1U << (int)q);
                    n = n & mask;
                }
                else
                {
                    mask = 1U << (int)q;
                    n = n | mask;
                }

                if (bit2 == 0)
                {
                    mask = ~((ulong)1 << (int)p);
                    n = n & mask;
                }
                else
                {
                    mask = (ulong)1 << (int)p;
                    n = n | mask;
                }
            }
            Console.WriteLine(n);
        }
    }
}
/*Description

Write a program first reads 4 numbers n, p, q and k and than swaps bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of n. Print the resulting integer on the console.

Input

On the only four lines of the input you will receive the integers n, p, q and k in this order.
Output

Output a single value - the value of n after the bit swaps.
Constraints

The first and the second sequence of bits will never overlap.
n will always be a valid 32-bit positive integer.
p, q >= 0
p+k-1, q+k-1 < 32
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Binary representation	Binary representation after swaps	Output
1140867093
3
24
3	01000100 00000000 01000000 00010101	01000010 00000000 01000000 00100101	1107312677
4294901775
24
3
3	11111111 11111111 00000000 00001111	11111001 11111111 00000000 00111111	4194238527
2369124121
2
22
10	10001101 00110101 11110111 00011001	01110001 10110101 11111000 11010001	1907751121
*/
