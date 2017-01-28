using System;
using System.Linq;

namespace _01.Multidim_Arrays._03.Seq_in_mtrx
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            string[] matrixDimensions = Console.ReadLine().Split(' ').ToArray();
           
            int rows = 0, cols = 0;

            for (int i = 0; i < matrixDimensions.Length; i++)
            {
                if (i == 0)
                {
                    rows = int.Parse(matrixDimensions[i]);
                }
                else
                {
                    cols = int.Parse(matrixDimensions[i]);
                }
            }
            int[,] matrix = new int[rows, cols];
            

            for (int i = 0; i < rows; i++)
            {
                string[] matrixNumbers = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(matrixNumbers[j]);
                }
            }
            //int rows = 6, cols = 6;
            //int[,] matrix = new int[,]
            //    {
            //     { 1, 2, 3, 4, 5, 1 },
            //     { 7, 8, 9, 10, 1, 12 },
            //     { 13, 14, 15, 1, 17, 18 },
            //     { 19, 20, 21, 22, 23, 24 },
            //     { 25, 26, 27, 28, 29, 30 },
            //     { 31, 32, 33, 34, 35, 36 },
            //    };
            //logic
            int currentCount = 1,
                biggestCount = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int currentNumber = matrix[i, j];
                    //check down \/
                    if (i < rows-1 && matrix[i + 1, j] == currentNumber)
                    {
                        int row = i, col = j;
                        while (row < rows - 1)
                        {
                            if (matrix[row + 1, col] == currentNumber)
                            {
                                currentCount++;
                                row++;
                            }
                            else
                            {
                                if (currentCount > biggestCount)
                                {
                                    biggestCount = currentCount;
                                    currentCount = 1;
                                }
                                currentCount = 1;
                                break;
                            }
                        }
                        if (currentCount > biggestCount)
                        {
                            biggestCount = currentCount;
                        }
                        currentCount = 1;
                    }
                    //check right >
                    if (j < cols-1 && matrix[i, j + 1] == currentNumber)
                    {
                        int row = i, col = j;
                        while (col < cols - 1)
                        {
                            if (matrix[row, col + 1] == currentNumber)
                            {
                                currentCount++;
                                col++;
                            }
                            else
                            {
                                if (currentCount > biggestCount)
                                {
                                    biggestCount = currentCount;
                                    currentCount = 1;
                                }
                                currentCount = 1;
                                break;
                            }
                        }
                        if (currentCount > biggestCount)
                        {
                            biggestCount = currentCount;
                        }
                        currentCount = 1;
                    }
                    //check diagonal right \
                    if (i < rows-1 &&  j < cols-1 && matrix[i + 1, j + 1] == currentNumber)
                    {
                        int row = i, col = j;
                        while (col < cols - 1 && row < rows - 1)
                        {
                            if (matrix[row + 1, col + 1] == currentNumber)
                            {
                                currentCount++;
                                col++;
                                row++;
                            }
                            else
                            {
                                if (currentCount > biggestCount)
                                {
                                    biggestCount = currentCount;
                                    currentCount = 1;
                                }
                                currentCount = 1;
                                break;
                            }
                        }
                        if (currentCount > biggestCount)
                        {
                            biggestCount = currentCount;
                        }
                        currentCount = 1;
                    }
                    //check diagonal left /
                    if (i < rows-1 && j > 0 && matrix[i + 1, j - 1] == currentNumber)
                    {
                        int row = i, col = j;
                        while (col > 0 && row < rows - 1)
                        {
                            if (matrix[row + 1, col - 1] == currentNumber)
                            {
                                currentCount++;
                                col--;
                                row++;
                            }
                            else
                            {
                                if (currentCount > biggestCount)
                                {
                                    biggestCount = currentCount;
                                    currentCount = 1;
                                }
                                currentCount = 1;
                                break;
                            }
                        }
                        if (currentCount > biggestCount)
                        {
                            biggestCount = currentCount;
                        }
                        currentCount = 1;
                    }
                }
            }
            Console.WriteLine(biggestCount);
        }
    }
}
/*Sequence in matrix
Description

We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several 
neighbour elements located on the same line, column or diagonal. Write a program that finds the longest 
sequence of equal strings in the matrix and prints its length.

Input

On the first line you will receive the numbers N and M separated by a single space
On the next N lines there will be M strings separated with spaces - the strings in the matrix
Output

Print the length of the longest sequence of equal equal strings in the matrix
Constraints

3 <= N, M <= 128
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	            Output
6 6
92 11 23 42 59 48
09 92 23 72 56 14
17 63 92 46 85 95
34 12 52 69 23 95
26 88 78 71 29 95
26 34 16 63 39 95	4
*/