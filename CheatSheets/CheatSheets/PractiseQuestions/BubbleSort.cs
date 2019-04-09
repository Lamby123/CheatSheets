using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatSheets.PractiseQuestions
{
    public static class BubbleSort
    {


        // Bubble sort is a simple sorting algorithm. 
        // This sorting algorithm is a comparison-based algorithm in which each pair of adjacent elements is compared and the elements are swapped if they are not in order.
        public static void Bubble(this int[] arrayToSort){

            int placeholder;
            for (int j = 0; j <= arrayToSort.Length - 2; j++)
            {
                for (int i = 0; i <= arrayToSort.Length - 2; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i + 1])
                    {
                        placeholder = arrayToSort[i + 1];
                        arrayToSort[i + 1] = arrayToSort[i];
                        arrayToSort[i] = placeholder;
                    }
                }
            }
        }
    }
}
