using AutoMapper;
using AutoMapper.QueryableExtensions;
using HMS.DAL.Repository.Interface;
using HMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Database.HMSDatabaseEntities _dbContext;
        private readonly IMapper _mapper;
        private MapperConfiguration config;
        public BookingRepository()
        {
            _dbContext = new Database.HMSDatabaseEntities();

            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hotel, Database.Hotel>();
                cfg.CreateMap<Database.Hotel, Hotel>();
                cfg.CreateMap<Room, Database.Room>();
                cfg.CreateMap<Database.Room, Room>();
                cfg.CreateMap<Booking, Database.Booking>();
                cfg.CreateMap<Database.Booking, Booking>();
            });

            _mapper = config.CreateMapper();
        }

        public string BookRoom(short roomId, DateTime bookingDate)
        {
            var isValidRoomId = _dbContext.Rooms.Where(b => b.Id == roomId).Single();

            //check if the room is already booked or not
            int bookingCount = _dbContext.Bookings.Where(b => b.RoomId == roomId && b.BookingDate == bookingDate && b.Status != (byte)BookingStatus.Deleted).Count();
            if (bookingCount != 0)
                return "Room is already booked on " + bookingDate;

            Database.Booking booking = new Database.Booking();
            booking.RoomId = roomId;
            booking.BookingDate = bookingDate;
            booking.Status = (byte)Database.Booking.BookingStatus.Optional;

            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
            return $"Room Booked Successfully.\nYour Booking ID is: {booking.Id}";
        }

        public string DeleteBooking(int id)
        {
            try
            {
                Database.Booking dbBooking = _dbContext.Bookings.SingleOrDefault(b => b.Id == id);
                if (dbBooking == null)
                {
                    return null;
                }
                dbBooking.Status = (byte)Database.Booking.BookingStatus.Deleted;
                _dbContext.Entry(dbBooking).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return "Success";
        }

        public Booking GetBooking(int id)
        {
            Database.Booking booking = _dbContext.Bookings.Find(id);
            return _mapper.Map<Booking>(booking);
            
        }


        public IQueryable<Models.Booking> GetBookings()
        {

            return _dbContext.Bookings.Where(b=>b.Status!=(byte)Database.Booking.BookingStatus.Deleted).AsQueryable().ProjectTo<Booking>(config);

        }


        public string UpdateBooking(int bookingId, DateTime updatedDate)
        {
            try
            {
                Database.Booking booking = _dbContext.Bookings.SingleOrDefault(b => b.Id == bookingId);
                if (booking == null)
                {
                    return $"No booking found for id: { bookingId}";
                }

                if (booking.Status == (byte)BookingStatus.Deleted)
                {
                    return "This booking is already deleted.";
                }

                int bookingCount = _dbContext.Bookings.Where(b => b.Id == bookingId && b.BookingDate == updatedDate && b.Status != (byte)BookingStatus.Deleted).Count();

                if (bookingCount != 0)
                    return "The room is already booked on the specified date.";

                booking.BookingDate = updatedDate;
                _dbContext.Entry(booking).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return "Booking Updated.";
        }

        public string UpdateBookingStatus(int id, BookingStatus bookingStatus)
        {
            try
            {
                Database.Booking booking = _dbContext.Bookings.SingleOrDefault(b => b.Id == id);
                if (booking == null)
                {
                    return null;
                }

                if (booking.Status == (byte)BookingStatus.Deleted)
                    return null;

                booking.Status = (byte)bookingStatus;
                _dbContext.Entry(booking).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return "Booking Status Updated.";
        }
    }
}
