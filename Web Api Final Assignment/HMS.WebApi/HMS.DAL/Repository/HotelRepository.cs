using HMS.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;
using AutoMapper;
using System.Data.Entity;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {

        private readonly Database.HMSDatabase _dbContext;

        private readonly IMapper _mapper;
        

        public HotelRepository()
        {
            _dbContext = new Database.HMSDatabase();
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hotel, Database.Hotel>();
                cfg.CreateMap<Database.Hotel, Hotel>();
                cfg.CreateMap<Room, Database.Room>();
                cfg.CreateMap<Database.Room, Room>();
            });

            _mapper = config.CreateMapper();
        }

        public string CreateHotel(Hotel hotel)
        {
            try
            {
                
                Database.Hotel entry =_mapper.Map<Models.Hotel,Database.Hotel>(hotel);

                //Adding data for project-specific fields
                entry.CreatedDate = DateTime.Today;
                entry.CreatedBy = 1;

                _dbContext.Hotels.Add(entry);
                _dbContext.SaveChanges();

                entry.Id = hotel.Id;

                return "Hotel Added Successfully.";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public IQueryable<Hotel> GetAllHotels()
        {
            
            var hotels = _dbContext.Hotels.OrderBy(h => h.Name).Include(r => r.Rooms).AsEnumerable().Where(h => Convert.ToBoolean(h.IsActive)).Select(_mapper.Map<Database.Hotel,Models.Hotel>);

            return hotels.AsQueryable();

        }

        public Hotel GetHotelById(int id)
        {
            try
            {
                var hotel = _dbContext.Hotels.Include(r => r.Rooms).Where(h => h.Id == id).Single();
                return _mapper.Map<Database.Hotel,Hotel>(hotel);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
