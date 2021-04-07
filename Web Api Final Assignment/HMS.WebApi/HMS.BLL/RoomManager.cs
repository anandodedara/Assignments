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
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public bool CheckAvailability(int roomId, DateTime date)
        {
            bool isAvailable = _roomRepository.CheckAvailability(roomId, date);
            return isAvailable;
        }

        public string CreateRoom(Room room)
        {
            return _roomRepository.CreateRoom(room);
        }

        public Room GetRoom(int id)
        {
            return _roomRepository.GetRoom(id);
        }

        public IQueryable<Room> GetRooms(string city = null, int? pincode = 0, decimal? price = 0, Room.RoomCategory category = Room.RoomCategory.Cat0)
        {
            return _roomRepository.GetRooms(city,pincode,price,category);
        }

        public IQueryable<Room> GetAllRooms() {
            return _roomRepository.GetAllRooms();
        }
    }
}
