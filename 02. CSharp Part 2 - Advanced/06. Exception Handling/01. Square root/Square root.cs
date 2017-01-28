using System;

namespace _06._01.Square_root
{
    class Program
    {
        static void Main()
        {
            try
            {
                double input = double.Parse(Console.ReadLine());
                if (input < 0)
                {
                    throw  new FormatException();
                }
                else
                {
                    Console.WriteLine("{0:F3}", Math.Sqrt(input));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
/*Description

Write a program that reads a number and calculates and prints its square root.

If the number is invalid or negative, print Invalid number.
In all cases finally print Good bye. Use try-catch-finally block.
Input

On the only line you will receive a real number
Output

Print the square root of the number or Invalid number on the first line
Use 3 digits of precision
Print Good bye on the second line
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	        Output
number	        Invalid number
                Good bye
4	            2.000
                Good bye
-3.14	        Invalid number
                Good bye
17	            4.123
                Good bye
*/