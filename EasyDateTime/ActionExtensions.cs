using System;

namespace EasyDateTime
{
    public static class ActionExtensions
    {
        /// <summary>
        ///     Create a scheduled action that will invoke the action every given
        ///     time span for any given times.
        /// </summary>
        /// <param name="action">The action to be performed.</param>
        /// <param name="timeSpan">The time span between invocations.</param>
        /// <param name="times">The number of invocations.</param>
        /// <returns>
        ///     Scheduled action object.
        /// </returns>
        public static ScheduledAction DoEvery(
            this Action action,
            TimeSpan timeSpan,
            int? times = null)
        {
            return new ScheduledAction(action, timeSpan, times);
        }

        /// <summary>
        ///     Invoke the action after a period of time.
        /// </summary>
        /// <param name="action">The action to be performed.</param>
        /// <param name="delay">The delay.</param>
        /// <param name="finishAction">The action that should be invoked there after.</param>
        public static void DoAfter(
            this Action action,
            TimeSpan delay,
            Action finishAction)
        {
            (new ScheduledAction(action, delay, 2)).SkipFirst(finishAction);
        }
    }
}