using System;
using System.Linq;
using EasyDateTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyDateTimeUnitTests
{
    [TestClass]
    public class DateTimeExtensionsUnitTests
    {
        [TestMethod]
        public void IsPassed_WithNull_ReturnsFalse()
        {
            // Act.
            var actual = ((DateTime?) null).IsPassed();

            // Assert.
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsPassed_WithNullableDateInThePast_ReturnsTrue()
        {
            // Arrange.
            DateTime? sut = 5.Minutes().Ago();

            // Act.
            var actual = sut.IsPassed();

            // Assert.
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsPassed_WithDateInThePast_ReturnsTrue()
        {
            // Arrange.
            var sut = 5.Minutes().Ago();

            // Act.
            var actual = sut.IsPassed();

            // Assert.
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void YesterdaySameTime_WithNow_ShouldReturnYesterdayWithSameTime()
        {
            // Act.
            var actual = DateTime.Now.YesterdaySameTime();

            // Assert.
            actual.ShouldBeCloseTo(DateTime.Now.AddDays(-1), 1.Seconds());
        }

        [TestMethod]
        public void TomorrowSameTime_WithNow_ShouldReturnTomorrowWithSameTime()
        {
            // Act.
            var actual = DateTime.Now.TomorrowSameTime();

            // Assert.
            actual.ShouldBeCloseTo(DateTime.Now.AddDays(1), 1.Seconds());
        }

        [DataTestMethod]
        [DataRow(2010, 21)]
        [DataRow(1980, 20)]
        [DataRow(5000, 51)]
        public void Century_WithDateTimeOfGivenYear_ReturnsCentury(int year, int expectation)
        {
            // Arrange.
            var date = new DateTime(year, 1, 1);

            // Act.
            var century = date.Century();

            // Assert.
            Assert.AreEqual(expectation, century);
        }

        [TestMethod]
        public void IsBefore_WithTimeAfter_ReturnFalse()
        {
            // Arrange.
            var fiveMinutesAgo = 5.Minutes().Ago();

            // Act.
            var actual = 5.Minutes().FromNow().IsBefore(fiveMinutesAgo);

            // Assert.
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsBefore_WithTimeBefore_ReturnTrue()
        {
            // Arrange.
            var fiveMinutesAgo = 5.Minutes().FromNow();

            // Act.
            var actual = 5.Minutes().Ago().IsBefore(fiveMinutesAgo);

            // Assert.
            Assert.IsTrue(actual);
        }

        [DataTestMethod]
        [DataRow(100, true)]
        [DataRow(200, true)]
        [DataRow(99, false)]
        [DataRow(201, false)]
        public void IsBetween_WithBeginAndEnd_ReturnsTrueIfBetweenOrEqual(long tick, bool expected)
        {
            // Arrange.
            var begin = new DateTime(100);
            var end = new DateTime(200);

            // Act.
            var actual = (new DateTime(tick)).IsBetween(begin, end);

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(100, true)]
        [DataRow(200, true)]
        [DataRow(99, false)]
        [DataRow(201, true)]
        public void IsBetween_WithBeginWithoutEnd_ReturnsIfAfterBegin(long tick, bool expected)
        {
            // Arrange.
            var begin = new DateTime(100);

            // Act.
            var actual = (new DateTime(tick)).IsBetween(begin, null);

            // Assert.
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(100, true)]
        [DataRow(101, false)]
        [DataRow(99, true)]
        public void IsBetween_WithoutBeginWithEnd_ReturnsIfBeforeEnd(long tick, bool expected)
        {
            // Arrange.
            var end = new DateTime(100);

            // Act.
            var actual = (new DateTime(tick)).IsBetween(null, end);

            // Assert.
            Assert.AreEqual(expected, actual);
        }

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
    }
}