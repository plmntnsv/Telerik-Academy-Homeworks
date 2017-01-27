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
            string binNum = Console.ReadLine();
            Console.WriteLine(ConvertBinaryToHexa(binNum));
        }
        static string ConvertBinaryToHexa(string binNum)
        {
            string result = "";
            for (int i = binNum.Length-1; i >=0; i-=4)
            {
                string temp = "";
                for (int j = 0, currIndex = i; j < 4; j++, currIndex--)
                {

                    temp = binNum[currIndex] + temp;
                    if (currIndex == 0)
                    {
                        temp = temp.PadLeft(4, '0');
                        break;
                    }
                }
                switch (temp)
                {
                    case "0000": result = "0" + result; break;
                    case "0001": result = "1" + result; break;
                    case "0010": result = "2" + result; break;
                    case "0011": result = "3" + result; break;
                    case "0100": result = "4" + result; break;
                    case "0101": result = "5" + result; break;
                    case "0110": result = "6" + result; break;
                    case "0111": result = "7" + result; break;
                    case "1000": result = "8" + result; break;
                    case "1001": result = "9" + result; break;
                    case "1010": result = "A" + result; break;
                    case "1011": result = "B" + result; break;
                    case "1100": result = "C" + result; break;
                    case "1101": result = "D" + result; break;
                    case "1110": result = "E" + result; break;
                    case "1111": result = "F" + result; break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
/*Description

Write a program to convert binary numbers to hexadecimal numbers (directly).

Input

On the only line you will receive a decimal number - N
There will not be leading zeros
Output

Print the its binary representation on a single line
There should not be leading zeros
Use uppercase letters
Constraints

1 <= N <= 1018 = 110111100000101101101011001110100111011001000000000000000000(2)
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
10011	13
*/
