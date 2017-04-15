using System;
using RotatingWalkInMatrix;

namespace RotatingWalkInMatrix
{
    public class StartUp
    {
        public static void Main()
        {
            Matrix defaultMatrix = new Matrix();
            defaultMatrix.Fill();
            Console.WriteLine("Matrix of default size 3*3");
            Console.WriteLine(defaultMatrix);

            Console.WriteLine();

            Matrix matrix = new Matrix(5);
            matrix.Fill();
            Console.WriteLine("Matrix of size 5*5");
            Console.WriteLine(matrix);
        }
    }
}
