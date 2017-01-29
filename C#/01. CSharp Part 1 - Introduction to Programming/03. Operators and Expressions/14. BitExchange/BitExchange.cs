using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._14.BitExchange
{
    class BitExchange
    {
        static void Main(string[] args)
        {//input
            uint n = uint.Parse(Console.ReadLine());
            uint mask,
                result;
           //vzima 3ti bit
            uint mask3 = 1 << 3;
            uint nAndMask3 = n & mask3;
            uint bit3 = nAndMask3 >> 3;
            //vzima 4ti bit
            uint mask4 = 1 << 4;
            uint nAndMask4 = n & mask4;
            uint bit4 = nAndMask4 >> 4;
            //vzima 5ti bit
            uint mask5 = 1 << 5;
            uint nAndMask5 = n & mask5;
            uint bit5 = nAndMask5 >> 5;
            //vzima 24ti bit
            uint mask24 = 1 << 24;
            uint nAndMask24 = n & mask24;
            uint bit24 = nAndMask24 >> 24;
            //vzima 25ti bit
            uint mask25 = 1 << 25;
            uint nAndMask25 = n & mask25;
            uint bit25 = nAndMask25 >> 25;
            //vzima 26ti bit
            uint mask26 = 1 << 26;
            uint nAndMask26 = n & mask26;
            uint bit26 = nAndMask26 >> 26;
            //ako 3ti bit e 0 pravi i 24 = 0, ako e 1 pravi 24 = 1
            if (bit3 == 0)
            {
                mask = ~((uint)1 << 24);
                result = n & mask;
            }
            else
            {
                mask = 1 <<24;
                result = n | mask;
            }
            //ako 4ti bit e 0 pravi i 25 = 0, ako e 1 pravi 25 = 1
            if (bit4 == 0)
            {
                mask = ~((uint)1 << 25);
                result = result & mask;
            }
            else
            {
                mask = 1 << 25;
                result = result | mask;
            }
            //ako 5ti bit e 0 pravi i 26 = 0, ako e 1 pravi 26 = 1
            if (bit5 == 0)
            {
                mask = ~((uint)1 << 26);
                result = result & mask;
            }
            else
            {
                mask = 1 << 26;
                result = result | mask;
            }
            //ako 24ti bit e 0 pravi i 3 = 0, ako e 1 pravi 3 = 1
            if (bit24 == 0)
            {
                mask = ~((uint)1 << 3);
                result = result & mask;
            }
            else
            {
                mask = 1 << 3;
                result = result | mask;
            }
            //ako 25ti bit e 0 pravi i 4 = 0, ako e 1 pravi 4 = 1
            if (bit25 == 0)
            { 
                mask = ~((uint)1 << 4);
                result = result & mask;
            }
            else
            {
                mask = 1 << 4;
                result = result | mask;
            }
            //ako 26ti bit e 0 pravi i 5 = 0, ako e 1 pravi 5 = 1
            if (bit26 == 0)
            {
                mask = ~((uint)1 << 5);
                result = result & mask;
            }
            else
            {
                mask = 1 << 5;
                result = result | mask;
            }
            //output
            Console.WriteLine(result);
        }
    }
}
/*Description

Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer(read from the console).

Input

On the only input line you will receive the unsigned integer number whose bits you must exchange.
Output

On the only output line print the value of the integer with the exchanged bits.
Constraints

N will always be a valid 32-bit unsigned integer.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Binary representation	Binary representation after exchange	Output
1140867093	01000100 00000000 01000000 00010101	01000010 00000000 01000000 00100101	1107312677
255406592	00001111 00111001 00110010 00000000	00001000 00111001 00110010 00111000	137966136
4294901775	11111111 11111111 00000000 00001111	11111001 11111111 00000000 00111111	4194238527
5351	00000000 00000000 00010100 11100111	00000100 00000000 00010100 11000111	67114183
2369124121	10001101 00110101 11110111 00011001	10001011 00110101 11110111 00101001	2335569705
*/