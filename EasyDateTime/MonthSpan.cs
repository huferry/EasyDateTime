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

        public DateTime Ago() => DateTime.Now.AddMonths(-value);
        
        public DateTime FromNow() => DateTime.Now.AddMonths(value);

        public TimeSpan Approximately() => DateTime.Today.AddMonths(value) - DateTime.Today;
    }
}