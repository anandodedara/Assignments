using HMS.BLL.Interface;
using System;
using System.Linq;
using System.Web.Http;

namespace HMS.WebApi.Controllers.api
{
    public class HotelController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        
        public IHttpActionResult Get() {
            var hotels = _hotelManager.GetAllHotels().AsEnumerable();
            if (!hotels.Any())
                return NotFound();
            else
                return Ok(hotels);
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                //Throws an exception if no record found
                var hotel = _hotelManager.GetHotelById(id); 

                return Ok(hotel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Json(new Models.Hotel() { });
            }
        }

        // POST: api/hotels
        public IHttpActionResult Add([FromBody] Models.Hotel hotel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Data is not valid.");

            return Ok(_hotelManager.CreateHotel(hotel));
        }
    }
}