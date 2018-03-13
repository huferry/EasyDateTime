using System;

namespace EasyDateTime
{
    internal class YearSpan : IIndefiniteTimeSpan
    {
        private readonly int value;

        internal YearSpan(int value)
        {
            this.value = value;
        }

        /// <summary>
        ///     Create a date time in the past from time span.
        /// </summary>
        public DateTime Ago() => DateTime.Now.AddYears(-value);

        /// <summary>
        ///     Create a date time in the future from time span.
        /// </summary>
        public DateTime FromNow() =>  DateTime.Now.AddYears(value);

        /// <summary>
        ///     Create an approximate date time from this date time.
        /// </summary>
        public TimeSpan Approximately() => DateTime.Today.AddYears(value) - DateTime.Today;
    }
}