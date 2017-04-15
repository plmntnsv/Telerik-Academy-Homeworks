using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMaths
{
    public class Compare
    {
        private const float FloatNumber = 100.00F;
        private const double DoubleNumber = 100.00D;
        private const decimal DecimalNumber = 100.00M;
        private static Stopwatch sw = new Stopwatch();

        public static void Main()
        {
            GetSquareRootTime();
            Console.WriteLine();
            GetLogarithmTime();
            Console.WriteLine();
            GetSinusTime();
        }

        private static void GetSquareRootTime()
        {
            float floatSqrt;
            double doubleSqrt;
            decimal decimalSqrt;

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                floatSqrt = (float)Math.Sqrt(FloatNumber);
            }

            sw.Stop();
            Console.WriteLine("Float Sqrt: " + sw.Elapsed);
            sw.Reset();

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                doubleSqrt = Math.Sqrt(DoubleNumber);
            }       
            
            sw.Stop();
            Console.WriteLine("Double Sqrt: " + sw.Elapsed);
            sw.Reset();

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                decimalSqrt = (decimal)Math.Sqrt((double)DecimalNumber);
            }   
            
            sw.Stop();
            Console.WriteLine("Decimal Sqrt: " + sw.Elapsed);
            sw.Reset();
        }

        private static void GetLogarithmTime()
        {
            float floatLog;
            double doubleLog;
            decimal decimalLog;

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                floatLog = (float)Math.Log(FloatNumber);
            }

            sw.Stop();
            Console.WriteLine("Float Log: " + sw.Elapsed);
            sw.Reset();

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                doubleLog = Math.Log(DoubleNumber);
            }

            sw.Stop();
            Console.WriteLine("Double Log: " + sw.Elapsed);
            sw.Reset();

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                decimalLog = (decimal)Math.Log((double)DecimalNumber);
            }

            sw.Stop();
            Console.WriteLine("Decimal Log: " + sw.Elapsed);
            sw.Reset();
        }

        private static void GetSinusTime()
        {
            float floatSin;
            double doubleSin;
            decimal decimalSin;

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                floatSin = (float)Math.Sin(FloatNumber);
            }

            sw.Stop();
            Console.WriteLine("Float Sin: " + sw.Elapsed);
            sw.Reset();

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                doubleSin = Math.Sin(DoubleNumber);
            }

            sw.Stop();
            Console.WriteLine("Double Sin: " + sw.Elapsed);
            sw.Reset();

            sw.Start();
            for (int times = 0; times < 10000; times++)
            {
                decimalSin = (decimal)Math.Sin((double)DecimalNumber);
            }

            sw.Stop();
            Console.WriteLine("Decimal Sin: " + sw.Elapsed);
            sw.Reset();
        }
    }
}
