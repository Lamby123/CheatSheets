namespace CheatSheets.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal? ConvertStringToDecimal(string value)
        {
            decimal returnObj;
            if (decimal.TryParse(value, out returnObj))
            {
                return returnObj;
            }
            return null;
        }
    }
}
