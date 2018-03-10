using System;
using EasyDateTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyDateTimeUnitTests
{
    [TestClass]
    public class TimeSpanExtensions
    {
        [TestMethod]
        public void Ago_With5Seconds_Returns5MillisecondsAgo()
        {
            // Arrange.
            var expected = DateTime.Now.Subtract(TimeSpan.FromSeconds(5));

            // Act.
            var actual = 5.Seconds().Ago();

            // Assert.
            expected.ShouldBeCloseTo(actual, TimeSpan.FromSeconds(0.5));
        }

        [TestMethod]
        public void FromNow_With5Minutes_ReturnsMinutesFromNow()
        {
            // Arrange.
            var expected = DateTime.Now.AddMinutes(5);

            // Act.
            var actual = 5.Minutes().FromNow();

            // Assert.
            expected.ShouldBeCloseTo(actual, TimeSpan.FromSeconds(0.5));
        }
    }
}