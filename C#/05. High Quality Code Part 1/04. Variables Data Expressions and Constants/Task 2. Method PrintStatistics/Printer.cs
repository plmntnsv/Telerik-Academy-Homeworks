using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Method_PrintStatistics
{
    class Printer
    {
        public void PrintStatistics(double[] dataArray, int count)
        {
            double max = 0;
            for (int i = 0; i < count; i++)
            {
                if (dataArray[i] > max)
                {
                    max = dataArray[i];
                }
            }

            PrintMax(max);

            double min = 0;
            for (int i = 0; i < count; i++)
            {
                if (dataArray[i] < min)
                {
                    min = dataArray[i];
                }
            }

            PrintMin(max);

            double average = 0;
            for (int i = 0; i < count; i++)
            {
                average += dataArray[i];
            }

            PrintAvg(average / count);
        }
    }
}
