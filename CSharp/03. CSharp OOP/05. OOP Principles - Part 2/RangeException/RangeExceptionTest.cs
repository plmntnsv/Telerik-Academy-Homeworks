namespace _05.OOP_Principles___Part_2.RangeException
{
    using System;
    using System.Globalization;

    public static class RangeExceptionTest
    {
        public static void Test()
        {
            int start = 0, end = 100;
            try
            {
                Console.WriteLine("Enter a number that must not be below 0 and higher than 100");
                int number = int.Parse(Console.ReadLine());
                if (number < start || number > end)
                {
                    throw new InvalidRangeException<int>(start, end, "Invalid number! Valid range is between {0} and {1}!");
                }

                Console.WriteLine("{0} is a valid number!", number);
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine(ire.Message);
                Console.WriteLine(ire.StackTrace);
            }

            DateTime startDate = new DateTime(1980, 1, 1), endDate = new DateTime(2013, 12, 31);

            try
            {
                Console.WriteLine("\nEnter a date in the format YYYY.MM.DD that is between 1980.01.01 and 2013.12.31");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), new[] { "yyyy.M.d", "yyyy.MM.dd", "yyyy.M.dd", "yyyy.MM.d" }, CultureInfo.InvariantCulture, DateTimeStyles.None);
                if (date < startDate || date > endDate)
                {
                    throw new InvalidRangeException<DateTime>(startDate, endDate, "Invalid date! Valid date range is between {0:yyyy.MM.dd} and {1:yyyy.MM.dd}!");
                }

                Console.WriteLine("{0:yyyy.MM.dd} is a valid date!\n\nGood job!\n", date);
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine(ire.Message);
                Console.WriteLine(ire.StackTrace);
            }
        }
    }
}
