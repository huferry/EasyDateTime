using System;

namespace EasyDateTime
{
    public static class ActionExtensions
    {
        public static ScheduledAction DoEvery(
            this Action action,
            TimeSpan timeSpan,
            int? times = null)
        {
            return new ScheduledAction(action, timeSpan, times);
        }

        public static void DoAfter(
            this Action action,
            TimeSpan timeSpan,
            Action finishAction)
        {
            var scheduledAction = new ScheduledAction(action, timeSpan, 2);
            scheduledAction.SkipFirst(finishAction);
        }
    }
}