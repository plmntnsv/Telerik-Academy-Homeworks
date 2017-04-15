namespace RotatingWalkInMatrix
{
    using System;
    using log4net;
    using log4net.Config;

    public class StartUp
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Matrix));

        public static void Main()
        {
            // BasicConfigurator.Configure();
            XmlConfigurator.Configure();
            try
            {
                Matrix invalidMatrix4Log = new Matrix(0);
                Console.WriteLine(invalidMatrix4Log);
            }
            catch (ArgumentException ae)
            {                
                Log.Error("error:" + ae);
            }

            Console.WriteLine("[any key to exit]");
            Console.ReadKey();

            // Matrix defaultMatrix = new Matrix();
            // defaultMatrix.Fill();
            // Console.WriteLine("Matrix of default size 3*3");
            // Console.WriteLine(defaultMatrix);
               
            // Console.WriteLine();
               
            // Matrix matrix = new Matrix(5);
            // matrix.Fill();
            // Console.WriteLine("Matrix of size 5*5");
            // Console.WriteLine(matrix);
        }
    }
}
