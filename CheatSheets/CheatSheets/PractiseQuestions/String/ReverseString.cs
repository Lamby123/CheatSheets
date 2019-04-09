using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatSheets.PractiseQuestions.String
{
    public static class ReverseString
    {
        public static string Reverse(this string input)
        {
            var arr = input.Split();
            Array.Reverse(arr);
            return string.Join("", arr);
        }
    }
}
