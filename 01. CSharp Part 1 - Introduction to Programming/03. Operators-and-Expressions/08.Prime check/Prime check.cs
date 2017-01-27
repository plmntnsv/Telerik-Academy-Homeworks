using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._08.Prime_check
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            bool isPrime = true;
            if (num <= 1)
            {
                Console.WriteLine("false");
            }
            else
            {
                if (num == 2 || num == 3)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    for (int i = 2; i <= Math.Sqrt(num); i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                        
                           
                    }
                    //if (isPrime)
                    //{
                    //    Console.WriteLine("true");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("false");
                    //}

                    Console.WriteLine(isPrime ? "true" : "false");

                }
            }
        }
    }
}
/*Description

Write a program that reads an integer N (which will always be less than 100 or equal) and uses an expression to check 
if given N is prime (i.e. it is divisible without remainder only to itself and 1).

Note: You should check if the number is positive
Input

On the only input line you will receive the number N.
Output

Output true if the number is prime and false otherwise.
Constraints

N will always be a valid 32-bit integer number, which will be less than 100 or equal.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
2	true
23	true
-3	false
0	false
1	false
*/