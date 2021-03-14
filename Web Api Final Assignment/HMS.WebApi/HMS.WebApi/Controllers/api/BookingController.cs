using HMS.BLL.Interface;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace HMS.WebApi.Controllers.api
{
    public class BookingController : ApiController
    {
        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }


        [System.Web.Http.Route("api/booking/{id:int}")]
        [ResponseType(typeof(HMS.Models.Booking))]
        public IHttpActionResult GetBooking(int id)
        {
            Booking booking = _bookingManager.GetBooking(id);
            if (booking == null)
            {
                return Json("No record found.");
            }

            return Ok(booking);
        }

        [System.Web.Http.Route("api/booking/get")]
        public IHttpActionResult GetBooking()
        {
            var booking = _bookingManager.GetBookings();
            if (booking == null)
            {
                return Json("No record found.");
            }

            return Ok(booking);
        }

        //// PUT: api/booking/
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/booking/update/{bookingId:int}/{updatedDate:DateTime}")]
        public IHttpActionResult UpdateBookingDate(int bookingId, DateTime updatedDate)
        {
            string result = _bookingManager.UpdateBooking(bookingId, updatedDate);
            if (result == null)
            {
                return Json("No record found.");
            }
            return Ok(result);

        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("api/booking/update/{bookingId:int}/{bookingStatus}")]
        public IHttpActionResult UpdateBookingStatus(int bookingId, BookingStatus bookingStatus)
        {
            if (!(bookingStatus == BookingStatus.Definitive || bookingStatus == BookingStatus.Cancelled)) //if the updated bookingStatus is not Definitive nor Cancelled
            {
                return BadRequest("Invalid booking status.");
            }

            string result = _bookingManager.UpdateBookingStatus(bookingId, bookingStatus);

            if (result == null)
            {
                return Json("No record found.");
            }

            return Ok(result);

        }

        [System.Web.Http.Route("api/booking/room/{roomId:int}/{bookingDate:datetime}")]
        public IHttpActionResult BookRoom(short roomId, DateTime bookingDate)
        {
            try
            {
                return Ok(_bookingManager.BookRoom(roomId, bookingDate));
            }
            catch (Exception exception)
            {

                return Json(exception);
            }
        }

        
        [System.Web.Http.Route("api/booking/delete/{bookingId:int}")]
        public IHttpActionResult DeleteBooking(int bookingId)
        {
            string result = _bookingManager.DeleteBooking(bookingId);
            if (result == null)
            {
                return Json("No record found.");
            }

            if (result == "Success")
            {
                return Ok("Booking Deleted.");
            }

            return InternalServerError();
        }
    }
}