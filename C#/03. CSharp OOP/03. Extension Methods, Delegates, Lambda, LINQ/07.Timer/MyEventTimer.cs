namespace _03.Extension_Methods_Delegates_Lambda_LINQ._07.Timer
{
    using System;
    using System.Threading;

    public class MyEventTimer
    {
        public event EventHandler TimeElapsed;
        private int interval;

        public MyEventTimer(int seconds)
        {
            this.Seconds = seconds;
        }

        public int Seconds
        {
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
        
        public Timer Timer { get; private set; }

        public void Start()
        {
            this.Timer = new Timer(new TimerCallback(PrintSomething), null, 0, this.Seconds);
            Console.ReadKey();
            
        }

        private void PrintSomething(object o)
        {
            Console.WriteLine("Print something");
            this.NotifyElapsedTime(new EventArgs());
        }

        private void NotifyElapsedTime(EventArgs e)
        {
            this.TimeElapsed?.Invoke(this, e);
        }
    }
}
