using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        [HttpPost]
        [Route("Search3Parkings/{home_lat}/{home_lan}/1")]
        public IHttpActionResult Search3Parkings(double home_lat, double home_lan, [FromBody] RentEntities r)
        {
            try
            {
                return Ok(FindParkingBl.start(home_lat, home_lan, r));
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return Ok(e);
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
