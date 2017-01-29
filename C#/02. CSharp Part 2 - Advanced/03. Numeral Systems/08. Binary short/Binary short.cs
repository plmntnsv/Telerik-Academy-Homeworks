using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._08.Binary_short
{
    class Program
    {
        static void Main(string[] args)
        {
            short number = short.Parse(Console.ReadLine());
            if (number < 0)
            {
                ConvertShortToBinary(number, '-');
            }
            else
            {
                ConvertShortToBinary(number);
            }

        }
        static void ConvertShortToBinary(short number, char sign = '+')
        {
            int[] result = new int[16];
            int index = 15;
            while (number != 0)
            {
                if(number % 2 == 0)
                {
                    result[index] = 0;
                    index--;

                }
                else
                {
                    result[index] = 1;
                    index--;
                }
                number /= 2;
            }                                                    //Ako chisloto e otricatelno
            if (sign == '-')                                     //1vo obrushtame vsichki bitove > 0 = 1 i 1 = 0;
            {                                                    
                for (int i = 0; i < result.Length; i++)          
                {                                                
                    if (result[i] == 1)                          
                    {                                            
                        result[i] = 0;                           
                    }                                            
                    else                                         
                    {                                            
                        result[i] = 1;                           
                    }                                            
                }
                for (int i = result.Length-1; i >= 0; i--)       //Sled tova oburnatoto chislo, nai-desniq bit go subirame s 1;
                {                                                //Ako nai-desniq bit na oburnatoto chislo e 0, go pravim 1 i prikluchvame, 
                    if (result[i] == 0)                          //no ako e 1, to pravim tozi bit na 0 i minavame na sledvashtiq (nalqvo bit), 
                    {                                            //kato povtarqme dokato ne popadnem na 0;
                        result[i] = 1;                           //11 - 1011, obrushtame - 0100, subirame s 1 = 0101;
                        break;                                   //12 - 1100, obrushtame - 0011, subirame s 1 = 0010=>0000=>0100;
                    }                                            //13 - 1101, 0010, 0011;
                    else                                         //14 - 1110, 0001, 0000=>0010;
                    {                                            //t.n.
                        result[i] = 0;                           //** da se ima vpredvid, che se obrushtat i vsichki 0, koito sa do kraq, i te stavat 1-ci;
                    }                                            //naprimer, kakto sme oburnali 11 - 0101 => ...1111 1111 1111 0101;
                }
            }
            Console.WriteLine(string.Join("", result));
        }
    }
}
/*Description

Write a program that shows the binary representation of given 16-bit signed integer number N (the C# type short).

Input

On the only line you will receive a decimal number - N
Output

Print the its binary representation on a single line
There should be exactly 16 digits of output
Constraints

-215 <= N < 215
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
11	    0000000000001011
-11	    1111111111110101
*/
