using System;
using System.Linq;
using System.Numerics;

namespace _02._14.Integer_calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
            Console.WriteLine("{0}\n{1}\n{2:F2}\n{3}\n{4}",
                MinElement(numbers), 
                MaxElement(numbers), 
                AverageOfElements(numbers), 
                SumOfElements(numbers), 
                ProductOfElements(numbers));
        }
        static int MinElement(params int[] numbers)
        {
            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            return min;
        }
        static int MaxElement(params int[] numbers)
        {
            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }
        static double AverageOfElements(params int[] numbers)
        {
            double average = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                average += numbers[i];
            }
            average /= (double)numbers.Length;
            return average;
        }
        static int SumOfElements(params int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        static BigInteger ProductOfElements(params int[] numbers)
        {
            BigInteger product = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                product *= numbers[i];
            }
            return product;
        }
    }
}
/*Integer calculations
Description

Write methods to calculate minimum, maximum, average, sum and product of 
given set of integer numbers. Use variable number of arguments. Write a 
program that reads 5 elements and prints their minimum, maximum, average, sum and product.

Input

On the first line you will receive 5 numbers separated by spaces
Output

Print their minimum, maximum, average, sum and product
Each on a new line
The average value should be printed with two digits of precision
Constraints

Each of the five numbers will be in the interval [ -1000, 1000 ]
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	        Output
3 7 9 18 0	    0
                18
                7.40
                37
                0
*/
