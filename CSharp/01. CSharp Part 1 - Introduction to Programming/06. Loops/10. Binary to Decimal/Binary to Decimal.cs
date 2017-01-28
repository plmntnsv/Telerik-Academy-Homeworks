using System;

namespace _06._10.Binary_to_Decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int power = 0;
            long result = 0;
            for (int i = str.Length - 1; i >= 0; i--)
             {
                if (str[i] == '1')
                {
                    result += (long)Math.Pow(2, power);  
                }
                power++;
            }
            Console.WriteLine(result);
            
        }
    }
}
/*Description

Using loops write a program that converts a binary integer number to its decimal form.

The input is entered as string. The output should be a variable of type long.
Do not use the built-in .NET functionality.
Input

You will receive exactly one line containing an integer number representation in binary
Output

On the only output line write the decimal representation of the number
Constraints

All input numbers will be valid 32-bit integers
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                        Output
0	                            0
11	                            3
1010101010101011	            43691
1110000110000101100101000000	236476736
*/