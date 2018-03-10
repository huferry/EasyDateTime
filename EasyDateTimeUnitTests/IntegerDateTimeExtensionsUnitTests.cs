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
    }
}