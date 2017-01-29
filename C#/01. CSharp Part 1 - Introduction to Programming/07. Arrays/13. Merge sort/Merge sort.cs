using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._13.Merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //ima greshki (vij 1 testovi array)
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int power = 1,
                smallest = int.MaxValue,
                indexOfLeftSmallest = 0,
                indexOfRightSmallest = 0,
                leftEnd, rightEnd,
                endAll = 0;
            //int[] arr = { 36, 10, 1, 34, 28, 38, 31, 27, 30, 20, 21 };
            //int[] arr = { 3, 4, 1, 5, 7, 6, 2,}; //<= greshen otg
            int[] arr2 = new int[n];
            //podrejdane masiv 1 po 1 element
            for (int i = 0; i < n; i += 2)
            {
                smallest = arr[i];
                if (arr.Length % 2 != 0 && i == n - 1)
                {
                    continue;
                }
                else if (arr[i] > arr[i + 1])
                {
                    smallest = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = smallest;
                }
            }
            //podrejdane po 2 po 2, 4 po 4, 8 po 8 i t.n.
            while (endAll == 0)
            {
                for (int i = 0; i < n; i += (int)Math.Pow(2, power) * 2)
                {
                    indexOfLeftSmallest = i;
                    indexOfRightSmallest = i + (int)Math.Pow(2, power);
                    leftEnd = i + (int)Math.Pow(2, power);
                    rightEnd = i + (int)Math.Pow(2, power) * 2;
                    //ako veche sme podredili po golqmata chast ot masiva
                    //i ima ostatuci, da postavim nachalo i krai na po-golemiq podreden masiv i
                    //masiva s ostatuchni chisla i da gi podredim i tqh.
                    if ((int)Math.Pow(2, power) * 2 > n)
                    {
                        indexOfRightSmallest = leftEnd;
                        rightEnd = n;
                        indexOfLeftSmallest = 0;
                        leftEnd = indexOfRightSmallest;                        
                        for (int j = 0; j < n; j++)
                        {
                            if (indexOfRightSmallest < rightEnd && arr[indexOfLeftSmallest] > arr[indexOfRightSmallest] && arr[indexOfRightSmallest] != int.MaxValue)
                            {
                                arr2[j] = arr[indexOfRightSmallest];
                                arr[indexOfRightSmallest] = int.MaxValue;
                                indexOfRightSmallest++;

                            }
                            else
                            {
                                arr2[j] = arr[indexOfLeftSmallest];
                                arr[indexOfLeftSmallest] = int.MaxValue;
                                indexOfLeftSmallest++;
                            }
                        }
                        break;
                    }
                    //proverka ako sledvashtite hodove shte izleznem ot masiva
                    //da kopira ostanalite elementi bez da pravi nishto drugo
                    else if (rightEnd > n)
                    {
                        for (int g = indexOfLeftSmallest, u = 0; u < n - indexOfLeftSmallest; g++, u++)
                        {
                            arr2[g] = arr[g];
                            arr[g] = int.MaxValue;
                        }
                        break;
                    }
                    //sverqva i podrejda po 2 po 2, 4 po 4, 8 po 8 i t.n.,
                    //kato vzima ot originalniq masiv chislata i gi vkarva v arr2,
                    //dopulnitelno sled kato e vkaral chislo v arr2, v originalniq arr se smenq na int.Max
                    for (int k = 0, y = i; k < Math.Pow(2, power) * 2; k++, y++)
                    {
                        //proverka ako veche sme vzeli vsichki chisla ot lqvata ili dqsnata chast,
                        //napravo da kopira ostanalite chisla(koito veche sa podredeni)
                        //na tochnite im mesta v arr2
                        if (indexOfLeftSmallest >= leftEnd || indexOfRightSmallest >= rightEnd)
                        {
                            for (int h = 0, u = i; h < Math.Pow(2, power) * 2; h++, u++)
                            {
                                if (indexOfLeftSmallest >= leftEnd && arr[u] != int.MaxValue)
                                {
                                    arr2[u] = arr[u];
                                    arr[u] = int.MaxValue;
                                }
                                else if (indexOfRightSmallest >= rightEnd && arr[u] != int.MaxValue)
                                {
                                    arr2[u + (int)Math.Pow(2, power)] = arr[u];
                                    arr[u] = int.MaxValue;
                                }

                            }
                            break;
                        }
                        else if (arr[indexOfLeftSmallest] < arr[indexOfRightSmallest])
                        {
                            smallest = arr[indexOfLeftSmallest];
                            arr2[y] = smallest;
                            arr[indexOfLeftSmallest] = int.MaxValue;
                            indexOfLeftSmallest++;


                        }
                        else
                        {
                            smallest = arr[indexOfRightSmallest];
                            arr2[y] = smallest;
                            arr[indexOfRightSmallest] = int.MaxValue;
                            indexOfRightSmallest++;

                        }
                    }
                }
                //vkarvane chisla ot arr2 v originalniq arr
                endAll = 1;
                for (int z = 0; z < n; z++)
                {
                    arr[z] = arr2[z];
                    if (z != 0 && arr[z] <= arr[z - 1])
                    {
                        endAll = 0;
                    }
                }
                power++;
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
/*Description

Write a program that sorts an array of integers using the Merge sort algorithm.
https://en.wikipedia.org/wiki/Merge_sort

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the sorted array
Each number should be on a new line
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
6
3       1
4       2
1       3
5       4
2       5
6	    6

10      
36      1
10      10
1       20
34      27
28      28
38      30
31      31
27      34
30      36
20	    38
*/
