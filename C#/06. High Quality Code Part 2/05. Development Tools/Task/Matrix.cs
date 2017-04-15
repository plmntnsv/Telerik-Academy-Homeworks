namespace RotatingWalkInMatrix
{
    using System;
    using System.Text;

    /// <summary>
    /// Draws a matrix starting form the top left corner and going in down-right direction. 
    /// When no continuation is available at the current direction 
    /// the direction is changed to the next possible clockwise. 
    /// The matrix has dimensions size*size or defaults to 3*3.
    /// </summary>
    public class Matrix
    {
        public const int Directions = 8;
        private int size;
        private int[,] matrix;
        private int row = 0;
        private int col = 0;
        private int cellNumber = 1;
        private int nextRow = 1;
        private int nextCol = 1;

        public Matrix(int size = 3)
        {
            this.Size = size;
            this.matrix = new int[size, size];
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid matrix size provided! Size must be an integer above 1.");
                }

                this.size = value;
            }
        }

        /// <summary>
        /// Displays the matrix as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int rows = 0; rows < this.size; rows++)
            {
                for (int cols = 0; cols < this.size; cols++)
                {
                    sb.AppendFormat("{0,3}", this.matrix[rows, cols]);
                }

                if (rows == this.size - 1)
                {
                    continue;
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Fills the matrix with numbers starting from 1.
        /// </summary>
        public void Fill()
        {
            while (true)
            {
                this.matrix[this.row, this.col] = this.cellNumber;

                if (this.AreNeighbouringCellsVisited())
                {
                    // With this the matrix fills correctly and works with bigger sizes than 3.
                    if (!this.FindFreeCell())
                    {
                        break;
                    }
                }

                while (this.row + this.nextRow >= this.size || this.row + this.nextRow < 0 ||
                        this.col + this.nextCol >= this.size || this.col + this.nextCol < 0 ||
                        this.matrix[this.row + this.nextRow, this.col + this.nextCol] != 0)
                {
                    this.ChangeDirection();
                    if (this.nextRow == 0 && this.nextCol == 0)
                    {
                        if (!this.FindFreeCell())
                        {
                            break;
                        }
                    }
                }

                this.row += this.nextRow;
                this.col += this.nextCol;
                this.cellNumber++;
            }
        }

        /// <summary>
        /// Changes the direction of the walk clockwise, if no empty cell is available in the current direction or
        /// the size of the matrix either X or Y is reached.
        /// </summary>
        private void ChangeDirection()
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;

            for (int i = 0; i < Directions; i++)
            {
                if (directionX[i] == this.nextRow && directionY[i] == this.nextCol)
                {
                    currentDirection = i;
                    break;
                }
            }

            // If all possible directions are already visited, check the current cell in which we already are
            if (currentDirection == 7)
            {
                this.nextRow = 0;
                this.nextCol = 0;
                return;
            }

            this.nextRow = directionX[currentDirection + 1];
            this.nextCol = directionY[currentDirection + 1];
        }

        /// <summary>
        /// Searches clockwise for an unfilled neighbouring cell, that is not outside of the matrix, and sets the direction to it.
        /// </summary>
        /// <returns>True if valid free neighbouring cell is found and false if not.</returns>
        private bool AreNeighbouringCellsVisited()
        {
            int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < Directions; i++)
            {
                if (this.row + directionX[i] >= this.size || this.row + directionX[i] < 0)
                {
                    directionX[i] = 0;
                }

                if (this.col + directionY[i] >= this.size || this.col + directionY[i] < 0)
                {
                    directionY[i] = 0;
                }

                if (this.matrix[this.row + directionX[i], this.col + directionY[i]] == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Searches the matrix for unfilled cell.
        /// </summary>
        /// <returns>If found, sets the current row and column to that cell, if not returns false and the matrix is filled.</returns>
        private bool FindFreeCell()
        {
            this.row = 0;
            this.col = 0;

            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        this.row = i;
                        this.col = j;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
