using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07._18.Remove_elements_from_array
{
    class Program
    {
        static void Main(string[] args)
        {
            //input & variables
            int n = int.Parse(Console.ReadLine()),
                indexToSwap = 0,
                biggestToSwap = 0;
            bool smallest = true,
                 biggest = true;
            
            //int[] arr = { 1, 4, 3, 3, 6, 3, 2, 3 }; //otg:3 n:8
            //int[] arr = { 14, 2, 9, 8, 3, 13, 17, 19, 30, 1 }; //otg:4 n:10
            //int[] arr = { 0, 0, 1, 0, 0, 0, 0, 2, 0, 0 }; //otg:2 n:10
            //int[] arr = { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 }; //otg:10 n:16
            
            List<int> list = new List<int>();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            //pochvame da proverqvame
            for (int i = 0; i < n; i++)
            {
                if (i == 0) //ako e 1vi element napravo go dobavqme v lista
                {
                    list.Add(arr[i]);
                    continue;
                }
                smallest = true;
                biggest = true;
                for (int j = 0; j < list.Count; j++) //2ra stupka - proverqvame dali e nai-golemiq
                {                                    //ili nai-malkiq, ili puk e raven na nqkoe ot dr chisla
                    if (arr[i] >= list[j])
                    {
                        smallest = false;
                    }
                    if (arr[i] <= list[j])
                    {
                        biggest = false;
                    }
                    if (!smallest && !biggest)                      //samiqt algoritym pazi i poredicata ot chisla, kato ima 3 proverki
                    {                                               //1:ako chisloto e nai-malko ot poslednoto chislo na vsichki poredici, go vkarvame v nachaloto
                        break;                                      //2:ako e nai-golqmot ot poslednoto chislo na vs poredici, go vkarvame v kraq
                    }                                               //3:ako e po-sredata, tursime nai-golqmoto, koeto e po malko ot arr[i] (chisloto, na koeto tyrsime mqsto)
                                                                    //kato na vsqko chislo, koeto vkarvame, mahame ostanalite poredici, koito sa sus sushtata duljina.
                }                                                   //Az, pazeneto na celite poredici sum izbegnal, kato pazq samo poslednoto chislo (samo to ni trqbva za proverkite)  
                if (smallest && !biggest)                           //A za duljinata izpolzvam index-a na, koito se namira mqstoto na chisloto v lista, naprimer: 1vo chislo ot masiva napr. 0, otiva
                {                                                   //na index 0 v lista(tova e s duljina index+1= poredica ot 1 element (0)), 2roto chislo ako e po golqmo napr. 2, otiva na index 1, index1+1=
                    list.RemoveAt(0);                               //poredica ot 2 chisla(0,2), 3toto ako e mejdu dvete predishni napr. 1, otiva na index 1 s list.insert (stava - 0,1), kato taka izbutva predishniq index 1
                    list.Insert(0, arr[i]);                         //(0,2) na index 2 i poneje sa ednakvi duljini (ot po 2 elementa) mahame tozi koito sme izmestili. I tova se povtarq sus vsichki chisla ot originalniq masiv
                }                                                   //Nakraq spored zavisi, koi e posledniq index v lista, da kajem 5, tova oznachava che imame poredica ot 6 poredni uvelichavashti se ili ravni
                else if (biggest && !smallest)                      //chisla, izvajdame ot duljinata na masiva(vsichki chisla) duljinata na lista i poluchavame, kolko chisla nai-malko na broi ne ni trqvat.
                {
                    list.Add(arr[i]);
                }
                else if (!biggest && !smallest)
                {
                    biggestToSwap = int.MinValue;
                    for (int g = 0; g < list.Count; g++)
                    {
                        if (arr[i] >= list[g] && biggestToSwap == int.MinValue) //vajno e da ima > i = (< i =) ako imame chisla, koito sa ednakvi napr.: 
                        {                                                       // 1,3,3,2,3,4,3; ili 1,1,1,0,1,1,0,0,1,1;
                            indexToSwap = g;    
                            biggestToSwap = list[g];                            
                        }
                        else if (arr[i] >= list[g] && biggestToSwap <= list[g])
                        {
                            biggestToSwap = list[g];
                            indexToSwap = g;
                        }
                    }
                    list.Insert(indexToSwap+1, arr[i]);
                    if (indexToSwap + 2 > list.Count-1) //ako chisloto koeto iskame da vkarame e ravno na poslednoto v lista (t.e. biggest i smallest == false)
                    {                                   //dobavqme go, no poneje nqma chislo koeto da sme izmestili, za da nqma exception, davame continue
                        continue;
                    }
                    else
                    {
                        list.RemoveAt(indexToSwap + 2); //ako puk ne e nai-golqmoto, vkarvame go, i mahame chisloto koeto sme izmestili napred (poneje sa poredici 
                    }                                   //s ednakva duljina (vij algorityma)
                }
                else
                {
                    list.Add(arr[i]); // tova e ako imame poredica ot ednakvi chisla, 0 0 0 0 ili 1 1 1 1 1 1 i dr.,samo gi dobavq
                }

            }
            Console.WriteLine(n-list.Count);

        }
    }
}
/*Description
http://www.geeksforgeeks.org/longest-monotonically-increasing-subsequence-size-n-log-n/ !!!
Write a program that reads an array of integers and removes from it a minimal number of elements 
in such a way that the remaining array is sorted in increasing order. 
Print the minimal number of elements that need to be removed in order for the array to become sorted.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the minimal number of elements that need to be removed
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Input	Output
8       3
1
4
3
3
6
3
2
3	

10      4
14
2
9
8
3
13
17
19
30
1	
*/
