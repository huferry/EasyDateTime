using System;

namespace EasyDateTime
{
    public static class IntegerDateTimeExtensions
    {
        /// <summary>
        ///     Create milliseconds time span.
        /// </summary>
        public static TimeSpan Milliseconds(this int value) => TimeSpan.FromMilliseconds(value);

        /// <summary>
        ///     Create seconds time span.
        /// </summary>
        public static TimeSpan Seconds(this int value) => TimeSpan.FromSeconds(value);

        /// <summary>
        ///     Create minutes time span.
        /// </summary>
        public static TimeSpan Minutes(this int value) => TimeSpan.FromMinutes(value);

        /// <summary>
        ///     Create hours time span.
        /// </summary>
        public static TimeSpan Hours(this int value) => TimeSpan.FromHours(value);

        /// <summary>
        ///     Create days time span.
        /// </summary>
        public static TimeSpan Days(this int value) => TimeSpan.FromDays(value);

        /// <summary>
        ///     Create years time span.
        /// </summary>
        public static IIndefiniteTimeSpan Years(this int value) => new YearSpan(value);

        /// <summary>
        ///     Create months time span.
        /// </summary>
        public static IIndefiniteTimeSpan Months(this int value) => new MonthSpan(value);

        /// <summary>
        ///     Create date time, exactly the whole hour of today.
        /// </summary>
        public static DateTime OClock(this int value)
        {
            if (value < 0 || value > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return DateTime.Today.AddHours(value);
        }

        private static int GetCurrentYear() => DateTime.Today.Year;

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime January(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 1, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime February(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 2, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime March(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 3, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime April(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 4, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime May(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 5, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime June(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 6, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime July(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 7, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime August(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 8, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime September(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 9, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime October(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 10, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime November(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 11, date);

        /// <summary>
        ///     Create a date from the specific month and year.
        /// </summary>
        /// <param name="year">The year of the date. When undefined, the current year is used.</param>
        public static DateTime December(this int date, int? year = null) =>
            new DateTime(year ?? GetCurrentYear(), 12, date);
    }
}