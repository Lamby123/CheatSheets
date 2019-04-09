# CheatSheets

Cheat sheets for my reference when writing new ASP.NET Core projects. 


Most of this is just static extension methods to save me the job of rewriting the same code in different projects: 
E.g.

 public static decimal RemoveTrailingZeros(this decimal input) => 
            decimal.Parse(input.ToString("0.#######", new System.Globalization.CultureInfo("en-US")), new System.Globalization.CultureInfo("en-US"));
