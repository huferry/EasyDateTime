using System;
using System.Diagnostics;
using System.Threading;
using EasyDateTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyDateTimeUnitTests
{
    [TestClass]
    public class ScheduledActionUnitTests
    {
        [TestMethod]
        public void WaitUntilFinish_20MillisecondsFor3Times_ShouldInvoke3Times()
        {
            // Arrange.
            var count = 0;
            var log = "";

            Action act = () => log += (count++).ToString();

            var start = DateTime.Now;

            // Act.
            act.DoEvery(20.Milliseconds(), 3)
                .WaitUntilFinish();

            // Assert.
            Assert.AreEqual("012", log);
            start.ShouldBeCloseTo(
                DateTime.Now.AddMilliseconds(-60),
                TimeSpan.FromMilliseconds(20));
        }

        [TestMethod]
        public void WithoutWaiting_20MillisecondsFor3Times_ShouldInvoke3Times()
        {
            // Arrange.
            var count = 0;
            var log = "";

            Action act = () => log += (count++).ToString();

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Act.
            act.DoEvery(100.Milliseconds(), 3)
                .WithoutWaiting();

            // Assert.
            Assert.IsTrue(stopwatch.Elapsed.TotalMilliseconds < 20);
            Thread.Sleep(500);
            Assert.AreEqual("012", log);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DoEvery_WithMinus1Time_Throws()
        {
            // Arrange.
            Action act = () => Console.WriteLine("test");

            // Act.
            act.DoEvery(20.Milliseconds(), -1);
        }

        [TestMethod]
        public void WithoutWaiting_WithFinishEvent_ShouldInvokeEvent()
        {
            // Arrange.
            var log = "";
            var sw = new Stopwatch();

            Action act = () => Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Start();

            // Act.
            act.DoEvery(20.Milliseconds(), 5)
                .WithoutWaiting(() => log = "finished");

            // Assert.
            Thread.Sleep(200);
            Assert.AreEqual("finished", log);
        }

        [TestMethod]
        public void Stop_WhileRepeatingActionWitTimes_ShouldStop()
        {
            // Arrange.
            var count = 0;
            Action act = () => count++;

            var worker = act.DoEvery(10.Milliseconds(), 50)
                .WithoutWaiting();

            Thread.Sleep(100);

            // Act.
            worker.Stop();

            // Assert.
            var lastCount = count;
            Thread.Sleep(500);
            Assert.AreEqual(lastCount, count);
        }

        [TestMethod]
        public void Stop_WhileRepeatingActionWithNoTimes_ShouldStop()
        {
            // Arrange.
            var count = 0;
            var finished = false;
            Action act = () => count++;

            var worker = act.DoEvery(10.Milliseconds())
                .WithoutWaiting(() => finished = true);

            Thread.Sleep(100);

            // Act.
            worker.Stop();

            // Assert.
            Thread.Sleep(20);
            var lastCount = count;
            Thread.Sleep(200);
            Assert.AreEqual(lastCount, count);
            Assert.IsTrue(finished);
        }

        [TestMethod]
        public void DoAfter_With1Second_ShouldWaitFor1Second()
        {
            // Arrange.
            var stopwatch = new Stopwatch();

            Action stop = () => stopwatch.Stop();

            stopwatch.Start();

            // Act.
            stop.DoAfter(500.Milliseconds(), () => Debug.WriteLine($"Stopwatch ends: {stopwatch.Elapsed}"));

            // Assert.
            Thread.Sleep(600.Milliseconds());
            stopwatch.Elapsed.ShouldBeCloseTo(500.Milliseconds(), 5.Milliseconds());
        }
    }
}