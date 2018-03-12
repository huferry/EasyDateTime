using System;
using System.Collections.Generic;

namespace EasyDateTime
{
    public static class DateTimeExtensions
    {
        public static bool IsPassed(this DateTime? dateTime) =>
            dateTime?.IsPassed() ?? false;
        
        public static bool IsPassed(this DateTime dateTime) => 
            dateTime < DateTime.Now;

        public static DateTime YesterdaySameTime(this DateTime dateTime) =>
            dateTime.AddDays(-1);

        public static DateTime TomorrowSameTime(this DateTime dateTime) =>
            dateTime.AddDays(1);

        public static int Century(this DateTime dateTime) =>
            dateTime.Year / 100 + 1;

        public static bool IsBefore(this DateTime dateTime, DateTime comparison) =>
            dateTime < comparison;

        public static bool IsBetween(this DateTime value, DateTime? begin, DateTime? end) =>
           (!begin.HasValue || value >= begin) && 
           (!end.HasValue || value <= end.Value);
    }


    public class Period
    {
        private readonly DateTime? start;
        private readonly DateTime? end;

        public static Period From(DateTime dateTimeFrom) => new Period(dateTimeFrom, default(DateTime?));

        public Period(DateTime? start, DateTime? end)
        {
            this.start = start;
            this.end = end;
        }

        public Period Until(DateTime dateTimeUntil) => new Period(this.start, dateTimeUntil);

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