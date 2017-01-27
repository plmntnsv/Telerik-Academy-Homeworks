namespace _02.Defining_Classes___Part_2
{
    using System;

    public static class TestMatrix
    {
        public static void Test()
        {
            // Creating, filling and displaying two matrices
            Matrix<int> testMatrixOne = new Matrix<int>(3, 3);
            Matrix<int> testMatrixTwo = new Matrix<int>(3, 3);
            Matrix<int> operationMatrix = new Matrix<int>(3, 3);
            // Filling the first matrix
            Console.WriteLine("First matrix:");
            testMatrixOne.Fill(2);
            Console.WriteLine(testMatrixOne);
            // Filling the second matrix
            Console.WriteLine("Second matrix:");
            testMatrixTwo.Fill(5);
            Console.WriteLine(testMatrixTwo);

            // Add two matrices together
            Console.WriteLine("First + Second:");
            operationMatrix = testMatrixOne + testMatrixTwo;
            Console.WriteLine(operationMatrix);

            // Substract two matrices
            Console.WriteLine("First - Second:");
            operationMatrix = testMatrixOne - testMatrixTwo;
            Console.WriteLine(operationMatrix);

            // Creating and multiplying two matrices
            Matrix<int> testMatrixOneMultiply = new Matrix<int>(3, 2);
            Matrix<int> testMatrixTwoMultiply = new Matrix<int>(2, 3);
            Matrix<int> multipliedMatrix = new Matrix<int>(2, 2);
            testMatrixOneMultiply.Fill(1);
            testMatrixTwoMultiply.Fill(3);
            Console.WriteLine("First multiply matrix:");
            Console.WriteLine(testMatrixOneMultiply);
            Console.WriteLine("Second multiply matrix:");
            Console.WriteLine(testMatrixTwoMultiply);
            Console.WriteLine("First * Second:");
            multipliedMatrix = testMatrixOneMultiply * testMatrixTwoMultiply;
            Console.WriteLine(multipliedMatrix);

            // Implement true operator
            Console.WriteLine("Implement true operator:");
            if (testMatrixOne)
            {
                Console.WriteLine("There are non-zero elements in\n{0}", testMatrixOne);
            }
            else
            {
                Console.WriteLine("There aren't any non-zero elements in\n{0}", testMatrixOne);
            }

            Matrix<double> testMatrixBool = new Matrix<double>(3, 3);
            if (testMatrixBool)
            {
                Console.WriteLine("There are non-zero elements in\n{0}", testMatrixBool);
            }
            else
            {
                Console.WriteLine("There aren't any non-zero elements in\n{0}", testMatrixBool);
            }
        }
    }
}