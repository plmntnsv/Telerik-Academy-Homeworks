using System;

namespace _06._15.GCD
{
    class GCD
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputArr = input.Split(' ');
            int[] arr = new int[inputArr.Length];
           
            for (int i = 0; i < 2; i++)
            {
                arr[i] = int.Parse(inputArr[i]);
            }
            //1st way -> subtraction
            while (arr[0] != arr[1])
            {
                if (arr[0] > arr[1])
                {
                    arr[0] = arr[0] - arr[1];
                }
                else
                {
                    arr[1] = arr[1] - arr[0];
                }
                
            }
            Console.WriteLine(arr[0]);
            //2nd way -> divisions
            while (arr[0] % arr[1] != 0)
            {
                if (arr[0] > arr[1])
                {
                    arr[0] = arr[0] % arr[1];
                }
                else
                {
                    arr[1] = arr[1] % arr[0];
                }

            }
            Console.WriteLine(arr[0]);
        }
    }
}
/*Description

Write a program that calculates the greatest common divisor (GCD) of given two integers A and B.

Use the Euclidean algorithm (find it in Internet).
Input

On the first and only line of the input you will receive the 2 integers A and B, separated by a whitespace.
Output

Output a single number - the GCD of the numbers A and B.
Constraints

The numbers A and B will always be valid integers in the range [2, 500].
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
3 2	    1
60 40	20
5 15	5
*/