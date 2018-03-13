using System;

namespace EasyDateTime
{
    internal class MonthSpan : IIndefiniteTimeSpan
    {
        private readonly int value;

        internal MonthSpan(int value)
        {
            this.value = value;
        }

        /// <summary>
        ///     Create a date time in the past from time span.
        /// </summary>
        public DateTime Ago() => DateTime.Now.AddMonths(-value);

        /// <summary>
        ///     Create a date time in the future from time span.
        /// </summary>
        public DateTime FromNow() => DateTime.Now.AddMonths(value);

        /// <summary>
        ///     Create an approximate date time from this date time.
        /// </summary>
        public TimeSpan Approximately() => DateTime.Today.AddMonths(value) - DateTime.Today;
    }
}