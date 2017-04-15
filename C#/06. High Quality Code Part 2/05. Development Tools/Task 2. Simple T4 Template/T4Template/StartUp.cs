using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4Template
{
    public class StartUp
    {
        public static void Main()
        {
            Class0 someClass = new Class0(2);
            Console.WriteLine(someClass.Number);
            Console.WriteLine(someClass.SomeMethod());
        }
    }
}
