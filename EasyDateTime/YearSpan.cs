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

        public DateTime Ago() => DateTime.Now.AddYears(-value);

        public DateTime FromNow() =>  DateTime.Now.AddYears(value);
    
        public TimeSpan Approximately() => DateTime.Today.AddYears(value) - DateTime.Today;
    }
}