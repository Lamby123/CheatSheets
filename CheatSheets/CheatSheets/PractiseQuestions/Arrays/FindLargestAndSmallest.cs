using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatSheets.PractiseQuestions.Arrays
{
    public static class FindLargestAndSmallest
    {
        public static int FindLargest(int[] array)
        {
            if (!array.Any()) return -1;

            int largest = array[0];
            for (int i = 1; i < array.Length; i++)
            { 
                if (array[i] > largest)
                    largest = array[i];
            }

            return largest;
        }


        public static int FindSmallest(int[] array)
        {
            if (!array.Any()) return -1;

            int smallest = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < smallest)
                    smallest = array[i];
            }
            return smallest;
        }
    }
}
