namespace _02.Defining_Classes___Part_2
{
    using System;
    using System.Text;

    public class Matrix<T> where T : struct
    {
        // Field
        private T[,] matrix;

        //Constructor
        public Matrix(int columns, int rows)
        {
            this.Columns = columns;
            this.Rows = rows;
            this.matrix = new T[this.Rows, this.Columns];
        }

        // Properties
        public int Rows { get; }

        public int Columns { get; }

        public T this[int rowIndex, int colIndex]
        {
            get
            {
                return matrix[rowIndex, colIndex];
            }
            set
            {
                if (rowIndex < 0 || rowIndex > this.Rows - 1)
                {
                    throw new IndexOutOfRangeException("The row index is outside the boundaries of the array.");
                } else if (colIndex < 0 || colIndex > this.Columns - 1)
                {
                    throw new IndexOutOfRangeException("The column index is outside the boundaries of the array.");
                }

                this.matrix[rowIndex, colIndex] = value;
            }
        }

        // Methods
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Rows != secondMatrix.Columns || firstMatrix.Rows != secondMatrix.Rows || firstMatrix.Columns != secondMatrix.Columns)
            {
                throw new ArgumentException("Both matrices must have the same size to be added!");
            }
            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Rows);
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Columns; j++)
                {
                    resultMatrix[i, j] = (dynamic)firstMatrix[i, j] + secondMatrix[i, j];
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Rows != secondMatrix.Columns || firstMatrix.Rows != secondMatrix.Rows || firstMatrix.Columns != secondMatrix.Columns)
            {
                throw new ArgumentException("Both matrices must have the same size to be subtracted!");
            }
            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, firstMatrix.Rows);
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Columns; j++)
                {
                    resultMatrix[i, j] = (dynamic)firstMatrix[i, j] - secondMatrix[i, j];
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Rows != secondMatrix.Columns)
            {
                throw new ArgumentException("The rows of the first matrix must equal the colums of the second to be multiplied!");
            }
            Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Rows, secondMatrix.Columns);
            T temp = default(T);
            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < secondMatrix.Columns; j++)
                {
                    for (int k = 0; k < firstMatrix.Rows + 1; k++)
                    {
                        temp += (dynamic)firstMatrix[i, k] * secondMatrix[k, j];
                    }
                    resultMatrix[i, j] = temp;
                    temp = default(T);
                }
            }
            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] != (dynamic)0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] != (dynamic)0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Fill(int number = 0)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    this[i, j] = (dynamic)i + j + number;
                }
            }
        }

        public void Fill(float number = 0f)
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    this[i, j] = (dynamic)i + j + number;
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    if (j > 0)
                    {
                        result.Append(" ");
                    }
                    result.Append(this[i, j]);
                }
                if (i != this.Rows - 1)
                {
                    result.AppendLine();
                }
            }
            return result.ToString();
        }
    }
}
