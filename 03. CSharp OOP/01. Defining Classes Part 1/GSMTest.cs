using System;

namespace _01.Defining_Classes_Part_1
{
    class GSMTest
    {
        public static void TestGsm()
        {
            GSM[] gsmsArr =
        {
            new GSM("GalaxyS7","Samsung",1100,"Someone", new Battery("3000 mAh",44,22,BatteryType.LiIon),new Display(5.1,16000000)),
            new GSM("Desire 200","HTC",200,"Anyone",new Battery("1230 mAh",821,10,BatteryType.LiIon),new Display(3.5,16000000)),
            new GSM("P70","Lenovo",580,"Somebody",new Battery("4000 mAh",816,46,BatteryType.LiPo),new Display(5, 16000000)),
            new GSM("150","Nokia",60,"Whoever",new Battery("1020 mAh",744,22,BatteryType.LiIon),new Display(2.4, 65000))
        };
            foreach (GSM gsm in gsmsArr)
            {
                Console.WriteLine(gsm);
                Console.WriteLine(Startup.dashLine);
            }
            Console.WriteLine(GSM.Iphone4s);
        }
    }
}
