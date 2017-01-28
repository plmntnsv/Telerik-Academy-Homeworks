using System;

namespace _01.Say_hello
{
    class Program
    {
        static void Main()
        {
            //string name = Console.ReadLine();
            //Hello(name);
            Console.WriteLine(Hello2());
        }
        static void Hello(string name)
        {
            Console.WriteLine("Hello, {0}!", name);

        }
        static string Hello2()
        {
            string name = Console.ReadLine();
            string result = "Hello, " + name + "!";
            return result;
        }
    }
}
/*Say Hello
Description

Write a method that asks the user for his name and prints Hello, <name>!. Write a program to test this method.

Input

On the first line you will receive a name
Output

Print Hello, <name>!
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
Peter	Hello, Peter!
*/
