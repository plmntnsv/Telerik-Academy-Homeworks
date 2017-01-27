using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._16.Subset_with_sum_S
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 14,
                currSum = 0;
            int[] arr = { 2, 1, 2, 4, 3, 5, 2, 6 };
            int[] arr2 = new int[arr.Length];
            //arr.CopyTo(arr2, 0);
            
        }
    }
}
/*Description

We are given an array of integers and a number S. 
Write a program to find if there exists a subset of the 
elements of the array that has a sum S.

Sample tests

input array	                    S	result
2, 1*, 2*, 4, 3, 5*, 2, 6*	    14	yes
*/