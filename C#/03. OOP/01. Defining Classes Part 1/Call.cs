using System;

namespace _01.Defining_Classes_Part_1
{
    public class Call
    {
        private DateTime date;
        private DateTime timeOfCall;
        private string dialledNumber;
        private int duration;

        public Call(DateTime date, DateTime timeOfCall, string dialledNumber, int duration)
        {
            this.date = date;
            this.timeOfCall = timeOfCall;
            this.dialledNumber = dialledNumber;
            this.duration = duration;
        }

        public int DurationOfCall
        {
            get
            {
                return this.duration;
            }
        }

        public override string ToString()
        {
            return $"Date: {this.date.ToString("dd.MM.yyyy")}; Time: {this.timeOfCall.ToString("HH:mm:ss")}; Dialled number: {this.dialledNumber}; Duration: {this.duration} seconds;";

        }
    }
}
