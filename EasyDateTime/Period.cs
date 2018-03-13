using System;
using System.Collections.Generic;

namespace EasyDateTime
{
    public class Period
    {
        private readonly DateTime? end;
        private readonly DateTime? start;

        private Period(DateTime? start, DateTime? end)
        {
            this.start = start;
            this.end = end;
        }

        public bool IsCurrentlyActive => DateTime.Now.IsBetween(start, end);

        public static Period Before(DateTime dateTimeUntil)
        {
            return new Period(null, dateTimeUntil);
        }

        public static Period From(DateTime dateTimeFrom)
        {
            return new Period(dateTimeFrom, default(DateTime?));
        }

        public Period Until(DateTime dateTimeUntil)
        {
            return new Period(start, dateTimeUntil);
        }

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