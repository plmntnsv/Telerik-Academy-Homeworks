using System;

namespace Class_123
{
    public class OutterClass
    {
        private const int MAX_COUNT = 6;

        public static void Main()
        {
            InnerClass instanceOfInnerClass = new InnerClass();
            instanceOfInnerClass.LogBoolToTheConsole(true);
        }

        public class InnerClass
        {
            public void LogBoolToTheConsole(bool parameter)
            {
                string variableToString = parameter.ToString();
                Console.WriteLine(variableToString);
            }
        }
    }
}
