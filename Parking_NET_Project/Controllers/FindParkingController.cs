using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using Entities;

namespace Parking_NET_Project.Controllers
{
    [RoutePrefix("api/FindParking")]
    public class FindParkingController : ApiController
    {
        // חיפוש 3 חניות הקרובות ביותר
        [HttpGet]
        [Route("Search3Parkings")]
        //public IHttpActionResult Search3Parkings(double home_lat, double home_lan, [FromBody] DateTime r1,DateTime r2, DateTime r3, DateTime r4)
        public IHttpActionResult Search3Parkings()
        {
            try
            {
                DateTime d = new DateTime();
                RentEntities r = new RentEntities();
                r.EntryDate = DateTime.Now;
                r.EntryDate = DateTime.Now;
                r.EntryHour = DateTime.Now;
                double lat = 31.783985039956992;
                double lng = 35.223761640182104;
                r.LeavingHour = DateTime.Now;
                r.LeavingHour = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, DateTime.Now.Date.Day, 00, 00, 00, 00);


                return Ok(FindParkingBl.start(lat, lng, r));
            }
            catch
            {
                return Ok(true);
            }
        }

        //// חיפוש 3 חניות הקרובות ביותר
        //[HttpPost]
        //[Route("Search3Parkings/{home_lat}/{home_lan}")]
        //public IHttpActionResult Search3Parkings(double home_lat, double home_lan, [FromBody] RentEntities r)
        //{
        //    try
        //    {
        //        return Ok(FindParkingBl.start(home_lat, home_lan, r));
        //    }
        //    catch
        //    {
        //        return Ok(true);
        //    }
        //}
    }
}
