namespace _03.Extension_Methods_Delegates_Lambda_LINQ._07.Timer
{
    using System;
    using System.Threading;
    using System.Timers;

    class TestTimers
    {
        public delegate void MyDelegate(object sender, ElapsedEventArgs e);

        public static void Test()
        {
            // Implement delegate method with timer
            //MyTimer testTimer = new MyTimer(3);
            //testTimer.Start();
            //testTimer.InvokeDelegate();
            // Implement method with timer and catch it with publisher-subscriber event
            MyEventTimer testEventTimer = new MyEventTimer(3);
            testEventTimer.TimeElapsed += Notified;
            testEventTimer.Start();
        }

        public static void Notified(object sender, EventArgs e)
        {
            Console.WriteLine("Event caught");
        }
    }
}
