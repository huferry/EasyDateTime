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
    }
}