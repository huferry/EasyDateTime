using System;

namespace EasyDateTime
{
    public static class DateTimeExtensions
    {
        /// <summary>
        ///     Is the date/time already in the past?
        /// </summary>
        /// <param name="dateTime">The date/time.</param>
        /// <returns>
        ///     True if the date/time is in the past.
        /// </returns>
        public static bool IsPassed(this DateTime? dateTime)
        {
            return dateTime?.IsPassed() ?? false;
        }

        /// <summary>
        ///     Is the date/time already in the past?
        /// </summary>
        /// <param name="dateTime">The date/time.</param>
        /// <returns>
        ///     True if the date/time is in the past.
        /// </returns>
        public static bool IsPassed(this DateTime dateTime)
        {
            return dateTime < DateTime.Now;
        }

        /// <summary>
        ///     The day before, the same time.
        /// </summary>
        /// <param name="dateTime">The date/time.</param>
        /// <returns>The same date/time but the day before.</returns>
        public static DateTime YesterdaySameTime(this DateTime dateTime)
        {
            return dateTime.AddDays(-1);
        }

        /// <summary>
        ///     The day before, the same time.
        /// </summary>
        /// <param name="dateTime">The date/time.</param>
        /// <returns>The same date/time but the day after.</returns>
        public static DateTime TomorrowSameTime(this DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        /// <summary>
        ///     Get the century of the given date/time.
        /// </summary>
        /// <param name="dateTime">The date/time.</param>
        /// <returns>The century of the date/time.</returns>
        public static int Century(this DateTime dateTime)
        {
            return dateTime.Year / 100 + 1;
        }

        /// <summary>
        ///     Does the given date stand before the comparison date.
        /// </summary>
        /// <param name="dateTime">The date/time subject.</param>
        /// <param name="comparison">The date/time to be compared.</param>
        /// <returns>True if dateTime is before comparison.</returns>
        public static bool IsBefore(this DateTime dateTime, DateTime comparison)
        {
            return dateTime < comparison;
        }

        /// <summary>
        ///     Does a date/time stand between the begin and end date.
        ///     A period can be either closed (having begin and end date/time),
        ///     open-ended (without end) or open-beginning (without begin).
        ///     In case of open-ended, then IsBetween is true when value is greater than or equal to the begin date/time.
        ///     In case of open-beginning, then IsBetween is true when value is less than or equal to the end date/time.
        /// </summary>
        /// <param name="value">The subject date/time.</param>
        /// <param name="begin">The begin date/time of the period.</param>
        /// <param name="end">The end date/time of the period.</param>
        /// <returns>True if the subject date/time is within the given period.</returns>
        public static bool IsBetween(this DateTime value, DateTime? begin, DateTime? end)
        {
            return (!begin.HasValue || value >= begin) &&
                   (!end.HasValue || value <= end.Value);
        }

        /// <summary>
        /// Is the date Monday?
        /// </summary>
        /// <param name="dateTime">The date in subject.</param>
        /// <returns>True if the date is Monday.</returns>
        public static bool IsMonday(this DateTime dateTime) => 
            dateTime.DayOfWeek == DayOfWeek.Monday;

        /// <summary>
        /// Is the date Tuesday?
        /// </summary>
        /// <param name="dateTime">The date in subject.</param>
        /// <returns>True if the date is Tuesday.</returns>
        public static bool IsTuesday(this DateTime dateTime) =>
            dateTime.DayOfWeek == DayOfWeek.Tuesday;

        /// <summary>
        /// Is the date Wednesday?
        /// </summary>
        /// <param name="dateTime">The date in subject.</param>
        /// <returns>True if the date is Wednesday.</returns>
        public static bool IsWednesday(this DateTime dateTime) =>
            dateTime.DayOfWeek == DayOfWeek.Wednesday;

        /// <summary>
        /// Is the date Thursday?
        /// </summary>
        /// <param name="dateTime">The date in subject.</param>
        /// <returns>True if the date is Thursday.</returns>
        public static bool IsThursday(this DateTime dateTime) =>
            dateTime.DayOfWeek == DayOfWeek.Thursday;

        /// <summary>
        /// Is the date Friday?
        /// </summary>
        /// <param name="dateTime">The date in subject.</param>
        /// <returns>True if the date is Friday.</returns>
        public static bool IsFriday(this DateTime dateTime) =>
            dateTime.DayOfWeek == DayOfWeek.Friday;

        /// <summary>
        /// Is the date Saturday?
        /// </summary>
        /// <param name="dateTime">The date in subject.</param>
        /// <returns>True if the date is Saturday.</returns>
        public static bool IsSaturday(this DateTime dateTime) =>
            dateTime.DayOfWeek == DayOfWeek.Saturday;

        /// <summary>
        ///     Is the date Sunday?
        /// </summary>
        /// <param name="dateTime">The date in subject.</param>
        /// <returns>True if the date is Sunday.</returns>
        public static bool IsSunday(this DateTime dateTime) =>
            dateTime.DayOfWeek == DayOfWeek.Sunday;
    }
}