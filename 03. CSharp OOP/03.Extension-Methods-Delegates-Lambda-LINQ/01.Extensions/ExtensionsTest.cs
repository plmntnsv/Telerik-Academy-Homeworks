namespace _03.Extension_Methods_Delegates_Lambda_LINQ._01.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ExtensionsTest
    {
        public static void Test()
        {
            // StringBuilder extensions
            Console.WriteLine("StringBuilder extensions tests:");
            StringBuilder extensionTest = new StringBuilder();
            extensionTest.Append("Some text for testing");
            Console.WriteLine("Original text - " + extensionTest);
            Console.WriteLine("Substring - " + extensionTest.Substring(0, 4));
            Console.WriteLine("Substring - " + extensionTest.Substring(14));
            // IEnum extensions
            Console.WriteLine("\nIEnumerable extensions tests:");
            List<double> extensionIEnumTest = new List<double>() { 5d, 2d, 1d };
            Console.WriteLine("Collection = " + string.Join(", ", extensionIEnumTest));
            Console.WriteLine("Sum = " + extensionIEnumTest.Sum());
            Console.WriteLine("Product = " + extensionIEnumTest.Product());
            Console.WriteLine("Min = " + extensionIEnumTest.Min());
            Console.WriteLine("Max = " + extensionIEnumTest.Max());
            Console.WriteLine("Average = " + extensionIEnumTest.Average());
        }
    }
}
