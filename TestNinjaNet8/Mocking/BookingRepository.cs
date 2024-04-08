using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId);
    }

    public class BookingRepository : IBookingRepository
    {

        public BookingRepository()
        {

        }

        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => (b.Id != excludedBookingId || excludedBookingId == null) && b.Status != "Cancelled");

            return bookings;
        }
    }
}
