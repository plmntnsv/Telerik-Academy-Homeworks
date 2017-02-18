namespace _03.Extension_Methods_Delegates_Lambda_LINQ._06.Divisible_by_7_and_3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class TestDivisibleBy7and3
    {
        public static void Test()
        {
            int[] testArr = new[] { 1, 14, 7, 21, 3, 16, 42, 84, 22 };
            // Using lambda and extensions
            Console.WriteLine("Using lambda and extensions:");
            var lambdaResult = testArr.Where(x => x % 3 == 0 && x % 7 == 0).ToList();
            Console.WriteLine(string.Join(", ",lambdaResult));

            Console.WriteLine();
            Console.WriteLine("Using LINQ:");
            var linqResult = from number in testArr
                             where number % 3 == 0 && number % 7 == 0
                             select number;
            Console.WriteLine(string.Join(", ", linqResult));
        }
    }
}
