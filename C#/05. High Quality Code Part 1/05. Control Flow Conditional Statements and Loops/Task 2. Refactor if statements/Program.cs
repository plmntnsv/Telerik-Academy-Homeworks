using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Refactor_if_statements
{
    public class Program
    {
        public static void Main()
        {
            Potato potato;
            //... 
            if (potato != null && potato.HasBeenPeeled && !potato.IsRotten)
            {
                Cook(potato);
            }

            bool inRange = MIN_X <= x && x =< MAX_X && MIN_Y <= y && y <= MAX_Y;
            if (inRange && shouldVisitCell)
            {
                VisitCell();
            }
        }


    }
}
