using System;

namespace EasyDateTime
{
    public static class ActionExtensions
    {
        public static ScheduledAction DoEvery(
            this Action action,
            TimeSpan timeSpan,
            int times)
        {
            return new ScheduledAction(action, timeSpan, times);
        }
    }
}