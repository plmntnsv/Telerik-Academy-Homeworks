using System;

namespace _01.Defining_Classes_Part_1
{
    class CallHistoryTest
    {
        public static void TestGSMCallHistory()
        {

            GSM gsm = new GSM("GalaxyS7", "Samsung", 1100, "Someone", new Battery("3000 mAh", 44, 22, BatteryType.LiIon), new Display(5.1, 16000000));
            //List<Call> listOfCalls = new List<Call>();
            //listOfCalls.Add(new Call((new DateTime(2016, 12, 18)), DateTime.Parse("20:35:12"), "0123456", 210));
            //listOfCalls.Add(new Call((new DateTime(2015, 05, 01)), DateTime.Parse("13:12:54"), "6543210", 1431));
            //listOfCalls.Add(new Call((new DateTime(2014, 01, 31)), DateTime.Parse("23:29:01"), "1234567", 353));

            Call firstCall = new Call((new DateTime(2016, 12, 18)), DateTime.Parse("20:35:12"), "0123456", 210);
            Call secondCall = new Call((new DateTime(2015, 05, 01)), DateTime.Parse("13:12:54"), "6543210", 1431);
            Call thirdCall = new Call((new DateTime(2014, 01, 31)), DateTime.Parse("23:29:01"), "1234567", 353);
            gsm.AddCall(firstCall);
            gsm.AddCall(secondCall);
            gsm.AddCall(thirdCall);
            //initial call history
            Console.WriteLine("Call history:");
            Console.WriteLine(gsm.CallHistory);
            Console.WriteLine();
            Console.WriteLine("Total price of the calls:");
            Console.WriteLine(gsm.PriceOfCalls(0.37m));
            gsm.DeleteCall(gsm.FindLongestCall());
            //after deleting the longest call
            Console.WriteLine(Startup.dashLine);
            Console.WriteLine("Call history without longest call:");
            Console.WriteLine(gsm.CallHistory);
            Console.WriteLine();
            Console.WriteLine("Total price of the calls:");
            Console.WriteLine(gsm.PriceOfCalls(0.37m));
            //after clearing the history
            Console.WriteLine(Startup.dashLine);
            gsm.DeleteHistory();
            Console.WriteLine("Call history without any calls:");
            Console.WriteLine(gsm.CallHistory);
            Console.WriteLine();
            Console.WriteLine("Total price of the calls:");
            Console.WriteLine(gsm.PriceOfCalls(0.37m));
        }
    }
}
