using System;

namespace EasyDateTimeUnitTests
{
    public static class TimeSpanExtensions
    {
        public static DateTime Ago(this TimeSpan duration)
        {
            return DateTime.Now.Subtract(duration);
        }

        public static DateTime FromNow(this TimeSpan duration)
        {
            return DateTime.Now.Add(duration);
        }
    }
}