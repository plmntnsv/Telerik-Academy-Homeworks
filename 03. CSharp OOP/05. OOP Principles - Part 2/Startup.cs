namespace _05.OOP_Principles___Part_2
{
    using System;
    using BankAccounts;
    using RangeException;
    using Shapes;

    public class Startup
    {
        public static void Main()
        {
            ShapesTest.Test();
            Console.WriteLine();
            BankAccountTest.Test();
            Console.WriteLine();
            RangeExceptionTest.Test();
        }
    }
}