using System;

namespace EasyDateTime
{
    public interface IIndefiniteTimeSpan
    {
        DateTime Ago();
        DateTime FromNow();
        TimeSpan Approximately();
    }
}