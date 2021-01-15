using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.BLL.Interface
{
    public interface IHotelManager
    {
        Hotel GetHotelById(int id);
        IQueryable<Hotel> GetAllHotels();
        string CreateHotel(Hotel hotel);


    }
}
