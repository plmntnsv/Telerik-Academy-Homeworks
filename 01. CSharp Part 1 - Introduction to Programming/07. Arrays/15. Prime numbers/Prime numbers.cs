using System;

namespace _07._15.Prime_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int primal = new int();
            int[] arr = new int[n+1];
            
            for (int z = 2; z <= n; z++)
            {
                if (arr[z] == 0)
                {
                    primal = z;
                    for (int h = z + z; h <= n; h += z)
                    {
                        arr[h] = 1;
                    }
                }
                
            }
            Console.WriteLine(primal);
        }
    }
}
/*Description

Write a program that finds all prime numbers in the range [1 ... N]. 
Use the Sieve of Eratosthenes algorithm. The program should print the biggest prime number which is <= N.
https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes

Input

On the first line you will receive the number N
Output

Print the biggest prime number which is <= N
Constraints

2 <= N <= 10 000 000
Time limit: 0.3s
Memory limit: 64MB
Sample tests

Input	Output
13	    13
126	    113
26	    23
*/
