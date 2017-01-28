using System;

namespace _03._03.Decimal_to_hexadecimal
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong decNum = ulong.Parse(Console.ReadLine());
            Console.WriteLine(ConvertDecimalToHexa(decNum));
        }
        static string ConvertDecimalToHexa(ulong decNum)
        {
            string result = "";
            while (decNum > 0)
            {
                switch (decNum % 16)
                {
                    case 10:
                        result = "A" + result;
                        break;
                    case 11:
                        result = "B" + result;
                        break;
                    case 12:
                        result = "C" + result;
                        break;
                    case 13:
                        result = "D" + result;
                        break;
                    case 14:
                        result = "E" + result;
                        break;
                    case 15:
                        result = "F" + result;
                        break;
                    default:
                        result = ((decNum % 16)) + result;
                        break;
                }

                decNum /= 16;
            }
            return result;
        }
    }
}
/*Description

Write a program that converts a decimal number N to its hexadecimal representation.

Input

On the only line you will receive a decimal number - N
There will not be leading zeros
Output

Print the hexadecimal representation of N on a single line
There should not be leading zeros
Use uppercase letters
Constraints

1 <= N <= 10^18
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
19	13
*/
