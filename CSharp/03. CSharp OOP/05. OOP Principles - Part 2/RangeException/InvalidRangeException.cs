namespace _05.OOP_Principles___Part_2.RangeException
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        private readonly T start;
        private readonly T end;
        private readonly string message;

        public InvalidRangeException(T start, T end, string message)
        {
            this.start = start;
            this.end = end;
            this.message = message;
        }

        public override string Message
        {
            get
            {
                return string.Format(this.message, this.start, this.end);
            }
        }
    }
}
