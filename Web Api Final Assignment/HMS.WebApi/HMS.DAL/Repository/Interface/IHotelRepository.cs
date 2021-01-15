using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.DAL.Repository.Interface
{
    public interface IHotelRepository
    {
        string CreateHotel(Hotel hotel);

        // GET all hotels sort by alphabetic order
        IQueryable<Hotel> GetAllHotels();

        Hotel GetHotelById(int id);

    }
}
