using System;

namespace _07._12.Index_of_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();//"telerikacademy";

            //1 
            char[] indexOfLetters = new char[26];
            for (int i = 0; i < 26; i++)
            {
                indexOfLetters[i] = (char)(i+97);
            }
            foreach (char letter in input)
            {
                Console.WriteLine(Array.IndexOf(indexOfLetters, letter));
            }

            //2
            foreach (var letter in input)
            {
                Console.WriteLine(letter - 97);
            }
        }
    }
}
/*Description

Write a program that creates an array containing all letters from the alphabet (a-z). 
Read a word from the console and print the index of each of its letters in the array.

Input

On the first line you will receive the word
Output

Print the index of each of the word's letters in the array
Each index should be on a new line
Constraints

1 <= word length <= 128
Word is consisted of lowercase english letters
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	        Output
telerikacademy	19
                4
                11
                4
                17
                8
                10
                0
                2
                0
                3
                4
                12
                24
*/