using HMS.BLL.Interface;
using HMS.DAL.Repository.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.BLL
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public string BookRoom(short roomid, DateTime bookingDate)
        {
            return _bookingRepository.BookRoom(roomid, bookingDate);
        }

        public string DeleteBooking(int id)
        {
            return _bookingRepository.DeleteBooking(id);
        }

        public Booking GetBooking(int id)
        {
            return _bookingRepository.GetBooking(id);
        }

        public string UpdateBooking(int bookingId, DateTime updatedDate)
        {
            return _bookingRepository.UpdateBooking(bookingId, updatedDate);
        }

        public string UpdateBookingStatus(int bookingId, BookingStatus bookingStatus)
        {
            return _bookingRepository.UpdateBookingStatus(bookingId, bookingStatus);
        }
    }
}
