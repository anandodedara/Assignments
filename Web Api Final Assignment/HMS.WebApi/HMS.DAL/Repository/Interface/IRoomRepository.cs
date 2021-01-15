using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repository.Interface
{
    public interface IRoomRepository
    {
        Room GetRoom(int id);
        string CreateRoom(Room room);
        IQueryable<Room> GetRooms(string city=null,int? pincode=0, decimal? price=0, Room.RoomCategory category=0);
        bool CheckAvailability(int roomId, DateTime date);
    }
}
