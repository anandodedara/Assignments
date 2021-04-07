using TestingPassengerDemo.Models;

using CLPM.DAL.Repository.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestingPassengerDemo.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IPassengerRepository _passengerManager;

        public PassengerController(IPassengerRepository passengerManager)
        {
            _passengerManager = passengerManager;
        }

        [HttpPost]
        
        public Passenger AddPassenger([FromBody] Passenger model)
        {
            return _passengerManager.PassengerRegistration(model);
        }

        [HttpPut]
       
        public Passenger UpdatePassenger([FromBody] Passenger model)
        {

            var result = _passengerManager.PassengerDetailsUpdate(model);
            return result;
        }

        [HttpDelete]
        
        public bool DeletePassenger(String id)
        {

            bool result = _passengerManager.PassengerDetailsDelete(id);
            return result;
        }

        [HttpGet]
       
        public HttpResponseMessage GetPassengerById(String id)
        {
            if (id != null)
            {
                try
                {

                    var passenger = _passengerManager.getPassengerByPassengerId(id);
                    if (passenger.FirstName != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, passenger);

                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.InternalServerError);

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public IList<Passenger> getAllPassenger()
        {
            return _passengerManager.getAllPassenger();
        }
    }
}

