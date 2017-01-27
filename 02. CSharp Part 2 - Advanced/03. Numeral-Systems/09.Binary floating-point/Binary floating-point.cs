using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._09.Binary_floating_point
{
    class Program
    {
        static void Main(string[] args)
        {
            double floatNum = -27.25;
            int totalBits = 127;        //The bias is 2^k−1 − 1, where k is the number of bits in the exponent field. 
            bool isNegative = false;    //For the eight-bit format, k = 3, so the bias is 2^3−1 − 1 = 3. For IEEE 32-bit, k = 8, so the bias is 2^8−1 − 1 = 127.
            if (floatNum<0)
            {
                 isNegative = true;
                floatNum = Math.Abs(floatNum);
            }
            int leftSide = (int)floatNum;
            double rightSide = floatNum - Math.Truncate(floatNum);

            string binLeftSide = ConvertIntegralPart(leftSide);
            string binRightSide = ConvertFractialPart(rightSide);
            string binLeftAndRightSide = binLeftSide + binRightSide;
            string mantissa = FindMantissa(binLeftAndRightSide);
            int power = FindPower(binLeftSide, binRightSide);
            string exponent = ConvertIntegralPart(power + totalBits).PadLeft(8, '0');

            PrintFinalResult(isNegative, exponent, mantissa);
        }
        static string ConvertIntegralPart(int leftSide)
        {
            string result = "";
            if (leftSide == 0)
            {
                result = "0";
            }
            else
            {
                while (leftSide != 0)
                {
                    result = leftSide % 2 + result;
                    leftSide = leftSide / 2;
                }
            }
            return result;
        }
        
        static string ConvertFractialPart (double rightSide)
        {
            string result = "";

            while (rightSide - Math.Truncate(rightSide) > 0)
            {
                rightSide = rightSide * 2.00;
                result += (int)rightSide;
                if (rightSide > 1)
                {
                    rightSide -= 1;
                }
                    
            }
            return result;
        }
        static int FindPower(string binLeftSide, string binRightSide)
        {
            int power = 0;
            bool increasePower = false;
            for (int i = 0; i < binLeftSide.Length ; i++)
            {
                if (binLeftSide[i]=='1')
                {
                    increasePower = true;
                }
                if (increasePower)
                {
                    power++;
                }
            }
            if (power == 0)
            {
                for (int i = 0; i < binRightSide.Length; i++)
                {
                    if (binRightSide[i] == '0')
                    {
                        power--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return power-1;
        }
        static string FindMantissa (string binLeftAndRightSide)
        {
            string result = "";
            
            for (int i = 0; i < binLeftAndRightSide.Length; i++)
            {
                if (binLeftAndRightSide[i] == '1')
                {
                    result = binLeftAndRightSide.Substring(i+1);
                    break;
                }
            }
            return result;
        }
        static void PrintFinalResult (bool isNegative, string exponent, string mantissa)
        {
            if (isNegative)
            {
                Console.WriteLine("The sign is -: 1");
            }
            else
            {
                Console.WriteLine("The sign is +: 0");
            }
            Console.WriteLine("The exponent is: {0}",exponent);
            Console.WriteLine("The mantissa is: {0}", mantissa);
            string finalResult = ((isNegative ? "1" : "0") + "," + exponent + "," + mantissa).PadRight(32, '0'); ;
            Console.WriteLine(finalResult);
        }
    }
}
/*Description
http://sandbox.mc.edu/~bennet/cs110/flt/dtof.html
Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float).

Input

On the only line you will receive a decimal number - N
Output

Print the its binary representation on a single line
There should not be leading zeros
Constraints

1 <= N <= 1019
Time limit: 0.1s
Memory limit: 16MB
Example:

number	sign	exponent	mantissa
-27,25	1	10000011	10110100000000000000000
*/
