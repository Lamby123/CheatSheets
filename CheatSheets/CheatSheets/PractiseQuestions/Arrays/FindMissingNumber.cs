using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatSheets.PractiseQuestions.Arrays
{
    public class FindMissingNumber
    {
        public static int Search(int[] array)
        {
            // array must be sorted. 
            Array.Sort(array);

            int index = 0;
            int size = array.Length - 1;

            int count = 0;

            while ((size - index) > 1)
            {
                count = (index + size) / 2;
                if ((array[index] - index) != (array[count] - count))
                    size = count;
                else if ((array[size] - size) != (array[count] - count))
                    index = count;
            }
            return (array[count] + 1);
        }
    }
}
