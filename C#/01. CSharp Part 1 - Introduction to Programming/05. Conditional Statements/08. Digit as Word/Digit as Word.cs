using System;

namespace _05._08.Digit_as_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            switch (n)
            {
                case "0":
                    Console.WriteLine("zero");
                    break;
                case "1":
                    Console.WriteLine("one");
                    break;
                case "2":
                    Console.WriteLine("two");
                    break;
                case "3":
                    Console.WriteLine("three");
                    break;
                case "4":
                    Console.WriteLine("four");
                    break;
                case "5":
                    Console.WriteLine("five");
                    break;
                case "6":
                    Console.WriteLine("six");
                    break;
                case "7":
                    Console.WriteLine("seven");
                    break;
                case "8":
                    Console.WriteLine("eight");
                    break;
                case "9":
                    Console.WriteLine("nine");
                    break;
                default:
                    Console.WriteLine("not a digit");
                    break;
            }
        }
    }
}
/*Description

Write a program that read a digit [0-9] from the console, and depending on the input, shows the digit as a word (in English).

Print "not a digit" in case of invalid input.
Use a switch statement.
Input

The input consists of one line only, which contains the digit.
Output

Output a single line - should the input be a valid digits, print the english word for the digits. Otherwise, print "not a digit".
Constraints

The input will never be an empty line.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
-0.1	not a digit
1	one
9	nine
-9	not a digit
kek	not a digit
*/