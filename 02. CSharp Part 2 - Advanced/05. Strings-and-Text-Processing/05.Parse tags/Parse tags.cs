using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._05.Parse_tags
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); //"We are living in a <upcase>yellow submarine</upcase>.We don't have <upcase>anything</upcase> else."; 
            string result = "";
            int startIndex = 0,
                endIndex = 0;
            while (true)
            {
                startIndex = input.IndexOf("<upcase>", startIndex);
                if (startIndex < 0)
                {
                    break;
                }
                endIndex = input.IndexOf("</upcase>", endIndex);
                int count = 0;
                for (int i = startIndex+8; i < endIndex; i++)
                {
                    result += input[i];
                    count++;
                }
                input = input.Remove(startIndex, count + 17);
                input = input.Insert(startIndex, result.ToUpper());
                result = "";
                count = 0;
            }
            Console.WriteLine(input);
        }
    }
}
/*Description

You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to upper-case.

Input

On the only line you will receive a string - the text
Output

Print the changed string on one line
Constraints

The tags will not be nested.
String length will be <= 10000
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                Output
We are living in a <upcase>yellow submarine</upcase>.   We are living in a YELLOW SUBMARINE.
We don't have <upcase>anything</upcase> else.	        We don't have ANYTHING else.
*/
