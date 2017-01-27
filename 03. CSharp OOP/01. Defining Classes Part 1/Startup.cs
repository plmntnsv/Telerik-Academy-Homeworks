using System;

namespace _01.Defining_Classes_Part_1
{
    class Startup
    {
        public static string dashLine = new String('-', 80);
        public static void Main()
        {
            Console.WriteLine("".PadRight(80, '+'));
            GSMTest.TestGsm();
            Console.WriteLine("".PadRight(80, '+'));
            CallHistoryTest.TestGSMCallHistory();
            Console.WriteLine("".PadRight(80, '+'));
        }
    }
}
