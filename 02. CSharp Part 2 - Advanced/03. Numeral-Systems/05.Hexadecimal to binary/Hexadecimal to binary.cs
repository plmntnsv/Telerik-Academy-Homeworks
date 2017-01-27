using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._05.Hexadecimal_to_binary
{
    class Program
    {
        static void Main(string[] args)
        {
            string hexNum = Console.ReadLine();
            Console.WriteLine(ConvertHexaToBinary(hexNum));
        }
        static string ConvertHexaToBinary(string hexNum)
        {
            string result = "";
            foreach (char digit in hexNum)
            {
                switch (digit)
                {
                    case '0': result += "0000"; break;
                    case '1': result += "0001"; break;
                    case '2': result += "0010"; break;
                    case '3': result += "0011"; break;
                    case '4': result += "0100"; break;
                    case '5': result += "0101"; break;
                    case '6': result += "0110"; break;
                    case '7': result += "0111"; break;
                    case '8': result += "1000"; break;
                    case '9': result += "1001"; break;
                    case 'A': result += "1010"; break;
                    case 'B': result += "1011"; break;
                    case 'C': result += "1100"; break;
                    case 'D': result += "1101"; break;
                    case 'E': result += "1110"; break;
                    case 'F': result += "1111"; break;

                    default:
                        break;
                }
            }
            result = result.TrimStart('0');
            return result;
        }
    }
}
/*Description

Write a program to convert hexadecimal numbers to binary numbers (directly).

Input

On the only line you will receive a decimal number - N
There will not be leading zeros
Letters will be uppercase
Output

Print the its binary representation on a single line
There should not be leading zeros
Constraints

1 <= N <= 1018 = DE0B6B3A7640000(16)
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
13	    10011
*/
