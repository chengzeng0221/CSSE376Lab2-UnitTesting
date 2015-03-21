using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
		//TODO Task 7 items go here
        private readonly DateTime StartDate = new DateTime(2009, 11, 1);
        private readonly DateTime OneDayEndDate = new DateTime(2009, 11, 2);
        private readonly DateTime TwoDayEndDate = new DateTime(2009, 11, 3);
        private readonly DateTime TenDayEndDate = new DateTime(2009, 11, 11);



        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(StartDate, OneDayEndDate, 0);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayStay()
        {
            var target = new Flight(StartDate, OneDayEndDate, 0);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatHotelHasCorrectBasePriceForTwoDayStay()
        {
            var target = new Flight(StartDate, TwoDayEndDate, 0);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatHotelHasCorrectBasePriceForTenDaysStay()
        {
            var target = new Flight(StartDate, TenDayEndDate, 0);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatHotelThrowsOnNegativeMiles()
        {
            new Flight(StartDate, TenDayEndDate, -1);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatHotelThrowsOnEndDateBeforeStartDate()
        {
            new Flight(TenDayEndDate, StartDate, 0);
        }
	}
}
