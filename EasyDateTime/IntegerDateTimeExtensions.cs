using System;

namespace EasyDateTime
{
    public static class IntegerDateTimeExtensions
    {
        public static TimeSpan Milliseconds(this int value) => TimeSpan.FromMilliseconds(value);

        public static TimeSpan Seconds(this int value) => TimeSpan.FromSeconds(value);

        public static TimeSpan Minutes(this int value) => TimeSpan.FromMinutes(value);

        public static TimeSpan Hours(this int value) => TimeSpan.FromHours(value);

        public static TimeSpan Days(this int value) => TimeSpan.FromDays(value);

        public static IIndefiniteTimeSpan Years(this int value) => new YearSpan(value);

        public static IIndefiniteTimeSpan Months(this int value) => new MonthSpan(value);

        public static DateTime OClock(this int value)
        {
            if (value < 0 || value > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return DateTime.Today.AddHours(value);
        }

        public static DateTime January(this int date, int year) => new DateTime(year, 1, date);
        public static DateTime February(this int date, int year) => new DateTime(year, 2, date);
        public static DateTime March(this int date, int year) => new DateTime(year, 3, date);
        public static DateTime April(this int date, int year) => new DateTime(year, 4, date);
        public static DateTime May(this int date, int year) => new DateTime(year, 5, date);
        public static DateTime June(this int date, int year) => new DateTime(year, 6, date);
        public static DateTime July(this int date, int year) => new DateTime(year, 7, date);
        public static DateTime August(this int date, int year) => new DateTime(year, 8, date);
        public static DateTime September(this int date, int year) => new DateTime(year, 9, date);
        public static DateTime October(this int date, int year) => new DateTime(year, 10, date);
        public static DateTime November(this int date, int year) => new DateTime(year, 11, date);
        public static DateTime December(this int date, int year) => new DateTime(year, 12, date);
    }
}