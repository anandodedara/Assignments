using HMS.DAL.Repository.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public string BookRoom(int roomId, DateTime bookingDate)
        {
            throw new NotImplementedException();
        }

        public string DeleteBooking(int id)
        {
            throw new NotImplementedException();
        }

        public Booking GetBooking(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Booking> GetBookings()
        {
            throw new NotImplementedException();
        }

        public string UpdateBooking(int bookingId, DateTime updatedDate)
        {
            throw new NotImplementedException();
        }

        public string UpdateBookingStatus(int id, Status bookingStatus)
        {
            throw new NotImplementedException();
        }
    }
}
