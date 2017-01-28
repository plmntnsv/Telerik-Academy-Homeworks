using System;

namespace _06._16.Trailing_0_in_N_
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()),
            result = 0,
            power = 1;
            
            while ( n / Math.Pow(5, power) > 1)
            {
                result += n / (int)Math.Pow(5, power);
                power++;
            }
            Console.WriteLine(result);
        }
    }
}
/*Description

Write a program that calculates with how many zeroes the factorial of a given number N has at its end.

Your program should work well for very big numbers, e.g. N = 100000.
Input

On the only input line, you will receive a single integer - the number N
Output

Output a single number - the count of trailing zeroes for the N!
Constraints

N will always be a valid positive integer number.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output	Explanation
10	    2	    3628800
20	    4	    2432902008176640000
100000	24999	think why
*/
/*
Take the number that you've been given the factorial of.
Divide by 5; if you get a decimal, truncate to a whole number.
Divide by 5^2 = 25; if you get a decimal, truncate to a whole number.
Divide by 5^3 = 125; if you get a decimal, truncate to a whole number.
Continue with ever-higher powers of 5, until your division results in a number less than 1. Once the division is less than 1, stop.
Sum all the whole numbers you got in your divisions. This is the number of trailing zeroes.
Here's how the process works:

How many trailing zeroes would be found in 4617!, upon expansion?
I'll apply the procedure from above:

5^1 :  4617 ÷ 5 = 923.4, so I get 923 factors of 5
5^2 :  4617 ÷ 25 = 184.68, so I get 184 additional factors of 5
5^3 :  4617 ÷ 125 = 36.936, so I get 36 additional factors of 5
5^4 :  4617 ÷ 625 = 7.3872, so I get 7 additional factors of 5
5^5 :  4617 ÷ 3125 = 1.47744, so I get 1 more factor of 5
5^6 :  4617 ÷ 15625 = 0.295488, which is less than 1, so I stop here.
Then 4617! has 923 + 184 + 36 + 7 + 1 = 1151 trailing zeroes.
*/
