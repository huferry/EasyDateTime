using System;
using System.Collections.Generic;

namespace EasyDateTime
{
    /// <summary>
    ///     A period of time which can be a closed period (containing begin and end date/time) or
    ///     an open period (either with only begin or end date/time).
    /// </summary>
    public class Period
    {
        private readonly DateTime? end;
        private readonly DateTime? start;

        private Period(DateTime? start, DateTime? end)
        {
            this.start = start;
            this.end = end;
        }

        /// <summary>
        ///     Does The current date/time stand in this period.
        /// </summary>
        public bool IsCurrentlyActive => DateTime.Now.IsBetween(start, end);

        /// <summary>
        ///     Create an open period having only an end date/time.
        /// </summary>
        /// <param name="dateTimeUntil"></param>
        public static Period Before(DateTime dateTimeUntil) => new Period(null, dateTimeUntil);

        /// <summary>
        ///     Create an open period having only a begin date/time.
        /// </summary>
        public static Period From(DateTime dateTimeFrom) =>
            new Period(dateTimeFrom, default(DateTime?));

        /// <summary>
        ///     Set an end date/time of this period.
        /// </summary>
        public Period Until(DateTime dateTimeUntil) => new Period(start, dateTimeUntil);

        /// <summary>
        ///     Create an array of date/times which are evenly distributed within this period,
        ///     having a distance of the given time span.
        /// </summary>
        public DateTime[] Every(TimeSpan span)
        {
            if (!start.HasValue)
            {
                throw new InvalidOperationException(@"Use From() first to define start date.");
            }

            if (!end.HasValue)
            {
                throw new InvalidOperationException(@"Use Until() first to define start date.");
            }

            if (start > end)
            {
                throw new InvalidOperationException(@"From-date-time should be before the Until-date-time.");
            }


            var result = new List<DateTime>();
            var current = new DateTime(start.Value.Ticks);

            while (current <= end)
            {
                result.Add(current);
                current = current.Add(span);
            }

            return result.ToArray();
        }
    }
}