using System;

namespace _06._17.Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrixArr = new int[n, n];
            int col = 0, row = 0;
            string direction = "right";

            for (int i = 1; i <= n * n; i++)
            {
                matrixArr[row, col] = i;
                if (direction == "right" && col < n-1 && matrixArr[row, col+1] == 0)
                {
                    col++;
                }
                else if (direction == "right")
                {
                    row++;
                    direction = "down";
                    continue;
                }
                if (direction == "down" && row < n-1 && matrixArr[row+1, col] == 0)
                {
                    row++;
                }
                else if(direction == "down")
                {
                    col--;
                    direction = "left";
                    continue;
                }
                if (direction == "left" &&  col > 0 && matrixArr[row, col-1] == 0)
                {
                    col--;
                }
                else if (direction == "left")
                {
                    row--;
                    direction = "up";
                    continue;
                }
                if (direction == "up" && row > 0 && matrixArr[row-1, col] == 0)
                {
                    row--;
                }
                else if (direction == "up")
                {
                    col++;
                    direction = "right";
                    continue;
                }
               
            }
            for (int k = 0; k < n; k++)
            {
                for (int z = 0; z < n; z++)
                {
                    Console.Write("{0} ", matrixArr[k,z]);
                }
                Console.WriteLine();
            }
        }
    }
}
/*Description

Write a program that reads from the console a positive integer number N (1 ≤ N ≤ 20) and 
prints a matrix holding the numbers from 1 to N*N in the form of square spiral like in the examples below.

Input

The input will always consist of a single line containing a single number - N.
Output

Output a spiral matrix as described below.
Constraints

N will always be a valid integer number.
1 ≤ N ≤ 20
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
2	    1 2
        4 3
3	    1 2 3
        8 9 4
        7 6 5
4	    1  2  3  4
        12 13 14 5
        11 16 15 6
        10 9  8  7
*/
