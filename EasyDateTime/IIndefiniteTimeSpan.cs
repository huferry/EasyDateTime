using System;

namespace EasyDateTime
{
    /// <summary>
    ///     Represents an indefinite time span.
    ///     It is indefinite, in the sense like a month can be either 28, 29, 30 or 31 days;
    ///     or a year can be 365 or 366 days.
    /// </summary>
    public interface IIndefiniteTimeSpan
    {
        /// <summary>
        ///     Date time in the past, with the span from current date/time.
        /// </summary>
        /// <returns>
        ///     Date time in the past.
        /// </returns>
        DateTime Ago();

        /// <summary>
        ///     Date/time in the future, with the span from current date/time.
        /// </summary>
        /// <returns>
        ///     Date/time in the future.
        /// </returns>
        DateTime FromNow();

        /// <summary>
        ///     Give an approximate time span.
        ///     It is an approximation, for a month or a year has an indefinite number of days.
        ///     The approximation will be based on current date/time, e.g. if current year is 2004,
        ///     then a 1 year span will return 366 days (since 2004 is a leap year).
        /// </summary>
        /// <returns>
        ///     An approximation of the time span.
        /// </returns>
        TimeSpan Approximately();
    }
}