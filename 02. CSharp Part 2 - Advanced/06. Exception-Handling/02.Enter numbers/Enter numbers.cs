using System;

namespace _06._02.Enter_numbers
{
    class Program
    {
        static void Main()
        {
            int[] intArr = new int[12];
            intArr[0] = 1; intArr[11] = 100;
            int start = 1;
            try
            {
                for (int i = 1; i < 11; i++)
                {
                    int end = int.Parse(Console.ReadLine());
                    intArr[i] = ReadNumber(start, end);
                    start = end;
                }
                Console.WriteLine(string.Join(" < ",intArr));
            }
            catch (FormatException)
            {
                Console.WriteLine("Exception");
            }
        }

        static int ReadNumber ( int start, int end)
        {
            if (start >= end || end >= 100)
            {
                throw new FormatException();
            }
            return end;
        }
    }
}
/*Description

Write a method ReadNumber(int start, int end) that enters an integer number in a given range ( start, end ).

If an invalid number or non-number text is entered, the method should throw an exception. 
Using this method write a program that enters 10 numbers: a1, a2, ..., a10, such that 1 < a1 < ... < a10 < 100
Input

You will receive 10 lines of input, each consisted of an integer number
a1
a2
...
a10
Output

Print 1 < a1 < ... < a10 < 100
Or Exception if the above inequality is not true
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
5
7
15
29
46
47
60
70
89
98	        1 < 5 < 7 < 15 < 29 < 46 < 47 < 60 < 70 < 89 < 98 < 100

87
10
29
28
43
58
95
41
2
46	        Exception

5
11
20
27
49
41
52
81
89
99	        Exception
*/