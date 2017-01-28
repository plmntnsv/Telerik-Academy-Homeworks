namespace _02.Defining_Classes___Part_2
{
    using System;

    public static class TestGenericList
    {
        public static void Test()
        {
            //Creating a generic list
            GenericList<int> test = new GenericList<int>(10);
            for (int i = 0; i < 10; i++)
            {
                test.Add(i);
            }
            Console.WriteLine("A generic list:");
            Console.WriteLine("Result: "+test);
            Console.WriteLine();
            // Testing methods
            Console.WriteLine("Remove index 2:");
            test.RemoveAt(2);
            Console.WriteLine("Result: " + test);
            Console.WriteLine();
            Console.WriteLine("Insert at index 2 - 100:");
            test.InsertAt(2, 100);
            Console.WriteLine("Result: " + test);
            Console.WriteLine();
            Console.WriteLine("Get the index of number 3: ");
            Console.WriteLine("3 is at index: " +test.GetIndexOf(3));
            Console.WriteLine();
            Console.WriteLine("Get the list's length:");
            Console.WriteLine(test.Length());
            Console.WriteLine();
            Console.WriteLine("Get the element at index 2: ");
            Console.WriteLine(test.ElementAt(2));
            Console.WriteLine();
            Console.WriteLine("Get the min element:");
            Console.WriteLine(test.Min());
            Console.WriteLine();
            Console.WriteLine("Get the max element:");
            Console.WriteLine(test.Max());
            Console.WriteLine();
            Console.WriteLine("Clear all the list:");
            test.ClearAll();
            Console.WriteLine("Result: " + test);
        }
    }
}
