using System;
using System.Linq;
using EasyDateTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyDateTimeUnitTests
{
    [TestClass]
    public class PeriodUnitTests
    {
        [TestMethod]
        public void Every_WithPeriodOf1HourEvery5Minutes_Returns13Times()
        {
            // Arrange.
            var start = DateTime.Today;
            var end = start.AddHours(1);

            // Act.
            var actual = Period.From(start).Until(end).Every(5.Minutes());

            // Assert.
            Assert.AreEqual(13, actual.Length);
            Assert.AreEqual(start, actual.First());
            actual.Last().ShouldBeCloseTo(end, 50.Milliseconds());
        }

        [TestMethod]
        public void IsCurrentlyActive_WithPeriodSurroundingNow_ReturnsTrue()
        {
            // Arrange.
            var start = 1.Days().Ago();
            var end = 1.Hours().FromNow();

            // Act.
            var actual = Period.From(start).Until(end).IsCurrentlyActive;

            // Assert.
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsCurrentlyActive_WithOpenEndPeriodAndStartInThePast_ReturnsTrue()
        {
            // Arrange.
            var start = 1.Days().Ago();

            // Act.
            var actual = Period.From(start).IsCurrentlyActive;

            // Assert.
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsCurrentlyActive_WithOpenStartPeriodAndEndInThePast_ReturnsFalse()
        {
            // Arrange.
            var end = 4.Months().Ago();

            // Act.
            var actual = Period.Before(end).IsCurrentlyActive;

            // Assert.
            Assert.IsFalse(actual);
        }
    }
}