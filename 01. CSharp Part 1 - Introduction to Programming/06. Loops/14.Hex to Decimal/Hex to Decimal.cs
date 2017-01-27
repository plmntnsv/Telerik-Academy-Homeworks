using System;

namespace _06._14.Hex_to_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int power = 0,
                currentDigit;
            double result = 0;
            for (int i = input.Length-1; i >= 0; i--)
            {
                switch (input[i])
                {
                    case 'A': currentDigit = 10; break;
                    case 'B': currentDigit = 11; break;
                    case 'C': currentDigit = 12; break;
                    case 'D': currentDigit = 13; break;
                    case 'E': currentDigit = 14; break;
                    case 'F': currentDigit = 15; break;
                    default: int.TryParse(input[i].ToString(), out currentDigit); break;
                }
                
                result += currentDigit * (Math.Pow(16, power));
                power++;

            }
            Console.WriteLine(result);
        }
    }
}
/*Description

Using loops write a program that converts a hexadecimal integer number to its decimal form.

The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.
Input

The input will consists of a single line containing a single hexadecimal number as string.
Output

The output should consist of a single line - the decimal representation of the number as string.
Constraints

All numbers will be valid 64-bit integers.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
FE	        254
1AE3	    6883
4ED528CBB4	338583669684
*/