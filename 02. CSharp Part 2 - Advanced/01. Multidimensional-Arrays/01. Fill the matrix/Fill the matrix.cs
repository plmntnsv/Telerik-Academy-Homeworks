using System;

namespace _01.Multidim_Arrays._01.Fill_the_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char ch = (char)Console.Read();
            int[,] arr = new int[n, n];
            int counter = 1;
            switch (ch)
            {
                case 'a':
                    //1	  5	  9	  13
                    //2   6   10  14
                    //3   7   11  15
                    //4   8   12  16
                    for (int cols = 0; cols < n; cols++)
                    {
                        for (int rows = 0; rows < n; rows++)
                        {
                            arr[rows, cols] = counter;
                            counter++;
                        }
                    }
                    break;
                case 'b':
                    //1   8   9   16
                    //2   7   10  15
                    //3   6   11  14
                    //4   5   12  13
                    for (int cols = 0; cols < n; cols++)
                    {
                        if (cols % 2 == 0)
                        {
                            for (int rows = 0; rows < n; rows++)
                            {
                                arr[rows, cols] = counter;
                                counter++;

                            }
                        }
                        else
                        {
                            for (int rows = n - 1; rows >= 0; rows--)
                            {
                                arr[rows, cols] = counter;
                                counter++;

                            }
                        }


                    }
                    break;
                case 'c':
                    //   0   1   2   3
                    //0  7	 11	 14	 16
                    //1  4   8   12  15
                    //2  2   5   9   13
                    //3  1   3   6   10
                    for (int startRow = n - 1; startRow >= 0; startRow--) //dolna polovina + sreda
                    {
                        int row = startRow,
                        col = 0;
                        while (col != n - startRow)
                        {
                            arr[row, col] = counter;
                            counter++;
                            row++;
                            col++;
                        }
                    }

                    for (int startCol = 1; startCol <= n - 1; startCol++) // gorna polovina
                    {
                        int row = 0,
                            col = startCol;
                        while (col != n)
                        {
                            arr[row, col] = counter;
                            counter++;
                            row++;
                            col++;
                        }
                    }
                    break;
                case 'd':
                    //   0  1   2   3
                    //0  1  12  11  10
                    //1  2  13  16  9
                    //2  3  14  15  8
                    //3  4  5   6   7
                    string direction = "down";
                    int rowD = 0, colD = 0;
                    while (counter != n*n+1)
                    {
                        if ((direction == "down" && rowD < n) && arr[rowD,colD] == 0)
                        {
                            arr[rowD, colD] = counter;
                            counter++;
                            rowD++;
                        }
                        else if (direction == "down")
                        {
                            direction = "right";
                            rowD--;
                            colD++;
                            continue;
                        }

                        if ((direction == "right" && colD<n)&& arr[rowD,colD]==0)
                        {

                            arr[rowD, colD] = counter;
                            counter++;
                            colD++;
                        }
                        else if(direction == "right")
                        {
                            direction = "up";
                            colD--;
                            rowD--;
                            continue;
                        }

                        if ((direction == "up" && rowD >= 0) && arr[rowD, colD] == 0)
                        {

                            arr[rowD, colD] = counter;
                            counter++;
                            rowD--;
                        }
                        else if (direction == "up")
                        {
                            direction = "left";
                            colD--;
                            rowD++;
                            continue;
                        }

                        if ((direction == "left" && colD >= 0) && arr[rowD, colD] == 0)
                        {

                            arr[rowD, colD] = counter;
                            counter++;
                            colD--;
                        }
                        else if (direction == "left")
                        {
                            direction = "down";
                            colD++;
                            rowD++;
                            continue;
                        }
                    }
                   
                    break;
                default:
                    Console.WriteLine("-1");
                    break;
            }
            //output
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("{0}", arr[i, j]);
                    }
                    else
                    {
                        Console.Write(" {0}", arr[i, j]);
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
/*Description

Write a program that fills and prints a matrix of size (n, n) as shown below.

Input

On the first line you will receive the number N
On the second line you will receive a character (a, b, c, d*) which determines how to fill the matrix
Output

Print the matrix
Numbers on a row must be separated by a single spacebar
Each row must be on a new line
Constraints

1 <= N <= 128
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
4
a	
1	5	9	13
2	6	10	14
3	7	11	15
4	8	12	16
4
b	
1	8	9	16
2	7	10	15
3	6	11	14
4	5	12	13
4
c	
7	11	14	16
4	8	12	15
2	5	9	13
1	3	6	10
4
d	
1	12	11	10
2	13	16	9
3	14	15	8
4	5	6	7
*/
