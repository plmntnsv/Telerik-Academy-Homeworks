using System;
using System.Numerics;

namespace _03._07.One_system_to_any_other
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong currNumBase = ulong.Parse(Console.ReadLine());
            string number = Console.ReadLine();
            ulong convertBase = ulong.Parse(Console.ReadLine());
            if (currNumBase != 10)
            {
                BigInteger numberInDec = ConvertToDecimal(number, currNumBase);
                ConvertDecimalToOther(numberInDec, convertBase);
            }
            else
            {
                BigInteger numberInDec;
                BigInteger.TryParse(number, out numberInDec);
                ConvertDecimalToOther(numberInDec, convertBase);
            }

        }
        static BigInteger ConvertToDecimal(string number, ulong numBase)
        {
            BigInteger result = 0;
            foreach (char digit in number)
            {
                if (char.IsDigit(digit))
                {
                    result = result * numBase + digit - '0';
                }
                else
                {
                    result = result * numBase + digit - 'A' + 10;
                }

            }
            return result;
        }

        static void ConvertDecimalToOther(BigInteger numberInDec, ulong convertBase)
        {
            if (convertBase == 10)
            {
                Console.WriteLine(numberInDec);
                return;
            }
            string result = "";
            while (numberInDec > 0)
            {
                int remainder = (int)(numberInDec % convertBase);
                switch (remainder)
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
                        result = ((numberInDec % convertBase)) + result;
                        break;
                }

                numberInDec /= convertBase;
            }
            Console.WriteLine(result);
        }
    }
}
/*Description

Write a program to convert the number N from any numeral system of given base s to any other numeral system of base d.

Input

On the first line you will receive the number s
On the second line you will receive a number in base s - N
There will not be leading zeros
On the third line you will receive the number d
Output

Print N in base d
There should not be leading zeros
Use uppercase letters
Constraints

2 <= s, d <= 16
1 <= N <= 1018
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
13
16
9	    21
*/
