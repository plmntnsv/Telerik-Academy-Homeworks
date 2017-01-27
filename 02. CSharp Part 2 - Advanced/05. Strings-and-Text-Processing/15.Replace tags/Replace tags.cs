using System;
using System.Text;

namespace _05._15.Replace_tags
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine(); /*"<a href=\"http://academy.telerik.com\">Please visit our site</a><a href=\"http://academy.telerik.com\">Please visit our site</a>";*/
            StringBuilder strBldr = new StringBuilder();
            StringBuilder finalResult = new StringBuilder();
            finalResult.Append(input, 0, input.Length);


            int startIndex = input.LastIndexOf("<a href=");

            while (startIndex > -1)
            {
                strBldr.AppendFormat(string.Format("[{0}]({1})", GetText(input, startIndex), GetURL(input, startIndex)));
                finalResult.Remove(startIndex, GetRemoveCount(input, startIndex));
                finalResult.Insert(startIndex, strBldr.ToString());
                strBldr.Clear();

                startIndex = input.LastIndexOf("<a href=", startIndex);

            }
            Console.WriteLine(finalResult);
        }
        static StringBuilder GetURL(string input, int startIndex)
        {
            StringBuilder url = new StringBuilder();
            int endIndex = input.IndexOf('>', startIndex);
            for (int i = startIndex + 9; i < endIndex - 1; i++)
            {
                url.Append(input[i]);
            }
            return url;
        }
        static StringBuilder GetText(string input, int startIndex)
        {
            StringBuilder text = new StringBuilder();
            int textStart = input.IndexOf('>', startIndex),
                textEnd = input.IndexOf("</a>", startIndex);
            for (int i = textStart + 1; i < textEnd; i++)
            {
                text.Append(input[i]);
            }
            return text;
        }
        static int GetRemoveCount(string input, int startIndex)
        {
            int counter = 0;
            for (int i = startIndex; i < input.IndexOf("</a>", startIndex) + 4; i++)
            {
                counter++;
            }
            return counter;
        }
    }
}
/*Description

Write a program that replaces in a HTML document given as string all the tags <a href="URL">TEXT</a> with corresponding markdown notation [TEXT](URL).

Input

On the only input line you will receive a string
Output

Print the string with replaced tags
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                            Output
<p>Please visit <a href="http://academy.telerik.com">our site</a>   <p>Please visit [our site](http://academy.telerik.com)
to choose a training course.                                        to choose a training course.
Also visit <a href="www.devbg.org">our forum</a>                    Also visit [our forum](www.devbg.org)
to discuss the courses.</p>	                                        to discuss the courses.</p>
*/
