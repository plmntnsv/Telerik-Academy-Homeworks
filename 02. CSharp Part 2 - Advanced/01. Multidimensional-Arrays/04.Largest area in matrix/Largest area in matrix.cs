using System;
using System.Linq;

namespace _01.Multi_Arrs._04.Lrgst_area_mtrx
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            string[] matrixDimensions = Console.ReadLine().Split(' ').ToArray();
            int rows = int.Parse(matrixDimensions[0]), cols = int.Parse(matrixDimensions[1]);
            
            int[,] matrix = new int[rows, cols];
            int[,] matrixChecker = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] matrixNumbers = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(matrixNumbers[j]);
                }
            }
            int biggestCounter = 1, currentCounter = 1;
            //int rows = 5, cols = 5;

            //int[,] matrix = new int[,]
            //    {
            //     { 2, 2, 1, 2, 2 },
            //     { 2, 1, 1, 1, 2 },
            //     { 1, 1, 1, 1, 1 },
            //     { 2, 1, 1, 1, 3 },
            //     { 2, 2, 1, 2, 2 },
            //    };
            //int[,] matrixChecker = new int[rows, cols];

            int cells = rows * cols;
            for (int i = 0; i < rows; i++)
            {
                if (biggestCounter >= cells)
                {
                    break;
                }
                for (int j = 0; j < cols; j++)
                {
                    if (biggestCounter >= cells)
                    {
                        break;
                    }
                    int currRow = i, currCol = j,
                        currentNumber = matrix[i, j],
                        posInQueue = 1;
                        //postMinusOne = posInQueue & (~(1 << 0));
                    while (true)
                    {
                        //check right
                        if (currCol < cols - 1 && (matrix[currRow, currCol + 1] == currentNumber && matrixChecker[currRow, currCol + 1] == 0))
                        {
                            matrixChecker[currRow, currCol] = posInQueue;
                            posInQueue++;
                            currCol++;
                            currentCounter++;
                            cells--;
                        }
                        //check down
                        else if (currRow < rows - 1 && (matrix[currRow + 1, currCol] == currentNumber && matrixChecker[currRow + 1, currCol] == 0))
                        {
                            matrixChecker[currRow, currCol] = posInQueue;
                            posInQueue++;
                            currRow++;
                            currentCounter++;
                            cells--;
                        }
                        //check left
                        else if (currCol > 0 && (matrix[currRow, currCol - 1] == currentNumber && matrixChecker[currRow, currCol - 1] == 0))
                        {
                            matrixChecker[currRow, currCol] = posInQueue;
                            posInQueue++;
                            currCol--;
                            currentCounter++;
                            cells--;
                        }
                        //check up
                        else if (currRow > 0 && (matrix[currRow - 1, currCol] == currentNumber && matrixChecker[currRow - 1, currCol] == 0))
                        {
                            matrixChecker[currRow, currCol] = posInQueue;
                            posInQueue++;
                            currRow--;
                            currentCounter++;
                            cells--;
                        }
                        //go back
                        else
                        {
                            //check back right
                            if (currCol < cols - 1 && (matrix[currRow, currCol + 1] == currentNumber && matrixChecker[currRow, currCol + 1] == (posInQueue & (~(1<<1)))))
                            {
                                posInQueue--;
                                matrixChecker[currRow, currCol] = -1;
                                currCol++;
                            }
                            //check back down
                            else if (currRow < rows - 1 && (matrix[currRow + 1, currCol] == currentNumber && matrixChecker[currRow + 1, currCol] == (posInQueue & (~(1 << 1)))))
                            {
                                posInQueue--;
                                matrixChecker[currRow, currCol] = -1;
                                currRow++;
                            }
                            //check back left
                            else if (currCol > 0 && (matrix[currRow, currCol - 1] == currentNumber && matrixChecker[currRow, currCol - 1] == (posInQueue & (~(1 << 1)))))
                            {
                                posInQueue--;
                                matrixChecker[currRow, currCol] = -1;
                                currCol--;
                            }
                            //check back up
                            else if (currRow > 0 && (matrix[currRow - 1, currCol] == currentNumber && matrixChecker[currRow - 1, currCol] == (posInQueue & (~(1 << 1)))))
                            {
                                posInQueue--;
                                matrixChecker[currRow, currCol] = -1;
                                currRow--;
                            }
                            else
                            {
                                matrixChecker[currRow, currCol] = -1;
                                break;
                            }
                        }
                    }
                    if (currentCounter > biggestCounter)
                    {
                        biggestCounter = currentCounter;
                    }
                    currentCounter = 1;

                }
            }
            Console.WriteLine(biggestCounter);
        }
    }
}
/*Description
https://www.youtube.com/watch?v=iaBEKo5sM7w
Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.

Input

On the first line you will receive the numbers N and M separated by a single space
On the next N lines there will be M numbers separated with spaces - the elements of the matrix
Output

Print the size of the largest area of equal neighbour elements
Constraints

3 <= N, M <= 1024
Time limit: 0.35s
Memory limit: 24MB
Sample tests

Input	            Output
5 6
1  3* 2  2  2  4
3* 3* 3* 2  4  4
4  3* 1  2  3* 3*
4  3* 1  3* 3* 1
4  3* 3* 3* 1  1	    13
Hint: you can use the algorithm Depth-first search or Breadth-first search.
*/
