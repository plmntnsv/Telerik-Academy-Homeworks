using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3.Refactor_loop
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFound = false;
            int i;
            for (i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    if (array[i] == expectedValue)
                    {
                        isFound = true;
                    }
                }

                Console.WriteLine(array[i]);
            }

            // More code here
            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
