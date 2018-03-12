using System;
using System.Diagnostics;
using System.Threading;

namespace EasyDateTime
{
    public class ScheduledAction
    {
        private readonly Action action;
        private readonly Action finished;
        private readonly int? times;
        private readonly TimeSpan timeSpan;
        private bool isAlive = true;
        private Thread worker;

        internal ScheduledAction(
            Action action,
            TimeSpan timeSpan,
            int? times,
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

        /// <summary>
        ///     Wait until all scheduled actions are finished performing.
        /// </summary>
        public void WaitUntilFinish()
        {
            var i = 0;
            while (isAlive && (!times.HasValue || i < times.Value))
            {
                PerformAction();
                i++;
            }

            finished?.Invoke();
        }

        private void PerformAction()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            action.Invoke();

            Wait(stopwatch);
        }

        private void Wait(Stopwatch start)
        {
            while (isAlive && start.Elapsed < timeSpan)
            {
                // just wait
            }
        }

        /// <summary>
        ///     Perform the action on a new thread without waiting all actions to finish performing.
        ///     Invoke the Stop() method to stop the scheduling.
        /// </summary>
        /// <param name="actionWhenFinished">Will be invoked when all scheduled actions are finished.</param>
        /// <returns>A new scheduled action, can be used to stop the scheduling.</returns>
        public ScheduledAction WithoutWaiting(Action actionWhenFinished = null)
        {
            var newAction = Copy(actionWhenFinished);
            worker = new Thread(DoWaitUntilFinish);
            worker.Start(newAction);
            return newAction;
        }

        public void Stop()
        {
            isAlive = false;
        }

        private static void DoWaitUntilFinish(object scheduledAction)
        {
            (scheduledAction as ScheduledAction)?.WaitUntilFinish();
        }
    }
}