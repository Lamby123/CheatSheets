namespace CheatSheet.Extensions
{
    using System;
    using System.Globalization;

    public static class DateTimeExtensions
    {
        /// <summary>Check if a date is within a date range. </summary>
        public static bool DateTimeInRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate) 
            => dateToCheck >= startDate && dateToCheck <= endDate;

        /// <summary>Check if a date is within a date range. </summary>
        public static bool DateInRange(this DateTime dateToCheck, DateTime startDate, DateTime endDate)
            => dateToCheck.Date >= startDate.Date && dateToCheck.Date <= endDate.Date;

        /// <summary>Convert a string to datetime</summary>
        public static DateTime DateFromString(string input, string format)
            => DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);

        public static bool TryDateTimeParse(string input, string format)
        {
            DateTime value;
            return DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out value);
        }
    }
}
