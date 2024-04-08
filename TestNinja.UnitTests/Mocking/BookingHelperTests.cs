using Moq;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private List<Booking> Bookings;

        [SetUp]
        public void Setup() 
        {
            Bookings = new List<Booking>{
                new Booking{ Id = 1, ArrivalDate = new DateTime(2024,1,1), DepartureDate = new DateTime(2024,1,15), Status = "Active", Reference = "1 quincena Enero" },
                new Booking{ Id = 2, ArrivalDate = new DateTime(2024,1,20), DepartureDate = new DateTime(2024,1,31), Status = "Active", Reference = "2 quincena Enero" }
            };
        }

        [Test]
        public void OverlappingBookingsExist_NoOverlap_ReturnsEmpty()
        {
            var booking = new Booking { Status = "Active", ArrivalDate = new DateTime(2024, 10, 10), DepartureDate = new DateTime(2024, 10, 16) };
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(booking.Id)).Returns(Bookings.AsQueryable);

            var response = BookingHelper.OverlappingBookingsExist(booking, repository.Object);

            Assert.That(response, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_OverlapArrivalDate_ReturnsFirstBooking()
        {
            var booking = new Booking { Status = "Active", ArrivalDate = new DateTime(2024, 1, 10), DepartureDate = new DateTime(2024, 1, 16) };
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(booking.Id)).Returns(Bookings.AsQueryable);

            var response = BookingHelper.OverlappingBookingsExist(booking, repository.Object);

            Assert.That(response, Is.EqualTo("1 quincena Enero"));
        }

        [Test]
        public void OverlappingBookingsExist_OverlapDepartureDate_ReturnsSecondBooking()
        {
            var booking = new Booking { Status = "Active", ArrivalDate = new DateTime(2024, 1, 17), DepartureDate = new DateTime(2024, 1, 22) };
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(booking.Id)).Returns(Bookings.AsQueryable);

            var response = BookingHelper.OverlappingBookingsExist(booking, repository.Object);

            Assert.That(response, Is.EqualTo("2 quincena Enero"));
        }

        [Test]
        public void OverlappingBookingsExist_OverlapBothDatesIn_ReturnsSecondBooking()
        {
            var booking = new Booking { Status = "Active", ArrivalDate = new DateTime(2024, 1, 22), DepartureDate = new DateTime(2024, 1, 28) };
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(booking.Id)).Returns(Bookings.AsQueryable);

            var response = BookingHelper.OverlappingBookingsExist(booking, repository.Object);

            Assert.That(response, Is.EqualTo("2 quincena Enero"));
        }

        [Test]
        public void OverlappingBookingsExist_OverlapBothDatesOut_ReturnsSecondBooking()
        {
            var booking = new Booking { Status = "Active", ArrivalDate = new DateTime(2024, 1, 16), DepartureDate = new DateTime(2024, 2, 28) };
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(booking.Id)).Returns(Bookings.AsQueryable);

            var response = BookingHelper.OverlappingBookingsExist(booking, repository.Object);

            Assert.That(response, Is.EqualTo("2 quincena Enero"));
        }

        [Test]
        public void OverlappingBookingsExist_BookingIsCancelled_ReturnsEmpty()
        {
            var booking = new Booking { Status = "Cancelled" };
            var repository = new Mock<IBookingRepository>();
            repository.Setup(r => r.GetActiveBookings(booking.Id)).Returns(Bookings.AsQueryable);

            var response = BookingHelper.OverlappingBookingsExist(booking, repository.Object);

            Assert.That(response, Is.Empty);


        }

    }
}
