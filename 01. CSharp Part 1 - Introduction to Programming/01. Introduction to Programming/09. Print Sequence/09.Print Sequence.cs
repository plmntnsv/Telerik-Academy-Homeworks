using System;

namespace Print_Sequence
{
    class Program
    {
        static void Main()
        {
            for (int i = 2; i <= 11; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.WriteLine(-i);
                }
            }
        }  
    }
}
/*Description

Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

Input

There will be no input for this task.
Output

Print on the console the first 10 members of the sequence from the description. Print each member on a separate line.
2
-3
4
-5
...
Constraints

Time limit: 0.1s
Memory limit: 16MB
*/