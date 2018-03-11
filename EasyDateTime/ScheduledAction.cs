using System;
using System.Diagnostics;
using System.Threading;

namespace EasyDateTime
{
    public class ScheduledAction
    {
        private readonly Action action;
        private readonly Action finished;
        private readonly int times;
        private readonly TimeSpan timeSpan;

        internal ScheduledAction(
            Action action,
            TimeSpan timeSpan,
            int times,
            Action finished = null)
        {
            if (times < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(times));
            }

            this.action = action;
            this.times = times;
            this.finished = finished;
            this.timeSpan = timeSpan;
        }

        private ScheduledAction Copy(Action newFinishedAction)
        {
            return new ScheduledAction(action, timeSpan, times, newFinishedAction);
        }

        public void WaitUntilFinish()
        {
            for (var i = 0; i < times; i++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                action.Invoke();

                Wait(stopwatch);
            }

            finished?.Invoke();
        }

        private void Wait(Stopwatch start)
        {
            while (start.Elapsed < timeSpan)
            {
                // just wait
            }
        }

        public void WithoutWaiting(Action actionWhenFinished = null)
        {
            var thread = new Thread(Do);
            thread.Start(Copy(actionWhenFinished));
        }

        public static void Do(object scheduledAction)
        {
            (scheduledAction as ScheduledAction)?.WaitUntilFinish();
        }
    }
}