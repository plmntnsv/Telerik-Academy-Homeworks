using System;

namespace _01.Defining_Classes_Part_1
{
    public class Battery
    {
        private string batteryModel;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType batteryType;

        public Battery(string batteryModel, BatteryType batteryType, double? hoursIdle = null, double? hoursTalk = null)
        {
            this.BatteryModel = batteryModel;
            this.BatteryType = batteryType;
        }
        public Battery(string batteryModel, double hoursIdle, double hoursTalk, BatteryType batteryType)
        {
            this.BatteryModel = batteryModel;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public string BatteryModel
        {
            get
            {
                return batteryModel;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid battery model!");
                }
                this.batteryModel = value;
            }
        }

        public double HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Idle hours cannot be less than zero!");
                }
                this.hoursIdle = value;
            }
        }

        public double HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Talking hours cannot be less than zero!");
                }
                this.hoursTalk = value;
            }
        }
        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }
    }
}
