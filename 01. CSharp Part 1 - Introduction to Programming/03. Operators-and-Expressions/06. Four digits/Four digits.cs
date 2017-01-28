using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._06.Four_digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int firstDigit = (n / 1000),
                secondDigit = ((n / 100) % 10),
                thirdDigit = (((n % 1000) % 100) / 10),
                fourthDigit = (n % 10);
            int sum =  firstDigit + secondDigit + thirdDigit + fourthDigit;
            string reversed = ""+fourthDigit +thirdDigit+secondDigit+firstDigit;
            string reversed2 =  fourthDigit.ToString()+thirdDigit.ToString()+secondDigit.ToString()+firstDigit.ToString();
            string lastDigitFirst = fourthDigit.ToString() + firstDigit.ToString() + secondDigit.ToString() + thirdDigit.ToString();
            string exchSecondThird = firstDigit.ToString() + thirdDigit.ToString() + secondDigit.ToString()+ fourthDigit.ToString();
            Console.WriteLine("{0}\n{1}\n{2}\n{3}",sum, reversed, lastDigitFirst, exchSecondThird);
        }
    }
}
/*Description

Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:

Calculates the sum of the digits (in our example 2 + 0 + 1 + 1 = 4) and prints it on the console.
Prints on the console the number in reversed order: dcba (in our example 1102) and prints the reversed number.
Puts the last digit in the first position: dabc (in our example 1201) and prints the result.
Exchanges the second and the third digits: acbd (in our example 2101) and prints the result.
Input

The input will consist of a single four-digit integer number on a single line.
Output

Output the result of each action on a separate line, in the same order as they are explained above:
meaning the sum comes on the first line, the reversed number on the second, and so on.
Constraints

The number will always be a valid positive four-digit integer.
The number will always start with a digit other than 0.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
2011	4
        1102
        1201
        2101
3333	12
        3333
        3333
        3333
9876	30
        6789
        6987
        9786
1230	6
        0321
        0123
        1320
*/