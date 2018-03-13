using System;
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
        public void IsDayname_WithDayOfWeek_ReturnsTrue()
        {
            // Arrange.
            var monday = new DateTime(2018, 3,12);

            // Act. Assert.
            Assert.IsTrue(monday.IsMonday());
            Assert.IsTrue(monday.AddDays(1).IsTuesday());
            Assert.IsTrue(monday.AddDays(2).IsWednesday());
            Assert.IsTrue(monday.AddDays(3).IsThursday());
            Assert.IsTrue(monday.AddDays(4).IsFriday());
            Assert.IsTrue(monday.AddDays(5).IsSaturday());
            Assert.IsTrue(monday.AddDays(6).IsSunday());
        }

        [TestMethod]
        public void IsDayname_WithOtherDayOfWeek_ReturnsFalse()
        {
            // Arrange.
            var sunday = new DateTime(2018, 3, 11);

            // Act. Assert.
            Assert.IsFalse(sunday.IsMonday());
            Assert.IsFalse(sunday.AddDays(1).IsTuesday());
            Assert.IsFalse(sunday.AddDays(2).IsWednesday());
            Assert.IsFalse(sunday.AddDays(3).IsThursday());
            Assert.IsFalse(sunday.AddDays(4).IsFriday());
            Assert.IsFalse(sunday.AddDays(5).IsSaturday());
            Assert.IsFalse(sunday.AddDays(6).IsSunday());
        }
    }
}