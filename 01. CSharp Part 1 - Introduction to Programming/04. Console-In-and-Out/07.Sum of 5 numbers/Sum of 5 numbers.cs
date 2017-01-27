using System;

namespace _04._07.Sum_of_5_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine()),
                b = int.Parse(Console.ReadLine()),
                c = int.Parse(Console.ReadLine()),
                d = int.Parse(Console.ReadLine()),
                f = int.Parse(Console.ReadLine());
            Console.WriteLine(a+b+c+d+f);
        }
    }
}
/*Description

Write a program that reads 5 integer numbers from the console and prints their sum.

Input

You will receive 5 numbers on five separate lines.

Output

Your output should consist only of a single line - the sum of the 5 numbers.

Constraints

All 5 numbers will always be valid integer numbers between -1000 and 1000, inclusive
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
1
2
3
4
5	15
-1
2
-3
4
10	12
0
0
0
0
0	0
*/