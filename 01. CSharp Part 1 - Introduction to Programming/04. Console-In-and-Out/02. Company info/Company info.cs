using System;

namespace _04._02.Company_info
{
    class Program
    {
        static void Main(string[] args)
        {
            string companyName = Console.ReadLine(),
                companyAddress = Console.ReadLine(),
                phoneNumber = Console.ReadLine(),
                faxNumber = Console.ReadLine(),
                webSite = Console.ReadLine(),
                managerFirstName = Console.ReadLine(),
                managerLastName = Console.ReadLine(),
                managerAge = Console.ReadLine(),
                managerPhone = Console.ReadLine();
            if (faxNumber == string.Empty)
            {
                faxNumber = "(no fax)";
            }

            Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})", 
                                companyName,companyAddress,phoneNumber,faxNumber,webSite,managerFirstName, managerLastName,managerAge,managerPhone);


        }
    }
}
/*Description

A company has name, address, phone number, fax number, web site and manager. The manager has first name, last name, age and a phone number.
Write a program that reads the information about a company and its manager and prints it back on the console.
info	input
Company name:	Telerik Academy
Company address:	31 Al. Malinov, Sofia
Phone number:	+359 888 55 55 555
Fax number:	
Web site:	http://telerikacademy.com/
Manager first name:	Nikolay
Manager last name:	Kostov
Manager age:	25
Manager phone:	+359 2 981 981
Input

You will each piece of information about the company on a separate line, in the same order as in the example
Company name
Company address
Phone number
Fax number
Web site
Manager first name
Manager last name
Manager age
Manager phone
Output

Print the information the same way as shown in the sample test. Make sure that you print "(no fax)" if an empty line is passed as fax number.
Constraints

The input will always be in the described format
Only the fax number field can be empty, all other fields will be least one symbol
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	
Telerik Academy
231 Al. Malinov, Sofia
+359 888 55 55 555

http://telerikacademy.com/
Nikolay
Kostov
25
+359 2 981 981	

Output   
Telerik Academy
Address: 231 Al. Malinov, Sofia
Tel. +359 888 55 55 555
Fax: (no fax)
Web site: http://telerikacademy.com/
Manager: Nikolay Kostov (age: 25, tel. +359 2 981 981)
*/
