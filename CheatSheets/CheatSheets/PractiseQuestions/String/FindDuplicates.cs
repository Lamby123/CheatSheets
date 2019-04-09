using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatSheets.PractiseQuestions.String
{
    public static class FindDuplicates
    {
        public static void GetDuplicates(string input)
        {
            var arr = input.Split();
            var duplicates = 
                from a in arr
                group a by a into gr
                where gr.Count() > 1
                select new { gr.Key }
        }
    }
}
