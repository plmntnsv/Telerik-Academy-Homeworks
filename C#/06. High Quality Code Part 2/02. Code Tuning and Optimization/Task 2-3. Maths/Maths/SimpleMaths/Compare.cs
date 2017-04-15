using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMaths
{
    public class Compare
    {
        private const int IntegerNumber = 1;
        private const long LongNumber = 1L;
        private const float FloatNumber = 1F;
        private const double DoubleNumber = 1.0D;
        private const decimal DecimalNumber = 1.0M;
        private const int Operations = 100000;

        public static void Main()
        {
            Console.WriteLine("Get the result of 100,000 operations of adding,\nsubstracting, multyplying and dividing by 1:\n");
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Adding int:", GetElapsedTime(IntegerNumber, '+')));
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Adding long:", GetElapsedTime(LongNumber, '+')));
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Adding float:", GetElapsedTime(FloatNumber, '+')));
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Adding double:", GetElapsedTime(DoubleNumber, '+')));
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Adding decimal:", GetElapsedTime(DecimalNumber, '+')));
                                                        
            Console.WriteLine();                        
                                                        
            Console.WriteLine(string.Format("{0,-18} {1} ms", "Substract int:", GetElapsedTime(IntegerNumber, '-')));
            Console.WriteLine(string.Format("{0,-18} {1} ms", "Substract long:", GetElapsedTime(LongNumber, '-')));
            Console.WriteLine(string.Format("{0,-18} {1} ms", "Substract float:", GetElapsedTime(FloatNumber, '-')));
            Console.WriteLine(string.Format("{0,-18} {1} ms", "Substract double:", GetElapsedTime(DoubleNumber, '-')));
            Console.WriteLine(string.Format("{0,-18} {1} ms", "Substract decimal:", GetElapsedTime(DecimalNumber, '-')));
                                                        
            Console.WriteLine();                        
                                                        
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Multiply int:", GetElapsedTime(IntegerNumber, '*')));
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Multiply long:", GetElapsedTime(LongNumber, '*')));
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Multiply float:", GetElapsedTime(FloatNumber, '*')));
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Multiply double:", GetElapsedTime(DoubleNumber, '*')));
            Console.WriteLine(string.Format("{0,-17} {1} ms", "Multiply decimal:", GetElapsedTime(DecimalNumber, '*')));
                                                         
            Console.WriteLine();                         
                                                         
            Console.WriteLine(string.Format("{0,-15} {1} ms", "Divide int:", GetElapsedTime(IntegerNumber, '/')));
            Console.WriteLine(string.Format("{0,-15} {1} ms", "Divide long:", GetElapsedTime(LongNumber, '/')));
            Console.WriteLine(string.Format("{0,-15} {1} ms", "Divide float:", GetElapsedTime(FloatNumber, '/')));
            Console.WriteLine(string.Format("{0,-15} {1} ms", "Divide double:", GetElapsedTime(DoubleNumber, '/')));
            Console.WriteLine(string.Format("{0,-15} {1} ms", "Divide decimal:", GetElapsedTime(DecimalNumber, '/')));
        }

        private static string GetElapsedTime<T>(T number, char operation) where T : struct
        {
            T result = default(T);
            Stopwatch sw = Stopwatch.StartNew();

            switch (operation)
            {
                case '+':
                    for (int times = 0; times < Operations; times++)
                    {
                        result = (dynamic)number + number;
                    }

                    break;
                case '-':
                    for (int times = 0; times < Operations; times++)
                    {
                        result = (dynamic)number - number;
                    }

                    break;
                case '*':
                    for (int times = 0; times < Operations; times++)
                    {
                        result = (dynamic)number * number;
                    }

                    break;
                case '/':
                    for (int times = 0; times < Operations; times++)
                    {
                        result = (dynamic)number / number;
                    }

                    break;
                default:
                    throw new InvalidOperationException("Invalid math operator!");
            }

            sw.Stop();
            string elapsedTime = sw.Elapsed.TotalSeconds.ToString();
            return elapsedTime;
        }
    }
}
