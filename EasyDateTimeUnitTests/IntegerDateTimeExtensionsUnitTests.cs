using System;
using EasyDateTime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EasyDateTimeUnitTests
{
    [TestClass]
    public class IntegerDateTimeExtensionsUnitTests
    {
        [TestMethod]
        public void Milliseconds_With5_Returns5Milliseconds()
        {
            // Act.
            var actual = 5.Milliseconds();

            // Assert.
            Assert.AreEqual(TimeSpan.FromMilliseconds(5).Ticks, actual.Ticks);
        }

        [TestMethod]
        public void Seconds_With5_Returns5Seconds()
        {
            // Act.
            var actual = 5.Seconds();

            // Assert.
            Assert.AreEqual(TimeSpan.FromSeconds(5).Ticks, actual.Ticks);
        }

        [TestMethod]
        public void Minutes_With5_Returns5Minutess()
        {
            // Act.
            var actual = 5.Minutes();

            // Assert.
            Assert.AreEqual(TimeSpan.FromMinutes(5).Ticks, actual.Ticks);
        }

        [TestMethod]
        public void Hours_With5_Returns5Minutess()
        {
            // Act.
            var actual = 5.Hours();

            // Assert.
            Assert.AreEqual(TimeSpan.FromHours(5).Ticks, actual.Ticks);
        }

        [TestMethod]
        public void Days_With5_Returns5Minutess()
        {
            // Act.
            var actual = 5.Days();

            // Assert.
            Assert.AreEqual(TimeSpan.FromDays(5).Ticks, actual.Ticks);
        }

        [TestMethod]
        public void OClock_With3_Returns3OclockToday()
        {
            // Arrange.
            var expected = DateTime.Today.AddHours(3);

            // Act.
            var actual = 3.OClock();

            // Assert.
            expected.ShouldBeCloseTo(actual, TimeSpan.FromMilliseconds(10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OClock_With25_Throws()
        {
            // Act.
            25.OClock();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OClock_WithMin1_Throws()
        {
            // Act.
            (-1).OClock();
        }

        [TestMethod]
        public void MonthName()
        {
            // Act. Assert.
            Assert.AreEqual(new DateTime(2010, 1, 12), 12.January(2010));
            Assert.AreEqual(new DateTime(2010, 2, 12), 12.February(2010));
            Assert.AreEqual(new DateTime(2010, 3, 12), 12.March(2010));
            Assert.AreEqual(new DateTime(2010, 4, 12), 12.April(2010));
            Assert.AreEqual(new DateTime(2010, 5, 12), 12.May(2010));
            Assert.AreEqual(new DateTime(2010, 6, 12), 12.June(2010));
            Assert.AreEqual(new DateTime(2010, 7, 12), 12.July(2010));
            Assert.AreEqual(new DateTime(2010, 8, 12), 12.August(2010));
            Assert.AreEqual(new DateTime(2010, 9, 12), 12.September(2010));
            Assert.AreEqual(new DateTime(2010, 10, 12), 12.October(2010));
            Assert.AreEqual(new DateTime(2010, 11, 12), 12.November(2010));
            Assert.AreEqual(new DateTime(2010, 12, 12), 12.December(2010));
        }
    }
}