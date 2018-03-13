using System;

namespace EasyDateTimeUnitTests
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        ///     Create a date/time in the past with the given duration.
        /// </summary>
        public static DateTime Ago(this TimeSpan duration)
        {
            return DateTime.Now.Subtract(duration);
        }

        /// <summary>
        ///     Create a date/time in the future with the given duration.
        /// </summary>
        public static DateTime FromNow(this TimeSpan duration)
        {
            return DateTime.Now.Add(duration);
        }
    }
}