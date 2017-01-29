using System;

namespace _05._03.Correct_brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();//"()()(()()())"; "(bb(aaa))b(a(a+b))()";
            //int openBracket = 0,
            //    closeBracket = 0;
            //for (int i = 0; i < input.Length; i++)
            //{
            //    if (input[i] == '(')
            //    {
            //        openBracket++;
            //    }
            //    if (input[i] == ')')
            //    {
            //        closeBracket++;
            //    }
            //}
            //Console.WriteLine(openBracket==closeBracket?"Correct":"Incorrect");
            int startNext = 0;
            bool isItCorrect = true;
            int openBracket = 0,
                closeBracket = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (!isItCorrect)
                {
                    break;
                }
                if (input[i]=='(')
                {
                    openBracket++;
                    if (startNext >= input.Length)
                    {
                        isItCorrect = false;
                        break;
                    }
                    for (int j = startNext; j < input.Length; j++)
                    {
                        if (input[j]==')')
                        {
                            startNext = j+1;
                            break;
                        }
                        if (j >= input.Length - 1)
                        {
                            isItCorrect = false;
                            break;
                        }
                    }
                    
                }
                if (input[i]==')')
                {
                    closeBracket++;
                }
                if (closeBracket>openBracket)
                {
                    isItCorrect = false;
                    break;
                }
            }
            Console.WriteLine(isItCorrect?"Correct":"Incorrect");
        }
    }
}
/*Description

Write a program to check if in a given expression the ( and ) brackets are put correctly.

Input

On the only line you will receive an expression
Output

Print Correct if the brackets are correct
Incorrect otherwise
Constraints

1 <= length of expression <= 10000
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	    Output
((a+b)/5-d)	Correct
)(a+b))	    Incorrect
*/