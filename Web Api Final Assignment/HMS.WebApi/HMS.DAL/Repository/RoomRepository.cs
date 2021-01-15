using AutoMapper;
using HMS.DAL.Repository.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public string CreateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public Room GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Room> GetRooms(string city = null, int? pincode = 0, int? price = 0, short? category = 0)
        {
            throw new NotImplementedException();
        }
    }
}
