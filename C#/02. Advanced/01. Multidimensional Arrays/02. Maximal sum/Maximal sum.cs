using System;
using System.Linq;

namespace _01.Multidim_Arrays._02.Maximal_sum
{
    class Program
    {
        static void Main(string[] args)
        {
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
            

            int currentSum = int.MinValue,
            biggestSum = int.MinValue;
            
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                                 matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                                 matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > biggestSum)
                    {
                        biggestSum = currentSum;
                        currentSum = int.MinValue;
                    }
                }
            }
            Console.WriteLine(biggestSum);
        }
    }
}
/*Description

Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements. Print that sum.

Input

On the first line you will receive the numbers N and M separated by a single space
On the next N lines there will be M numbers separated with spaces - the elements of the matrix
Output

Print the maximal sum of 3 x 3 square
Constraints

3 <= N, M <= 1024
Numbers in the matrix will be in the interval [ -1000, 1000 ]
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
3 3
4 3 5
2 6 4
8 2 7	41


5 5
 1  1  3  3  5
-6 -7  2 -3 -1
 3  0 -4  5  9
 7 -7  0  1  0
-7 -6 -4 -4  9
*/
