using System;
using EasyDateTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyDateTimeUnitTests
{
    [TestClass]
    public class IndefiniteTimeSpanUnitTests
    {
        [TestMethod]
        public void FromNow_With5Months_Returns5MonthsFromNow()
        {
            // Arrange.
            var expectation = DateTime.Now.AddMonths(5);

            // Act.
            var actual = 5.Months().FromNow();

            // Assert.
            expectation.ShouldBeCloseTo(actual, TimeSpan.FromSeconds(0.5));
        }

        [TestMethod]
        public void Ago_With5Year_Returns5YearsAgo()
        {
            // Arrange.
            var expectation = DateTime.Now.AddYears(-5);

            // Act.
            var actual = 5.Years().Ago();

            // Assert.
            expectation.ShouldBeCloseTo(actual, TimeSpan.FromSeconds(0.5));
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(13)]
        [DataRow(20)]
        [DataRow(-4)]
        public void Approximately_WithXYears_ReturnsAmoutOfDaysUntilXYearsFromToday(int x)
        {
            // Arrange.
            var expectation = DateTime.Today.AddYears(x) - DateTime.Today;

            // Act.
            var actual = x.Years().Approximately();

            // Assert.
            Assert.AreEqual(expectation, actual);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(3)]
        [DataRow(13)]
        [DataRow(20)]
        [DataRow(-4)]
        public void Approximately_WithXMonths_ReturnsAmoutOfDaysUntilXMonthsFromToday(int months)
        {
            // Arrange.
            var expectation = DateTime.Today.AddMonths(months) - DateTime.Today;

            // Act.
            var actual = months.Months().Approximately();

            // Assert.
            Assert.AreEqual(expectation, actual);
        }
    }
}