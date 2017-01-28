using System;

namespace Age
{
    class Age
    {
        static void Main()
        {
            DateTime today = DateTime.Now;
            DateTime birthDay = DateTime.ParseExact(Console.ReadLine(), "MM.dd.yyyy", null);

           // DateTime birthDay = DateTime.Parse(Console.ReadLine());
           if (today.Month > birthDay.Month)
            {
                Console.WriteLine(today.Year - birthDay.Year);
                Console.WriteLine(today.Year - birthDay.Year + 10);
            }

            if (today.Month < birthDay.Month)
            {
                Console.WriteLine(today.Year - birthDay.Year - 1);
                Console.WriteLine(today.Year - birthDay.Year - 1 + 10);
            }
            else
            {
                if (today.Month == birthDay.Month)
                if (today.Day < birthDay.Day)
                    {
                        Console.WriteLine(today.Year - birthDay.Year - 1);
                        Console.WriteLine(today.Year - birthDay.Year - 1 + 10);
                    }
                else
                    {
                        Console.WriteLine(today.Year - birthDay.Year);
                        Console.WriteLine(today.Year - birthDay.Year + 10);
                    }
            }
        }
    }
}
/*Description

Write a program that reads your birthday(in the format MM.DD.YYYY) 
from the console and prints on the console how old you are you now and how old will you be after 10 years.

Input

The input will always consist of a single line - a birthdate.
Output

You should print two lines with one number on the each line:
How old are you now, on the first line.
How old will you be after 10 years, on the second line.
Constraints

The date read from the console will always be in a valid DateTime format.
All dates will be earlier than 2017.
Time limit: 0.1s
Memory limit: 16MB
Sample Tests

Input	    Output
09.05.2016	0
            10
09.16.1994	22
            32
*/