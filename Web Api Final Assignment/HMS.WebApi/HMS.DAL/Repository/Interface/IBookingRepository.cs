using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;
namespace HMS.DAL.Repository.Interface
{
    public interface IBookingRepository
    {
        Booking GetBooking(int id);
        string BookRoom(short roomId, DateTime bookingDate);
        string UpdateBooking(int bookingId, DateTime updatedDate);
        string UpdateBookingStatus(int id, BookingStatus bookingStatus);
        string DeleteBooking(int id);
        IQueryable<Models.Booking> GetBookings();
    }
}
