using System;

namespace _01.Defining_Classes_Part_1
{
    public class Display
    {
        private double size;
        private int numberOfColors;

        public Display(double size, int? numberOfColors = null)
        {
            this.Size = size;
        }
        public Display(double size, int numberOfColors)
        {
           this.Size = size;
            this.NumberOfColors = numberOfColors;
        }
        public double Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 2|| value > 7)
                {

                    throw new ArgumentOutOfRangeException("Display size must be between 2 and 7 inches!");

                }
                this.size = value;
            }
        }
        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
            set
            {
                if (value < 2 || value > 16000000)
                {

                    throw new ArgumentOutOfRangeException("The number of colors must be between 2 and 16000000!");

                }
                this.numberOfColors = value;
            }
        }
    }
}
