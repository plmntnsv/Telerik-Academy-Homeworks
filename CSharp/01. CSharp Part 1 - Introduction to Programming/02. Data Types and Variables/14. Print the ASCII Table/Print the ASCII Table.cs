using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._14.Print_the_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for (char i = (char)33; i <= (char)126; i++)
            {
                Console.Write(i);
            }
        }
    }
}
/*
Find online more information about ASCII (American Standard Code for Information Interchange) 
and write a program that prints the visible characters of the ASCII table on the console (characters from 33 to 126 including).

Note: You may need to use for-loops (learn in Internet how).

Input

None
Output

The 94 characters on single line
Constraints

Time limit: 0.1s
Memory limit: 16MB
 */
