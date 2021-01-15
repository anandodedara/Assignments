using AutoMapper;
using HMS.DAL.Repository.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Database.HMSDatabase _dbContext;
        private IMapper _mapper;

        public RoomRepository()
        {
            _dbContext = new Database.HMSDatabase();
            MapperConfiguration config = new MapperConfiguration(cfg =>
                                {
                                    cfg.CreateMap<Room, Database.Room>();
                                    cfg.CreateMap<Database.Room, Room>();
                                    cfg.CreateMap<Database.Booking, Booking>();
                                    cfg.CreateMap<Booking, Database.Booking>();
                                });
            _mapper = config.CreateMapper();
        }
        public bool CheckAvailability(int roomId, DateTime date)
        {
            var isValidRoomId = _dbContext.Rooms.Where(b => b.Id == roomId).Single(); //throws an exception if roomId is invalid
            var bookingCount = _dbContext.Bookings.Where(b => b.RoomId == roomId && b.BookingDate == date && b.Status != (Database.Booking.BookingStatus)BookingStatus.Deleted).Count();
            if (bookingCount != 0)
                return false;
            return true;
        }

        public string CreateRoom(Room room)
        {
            try
            {
                Database.Room entry = _mapper.Map<Database.Room>(room);

                entry.CreatedDate = DateTime.Today;
                entry.CreatedBy = 1;

                _dbContext.Rooms.Add(entry);
                _dbContext.SaveChanges();
                return "Success";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Room GetRoom(int id)
        {
            try
            {
                Database.Room room = _dbContext.Rooms.Include(b => b.Bookings).Where(r => r.Id == id).Single();
                
                return _mapper.Map<Database.Room, Room>(room);
                
            }
            catch (Exception exception)
            {
                return null;
                throw;
            }
        }

        public IQueryable<Room> GetRooms(string city = null, int? pincode = 0, decimal? price = 0, Room.RoomCategory category = Room.RoomCategory.Cat0)
        {

            List<Room> roomList = new List<Room>();
            IQueryable<Database.Room> rooms = _dbContext.Rooms.Where(r => (r.Price <= price || price == 0) && (r.Category == (Database.Room.RoomCategory)category || category == Room.RoomCategory.Cat0) && (r.Hotel.City == city || city == null) && (r.Hotel.PINCode == pincode || pincode == 0));
            foreach (var item in rooms)
            {
                roomList.Add(_mapper.Map<Database.Room, Room>(item));
            }

            return roomList.AsQueryable();
            
        }
    }
}
