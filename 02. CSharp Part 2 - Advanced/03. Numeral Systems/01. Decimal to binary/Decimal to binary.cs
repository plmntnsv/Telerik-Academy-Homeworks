using System;

namespace _03._01.Decimal_to_binary
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong decNum = ulong.Parse(Console.ReadLine());
            Console.WriteLine(ConvertDecimalToBinary(decNum));
        }
        static string ConvertDecimalToBinary(ulong decNum)
        {
            string result = "";
            while (decNum > 0)
            {
                result = decNum % 2 + result;
                decNum /= 2;
            }
            return result;
        }
    }
}
/*Description

Write a program that converts a decimal number N to its binary representation.

Input

On the only line you will receive a decimal number - N
There will not be leading zeros
Output

Print the binary representation of N on a single line
There should not be leading zeros
Constraints

1 <= N <= 10^18
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
19	    10011
*/