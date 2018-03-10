using System;

namespace EasyDateTime
{
    public static class IntegerDateTimeExtensions
    {
        public static TimeSpan Milliseconds(this int value)
        {
            return TimeSpan.FromMilliseconds(value);
        }

        public static TimeSpan Seconds(this int value)
        {
            return TimeSpan.FromSeconds(value);
        }

        public static TimeSpan Minutes(this int value)
        {
            return TimeSpan.FromMinutes(value);
        }

        public static TimeSpan Hours(this int value)
        {
            return TimeSpan.FromHours(value);
        }

        public static TimeSpan Days(this int value)
        {
            return TimeSpan.FromDays(value);
        }

        public static IndefiniteDateTime Years(this int value)
        {
            return new IndefiniteDateTime(DurationType.Year, value);
        }

        public static IndefiniteDateTime Months(this int value)
        {
            return new IndefiniteDateTime(DurationType.Month, value);
        }

        public static DateTime OClock(this int value)
        {
            if (value < 0 || value > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            } 
            return DateTime.Today.AddHours(value);
        }
    }
}