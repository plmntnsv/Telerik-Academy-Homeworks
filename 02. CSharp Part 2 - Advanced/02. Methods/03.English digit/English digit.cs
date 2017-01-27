using System;

namespace _01._03.English_digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(digitAsWord(number % 10));
        }

        static string digitAsWord(int digit)
        {
            string result = "";
            switch (digit)
            {
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
                default:
                    result = "zero";
                    break;
            }
            return result;
        }
    }
}
/*Description

Write a method that returns the last digit of given integer as an English word. 
Write a program that reads a number and prints the result of the method.

Input

On the first line you will receive a number
Output

Print the last digit of the number as an English word
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
42	    two
*/
