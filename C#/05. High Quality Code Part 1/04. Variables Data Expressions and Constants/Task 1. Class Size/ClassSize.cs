using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Class_Size
{
    public class Size
    {
        public double width, height;
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(
            Size size, double angleOfRotation)
        {
            var cosineOfRotation = Math.Abs(Math.Cos(angleOfRotation));
            var sinusOfRotation = Math.Abs(Math.Sin(angleOfRotation));

            var sizeWidth = size.width;
            var sizeHeight = size.height;

            var sizeAfterRotation = new Size(
                   cosineOfRotation * sizeWidth + sinusOfRotation * sizeHeight,
                   sinusOfRotation * sizeWidth + cosineOfRotation * sizeHeight);

            return sizeAfterRotation;
        }
    }
}
