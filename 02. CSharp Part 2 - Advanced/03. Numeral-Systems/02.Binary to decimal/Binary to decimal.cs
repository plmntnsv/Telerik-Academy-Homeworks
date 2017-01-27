using System;

namespace _03._02.Binary_to_decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] binNum = Console.ReadLine().ToCharArray();
            Console.WriteLine(ConvertBinaryToDecimal(binNum));
        }
        static ulong ConvertBinaryToDecimal (char[] binNum)
        {
            ulong result = 0;
            foreach (char digit in binNum)
            {
                result = result * 2 + digit - '0';
            }
            return result;
        }
    }
}
/*Description

Write a program that converts a binary number N to its decimal representation.

Input

On the only line you will receive a binary number - N
There will not be leading zeros
Output

Print the decimal representation of N on a single line
There should not be leading zeros
Constraints

1 <= N <= 1018 = 110111100000101101101011001110100111011001000000000000000000(2)
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10011	19
*/