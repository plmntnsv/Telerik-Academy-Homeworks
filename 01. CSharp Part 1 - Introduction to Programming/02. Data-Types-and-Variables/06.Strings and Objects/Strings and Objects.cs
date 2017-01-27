using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._06.Strings_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "Hello";
            string B = "World";
            object C = A + " " + B;
            string D = (string)C;
            Console.WriteLine(D);
        }
    }
}
/*Description

Declare two string variables and assign them with Hello and World. 
Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval between). 
Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
*/