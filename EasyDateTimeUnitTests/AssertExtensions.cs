using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyDateTimeUnitTests
{
    public static class AssertExtensions
    {
        public static void ShouldBeCloseTo(this DateTime expectation, DateTime actual, TimeSpan epsilon)
        {
            var difference = Math.Abs((expectation - actual).Ticks);
            if (difference > epsilon.Ticks)
            {
                Assert.Fail(
                    $"The actual date/time {expectation} differs too much from the expectation {expectation} with tolerance of {epsilon.TotalMilliseconds} milliseconds.");
            }
        }

        public static void ShouldBeCloseTo(this TimeSpan expectation, TimeSpan actual, TimeSpan epsilon)
        {
            var difference = Math.Abs((expectation - actual).Ticks);
            if (difference > epsilon.Ticks)
            {
                Assert.Fail(
                    $"The actual timespan {expectation} differs too much from the expectation {expectation} with tolerance of {epsilon.TotalMilliseconds} milliseconds.");
            }
        }
    }
}