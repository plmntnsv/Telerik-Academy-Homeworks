using System;

namespace _07._03.Compare_char_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string strArrOne = Console.ReadLine(),
                   strArrTwo = Console.ReadLine();

            if (strArrOne == strArrTwo)
            {
                Console.WriteLine("=");
            }
            else
            {
                for (int i = 0; i < Math.Min(strArrOne.Length, strArrTwo.Length); i++)
                {
                    if (strArrOne[i] < strArrTwo[i])
                    {
                        Console.WriteLine("<");
                        break;
                    }
                    else if (strArrOne[i] > strArrTwo[i])
                    {
                        Console.WriteLine(">");
                        break;
                    }
                    else if (i == Math.Min(strArrOne.Length-1, strArrTwo.Length-1))
                    {
                        Console.WriteLine(strArrOne.Length < strArrTwo.Length ? "<" : ">");
                    }
                }
            }
        }
    }
}
/*Write a program that compares two char arrays lexicographically (letter by letter).

Input

On the first line you will receive the first char array as a string
On the second line you will receive the second char array as a string
Output

Print < if the first array is lexicographically smaller
Print > if the second array is lexicographically smaller
Print = if the arrays are equal
Constraints

1 <= size of arrays <= 128
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
hello
halo	>
food
food	=
*/
