using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._11.Adding_polynomials
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] polynomArr1 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray(),
                  polynomArr2 = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            CalculateSumOfPolynoms(n, polynomArr1, polynomArr2);
        }
        static void CalculateSumOfPolynoms (int n, int[] arr1, int[] arr2)
        {
            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = arr1[i] + arr2[i];
            }
            Console.WriteLine(string.Join(" ",result));
        }
        static void CalculateSumOfPolynoms(int n, int[] arr1, int[] arr2, char operation)
        {
            int[] result = new int[n];
            if (operation =='-')
            {
                for (int i = 0; i < n; i++)
                {
                    result[i] = arr1[i] - arr2[i];
                }
                Console.WriteLine(string.Join(" ", result));
            }
            else if (operation == '*')
            {
                for (int i = 0; i < n; i++)
                {
                    result[i] = arr1[i] * arr2[i];
                }
                Console.WriteLine(string.Join(" ", result));
            }
        }
    }
}
/*Description

Write a method that adds two polynomials. Represent them as arrays of their coefficients. Write a program that reads two polynomials and prints their sum.

Input

On the first line you will receive the number N
On the second line you will receive the first polynomial as coefficients separated by spaces
On the third line you will receive the second polynomial as coefficients separated by spaces
Output

Print the sum of the polynomials
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
3
5 0 1
7 4 -3	12 4 -2
Example explanation:

x2 + 5 = 1x2 + 0x + 5 => {5, 0, 1}

-3x2 + 4x + 7 = -3x2 + 4x + 7 => {7, 4, -3}

(x2 + 5) + (-3x2 + 4x + 7) = (-2x2 + 4x + 12) = -2x2 + 4x + 12 => {12, 4, -2}
*/