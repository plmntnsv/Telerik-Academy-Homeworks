using System;

namespace _03._04.Hexadecimal_to_decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] hexNum = Console.ReadLine().ToCharArray();
            Console.WriteLine(ConvertHexatoDecimal(hexNum));
        }
        static ulong ConvertHexatoDecimal(char[] hexNum)
        {
            ulong result = 0;
            foreach (char digit in hexNum)
            {
                if (char.IsDigit(digit))
                {
                    result = result * 16 + digit - '0';
                }
                else
                {
                    result = result * 16 + digit - 'A' + 10;
                }
               
            }
            return result;
        }
    }
}
/*Description

Write a program that converts a hexadecimal number N to its decimal representation.

Input

On the only line you will receive a hexadecimal number - N
There will not be leading zeros
Letters will be uppercase
Output

Print the decimal representation of N on a single line
There should not be leading zeros
Constraints

1 <= N <= 1018 = DE0B6B3A7640000(16)
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
13	    19
*/