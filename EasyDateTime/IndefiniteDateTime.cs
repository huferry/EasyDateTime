using System;

namespace EasyDateTime
{
    public class IndefiniteDateTime
    {
        private readonly DurationType durationType;
        private readonly int value;

        internal IndefiniteDateTime(DurationType durationType, int value)
        {
            this.durationType = durationType;
            this.value = value;
        }

        public DateTime Ago()
        {
            switch (durationType)
            {
                case DurationType.Year:
                    return DateTime.Now.AddYears(-value);
                case DurationType.Month:
                    return DateTime.Now.AddMonths(-value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public DateTime FromNow()
        {
            switch (durationType)
            {
                case DurationType.Year:
                    return DateTime.Now.AddYears(value);
                case DurationType.Month:
                    return DateTime.Now.AddMonths(value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}