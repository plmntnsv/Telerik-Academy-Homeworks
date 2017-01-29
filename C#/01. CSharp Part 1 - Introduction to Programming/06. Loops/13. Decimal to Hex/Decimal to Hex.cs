using System;

namespace _06._13.Decimal_to_Hex
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string result = "";
            double reminder,
                   hexNum;
            while (input > 0)
            {

                reminder = input / 16.00;
                hexNum = (reminder - Math.Truncate(reminder)) * 16;
                if (hexNum >= 10 && hexNum <= 15)
                {
                    switch ((long)hexNum)
                    {
                        case 10: result = 'A' + result; break;
                        case 11: result = 'B' + result; break;
                        case 12: result = 'C' + result; break;
                        case 13: result = 'D' + result; break;
                        case 14: result = 'E' + result; break;
                        case 15: result = 'F' + result; break;
                        default: break;
                    }
                }
                else
                {
                    result = hexNum + result;
                }

                input /= 16;
            }

            Console.WriteLine(result);
            //long decInput = long.Parse(Console.ReadLine());

            //if (decInput == 0)
            //{
            //    Console.WriteLine(0);
            //}
            //else
            //{
            //    string hexaNumber = "";
            //    while (decInput > 0)
            //    {

            //        long checkRemainder = decInput % 16;
            //        string remainder = "";
            //        switch (checkRemainder)
            //        {
            //            case 10: remainder = "A"; break;
            //            case 11: remainder = "B"; break;
            //            case 12: remainder = "C"; break;
            //            case 13: remainder = "D"; break;
            //            case 14: remainder = "E"; break;
            //            case 15: remainder = "F"; break;
            //            default: remainder = checkRemainder.ToString(); break;
            //        }
            //        hexaNumber = remainder + hexaNumber;
            //        decInput /= 16;
            //    }

            //    Console.WriteLine(hexaNumber);
            //}
        }
    }
}
/*Description

Using loops write a program that converts an integer number to its hexadecimal representation.

The input is entered as long. The output should be a variable of type string.
Do not use the built-in .NET functionality.
Input

On the first and only line you will receive an integer in the decimal numeral system.
Output

On the only output line write the hexadecimal representation of the read number.
Constraints

All numbers will always be valid 64-bit integers.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	        Output
254	            FE
6883	        1AE3
338583669684	4ED528CBB4
*/
