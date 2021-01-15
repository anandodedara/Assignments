using HMS.BLL.Interface;
using HMS.Models;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

namespace HMS.WebApi.Controllers.api
{
    
    [Authorize]
    public class RoomController : ApiController
    {
        private readonly IRoomManager _roomManager;

        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        // GET: api/rooms
        public IHttpActionResult GetRoom(int id)
        {
            Room room = _roomManager.GetRoom(id);

            if (room==null)
                return Json("No record found.");

            return Ok(room);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetRooms(string city, int pincode, decimal price, Room.RoomCategory category)
        {
            _roomManager.GetRooms(city: city, pincode: pincode, price: price, category: category);
            return Ok();            
        }
        
        [System.Web.Http.HttpGet]
        public IHttpActionResult CheckRoom(int roomId, DateTime date)
        {
            try
            {
                bool isAvailable = _roomManager.CheckAvailability(roomId, date);

                return Ok(isAvailable);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        
        public IHttpActionResult Add(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_roomManager.CreateRoom(room));
        }
    }
}