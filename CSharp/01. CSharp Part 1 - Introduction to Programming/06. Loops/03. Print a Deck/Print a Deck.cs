using System;

namespace _06._03.Print_a_Deck
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n;
            int.TryParse(input, out n);
            if (input.Equals("j", StringComparison.CurrentCultureIgnoreCase))
            {
                n = 11;
            }
            else if (input.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            {
                n = 12;
            }
            else if (input.Equals("k", StringComparison.CurrentCultureIgnoreCase))
            {
                n = 13;
            }
            else if (input.Equals("a", StringComparison.CurrentCultureIgnoreCase))
            {
                n = 14;
            }
            for (int i = 2; i <= n; i++)
            {
                if (i < 11)
                {
                    Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", i);
                }
                else if ( i == 11)
                {
                    Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", "J");
                }
                else if (i == 12)
                {
                    Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", "Q");
                }
                else if (i == 13)
                {
                    Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", "K");
                }
                else if (i == 14)
                {
                    Console.WriteLine("{0} of spades, {0} of clubs, {0} of hearts, {0} of diamonds", "A");
                }

            }
        }
    }
}
/*Description

Write a program that reads a card sign(as a char) from the console and generates and prints all possible cards 
from a standard deck of 52 cards up to the card with the given sign(without the jokers). 
The cards should be printed using the classical notation (like 5 of spades, A of hearts, 9 of clubs; and K of diamonds).

The card faces should start from 2 to A.
Print each card face in its four possible suits: clubs, diamonds, hearts and spades.
Input

On the only line, you will receive the sign of the card to which, including, you should print the cards in the deck.
Output

The output should follow the format bellow(assume our input is 5):  2 of spades, 2 of clubs, 2 of hearts, 2 of diamonds 3 of spades, 3 of clubs, 3 of hearts, 3 of diamonds ... 5 of spades, 5 of clubs, 5 of hearts, 5 of diamonds 
Constraints

The input character will always be a valid card sign.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
5	    2 of spades, 2 of clubs, 2 of hearts, 2 of diamonds
        3 of spades, 3 of clubs, 3 of hearts, 3 of diamonds
        ...
        5 of spades, 5 of clubs, 5 of hearts, 5 of diamonds
*/