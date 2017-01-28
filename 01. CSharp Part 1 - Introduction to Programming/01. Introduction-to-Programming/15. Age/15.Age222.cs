using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age
{
    class Age
    {
        static void Main()
        {
            DateTime today = DateTime.Now;
            DateTime birthDay = DateTime.ParseExact(Console.ReadLine(), "MM.dd.yyyy", null);

           // DateTime birthDay = DateTime.Parse(Console.ReadLine());
           if (today.Month > birthDay.Month)
            {
                Console.WriteLine(today.Year - birthDay.Year);
                Console.WriteLine(today.Year - birthDay.Year + 10);
            }

            if (today.Month < birthDay.Month)
            {
                Console.WriteLine(today.Year - birthDay.Year - 1);
                Console.WriteLine(today.Year - birthDay.Year - 1 + 10);
            }
            else
            {
                if (today.Month == birthDay.Month)
                if (today.Day < birthDay.Day)
                    {
                        Console.WriteLine(today.Year - birthDay.Year - 1);
                        Console.WriteLine(today.Year - birthDay.Year - 1 + 10);
                    }
                else
                    {
                        Console.WriteLine(today.Year - birthDay.Year);
                        Console.WriteLine(today.Year - birthDay.Year + 10);
                    }
            }
        }
    }

}