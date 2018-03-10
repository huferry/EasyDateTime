using System;
using EasyDateTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyDateTimeUnitTests
{
    [TestClass]
    public class IndefiniteDateTimeUnitTests
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
    }
}