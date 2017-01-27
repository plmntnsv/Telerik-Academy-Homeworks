using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._10.Find_sum_in_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
            int wantedSum = 11,
                currentSum = 0;
            string result = "";

            for (int i = 0; i < arr.Length; i++)
            {
                if (currentSum == wantedSum)
                {
                    break;
                }
                currentSum = arr[i];
                result += arr[i]+", ";
                for (int z = i+1; z < arr.Length; z++)
                {
                    if (currentSum+arr[z] > wantedSum)
                    {
                        result = "";
                        break;
                    }
                    else if (currentSum + arr[z] < wantedSum)
                    {
                        currentSum += arr[z];
                        result += arr[z]+", ";
                    }
                    else if (currentSum + arr[z] == wantedSum)
                    {
                        currentSum += arr[z];
                        result += arr[z];
                        break;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
/*Description

Write a program that finds in given array of integers a sequence of given sum S (if present).

Sample tests

array	                S	    result
4, 3, 1, 4, 2, 5, 8	    11	    4, 2, 5
*/
