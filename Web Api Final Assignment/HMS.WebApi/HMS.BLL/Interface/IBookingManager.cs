using HMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL.Interface
{
    public interface IBookingManager
    {
        Booking GetBooking(int id);
        string BookRoom(short roomid, DateTime bookingDate);
        string UpdateBooking(int bookingId, DateTime updatedDate);
        string UpdateBookingStatus(int id, BookingStatus bookingStatus);
        string DeleteBooking(int id);

        IQueryable<Models.Booking> GetBookings();
    }
}
