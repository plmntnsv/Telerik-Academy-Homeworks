using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Defining_Classes_Part_1
{
    public class GSM
    {
        //fields
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private static GSM iPhone4S = new GSM("4S", "Apple", 400, "Minzuhar", new Battery("1432 mAh", 200, 14, BatteryType.LiPo),new Display(3.5,16000000));
        private List<Call> callsList = new List<Call>();
        //constructors
        public GSM(string model, string manufacturer, decimal? price = null, string owner = null)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
        }
        //properties
        public StringBuilder CallHistory {
            get
            {
                StringBuilder callsBuilder = new StringBuilder();
                if (this.callsList.Count == 0)
                {
                    callsBuilder.Append("Call history is empty");
                }
                else
                {
                    for (int i = 0; i < callsList.Count; i++)
                    {
                        if (i == callsList.Count-1)
                        {
                            callsBuilder.Append(callsList[i].ToString());
                        }
                        else
                        {
                            callsBuilder.AppendLine(callsList[i].ToString());
                        }
                    }
                }
                return callsBuilder;
            }
        }
        public static string Iphone4s
        {
            get
            {
                return iPhone4S.ToString();
            }
            
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid model name!");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid manufacturer name!");
                }
                this.manufacturer = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price cannot be a negative number!");
                }
                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("Invalid owner's name! Owner's name cannot be less than two letters!");
                }
                this.owner = value;
            }
        }
        public override string ToString()
        {
            return $"Phone - model: {this.model}, manufacturer: {this.manufacturer}, price: {this.price} lv., owner: {this.owner}\nBattery - model: {this.battery.BatteryModel}, hours idle: {this.battery.HoursIdle}, hours talking: {this.battery.HoursTalk}, type: {this.battery.BatteryType}\nDisplay - size: {this.display.Size}, number of colors: {this.display.NumberOfColors}";
        }
        //methods
        public void AddCall(Call newCall)
        {
            this.callsList.Add(newCall);
        }
        public void DeleteCall(int positionOfCall)
        {
            this.callsList.RemoveAt(positionOfCall);
        }
        public void DeleteHistory()
        {
            this.callsList.Clear();
        }
        public string PriceOfCalls(decimal price)
        {
            decimal duration = 0;
            foreach (var call in this.callsList)
            {
                duration += call.DurationOfCall;
            }
            return String.Format("{0:F2}lv.",price * (duration / 60m));
        }
        public int FindLongestCall()
        {
            if (this.callsList.Count != 0)
            {
                int indexOfLongestCall = 0;
                for (int i = 1; i < this.callsList.Count; i++)
                {
                    if (callsList[i].DurationOfCall > callsList[i - 1].DurationOfCall)
                    {
                        indexOfLongestCall = i;
                    }
                }
                return indexOfLongestCall;
            }
            else
            {
                throw new ArgumentException("Calls list is empty!");
            }
            
        }
    }
}
