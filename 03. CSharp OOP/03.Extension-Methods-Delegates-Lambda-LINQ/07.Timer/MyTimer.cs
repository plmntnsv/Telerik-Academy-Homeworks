namespace _03.Extension_Methods_Delegates_Lambda_LINQ._07.Timer
{
    using System;
    using System.Threading;
    //using System.Timers;

    public class MyTimer
    {
        // Two timers, for the second just remove the uncomment, but should comment the other timer
        private int interval;
        //public delegate void MyDelegate(object sender, ElapsedEventArgs e);
        public delegate void MyOtherDelegate(object o);
        
        public MyTimer(int interval)
        {
            this.Interval = interval;
        }

        public int Interval {
            get
            {
                return this.interval;
            }
            private set
            {
                if (value < 0 || value == 0)
                {
                    throw new ArgumentException("The interval must not be a negative number or zero.");
                }
                this.interval = value * 1000;
            }
        }

        //public System.Timers.Timer Timer { get; private set; }
        public System.Threading.Timer Timer { get; private set; }

        //public void InvokeDelegate()
        //{
        //    MyDelegate myMethod = SayHi;
        //    this.Timer = new System.Timers.Timer(interval);
        //    this.Timer.Elapsed += new ElapsedEventHandler(myMethod);
        //    this.Timer.Start();
        //    Console.ReadKey();
        //}

        //public static void SayHi(object sender, ElapsedEventArgs e)
        //{
        //    Console.WriteLine("Hi at {0:HH:mm:ss}", e.SignalTime);
        //}

        public void Start()
        {
            MyOtherDelegate myOtherMethod = SayHi;
            this.Timer = new System.Threading.Timer(new TimerCallback(myOtherMethod), null, 0, this.Interval);
            Console.ReadKey();
        }

        private static void SayHi(object o)
        {
            Console.WriteLine("Hi at {0:HH:mm:ss}", DateTime.Now);
            GC.Collect();
        }
    }

}
