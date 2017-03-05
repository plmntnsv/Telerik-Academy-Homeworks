using System;

namespace Task_1.class_123
{
    public class OutterClass
    {
        const int MAX_COUNT = 6;
        class InnerClass
        {
            public void LogBoolToTheConsole(bool parameter)
            {
                string variableToString = parameter.ToString();
                Console.WriteLine(variableToString);
            }
        }
        public static void Main()
        {
            InnerClass instanceOfInnerClass = new InnerClass();
            instanceOfInnerClass.LogBoolToTheConsole(true);
        }
    }
}
