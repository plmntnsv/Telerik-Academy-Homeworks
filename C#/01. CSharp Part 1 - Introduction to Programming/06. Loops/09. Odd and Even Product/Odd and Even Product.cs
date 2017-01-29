using System;

namespace _06._09.Odd_and_Even_Product
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            string nxtChr = string.Empty;
            long odd, oddFinal = 1, even, evenFinal = 1, oddOrEven = 1;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    nxtChr += str[i];
                }
                else if (oddOrEven % 2 != 0)
                {
                    long.TryParse(nxtChr, out odd);
                    oddFinal *= odd;
                    nxtChr = "";
                    oddOrEven++;
                }
                else
                {
                    long.TryParse(nxtChr, out even);
                    evenFinal *= even;
                    nxtChr = "";
                    oddOrEven++;
                }
                if (i == str.Length-1)
                {
                    if (oddOrEven % 2 != 0)
                    {
                        long.TryParse(nxtChr, out odd);
                        oddFinal *= odd;
                    }
                    else
                    {
                        long.TryParse(nxtChr, out even);
                        evenFinal *= even;
                    }
                }
            }
            if (oddFinal == evenFinal)
            {
                Console.WriteLine("yes {0}", evenFinal);
            }
            else
            {
                Console.WriteLine("no {0} {1}", oddFinal, evenFinal);
            }
        }
    }
}
/*Description

You are given N integers (given in a single line, separated by a space).

Write a program that checks whether the product of the odd elements is equal to the product of the even elements.
Elements are counted from 1 to N, so the first element is odd, the second is even, etc.
Input

On the first line you will receive the number N
On the second line you will receive N numbers separated by a whitespace
Output

If the two products are equal, output a string in the format "yes PRODUCT_VALUE", otherwise write on the console "no ODD_PRODUCT_VALUE EVEN_PRODUCT_VALUE"
Constraints

N will always be a valid integer number in the range [4, 50]
All input numbers from the second line will also be valid integers
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
5
2 1 1 6 3	yes 6
5
4 3 2 5 2	no 16 15
*/
