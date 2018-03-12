using System;

namespace EasyDateTime
{
    public static class DateTimeExtensions
    {
        public static bool IsPassed(this DateTime? dateTime) =>
            dateTime?.IsPassed() ?? false;
        
        public static bool IsPassed(this DateTime dateTime) => 
            dateTime < DateTime.Now;

        public static DateTime YesterdaySameTime(this DateTime dateTime) =>
            dateTime.AddDays(-1);

        public static DateTime TomorrowSameTime(this DateTime dateTime) =>
            dateTime.AddDays(1);

        public static int Century(this DateTime dateTime) =>
            dateTime.Year / 100 + 1;
    }
}