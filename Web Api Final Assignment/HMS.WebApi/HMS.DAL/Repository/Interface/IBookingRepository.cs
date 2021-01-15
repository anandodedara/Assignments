using System;
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
        string BookRoom(int roomId, DateTime bookingDate);
        IQueryable<Booking> GetBookings();
        string UpdateBooking(int bookingId, DateTime updatedDate);
        string UpdateBookingStatus(int id, Status bookingStatus);
        string DeleteBooking(int id);
    }
}
