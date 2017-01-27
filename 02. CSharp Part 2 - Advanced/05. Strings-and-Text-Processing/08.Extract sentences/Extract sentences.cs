using System;
using System.Text;

namespace _05._08.Extract_sentences
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string[] strArr = Console.ReadLine().Split(new string[] { "."}, StringSplitOptions.RemoveEmptyEntries);
            char[] splitters = new char[43];
            int pos = 0;
            for (int i = 0; i < 128; i++)
            {
                if ((i > 31 && i < 65) || (i > 90 && i < 97) || (i > 122 && i < 127))
                {
                    splitters[pos] = (char)i;
                    pos++;
                }
                
            }
            StringBuilder strBuild = new StringBuilder();
           
            foreach (string sentence in strArr)
            {
                string[] words = sentence.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (word == pattern)
                    {
                        strBuild.Append(sentence.Trim()+". ");
                        break;
                    }
                }
            }
            Console.WriteLine(strBuild);
        }
    }
}
/*Description

Write a program that extracts from a given text all sentences containing given word.

Input

On the first line you will receive a string - the word
On the second line you will receive a string - the text
Output

Print only the sentences containing the word on a single line
Constraints

Sentences are separated by . and the words – by non-letter symbols
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                                Output
in
We are living in a yellow submarine. We don't have anything else.       We are living in a yellow submarine.
Inside the submarine is very tight.                                     We will move out of it in 5 days.
So we are drinking all the day. We will move out of it in 5 days.	 
*/
