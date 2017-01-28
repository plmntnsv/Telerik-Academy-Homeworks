using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._12.Parse_URL
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string inputRemoveProtocol = input.Substring(input.IndexOf(':') + 3);

            Console.WriteLine("[protocol] = {0}\n[server] = {1}\n[resource] = {2}",
                GetProtServReso(input, 0, input.IndexOf(':')), 
                GetProtServReso(inputRemoveProtocol, 0, inputRemoveProtocol.IndexOf('/')),
                GetProtServReso(inputRemoveProtocol, inputRemoveProtocol.IndexOf('/'), inputRemoveProtocol.Length));


        }
        static StringBuilder GetProtServReso (string strInput, int startIndex, int endIndex)
        {
            StringBuilder result = new StringBuilder();

            for (int i = startIndex; i < endIndex; i++)
            {
                result.Append(strInput[i]);
            }

            return result;
        }
       
    }
}
/*Description

Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.

Input

On the only line you will receive an address
Output

Print the protocol, server and resource as shown below
Constraints

Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	                                                Output
.http://telerikacademy.com/Courses/Courses/Details/212	[protocol] = http
                                                        [server] = telerikacademy.com
                                                        [resource] = /Courses/Courses/Details/212

https://github.com/gentoo/gentoo.git	                [protocol] = https
                                                        [server] = github.com
                                                        [resource] = /gentoo/gentoo.git
*/