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
    [RoutePrefix("api/Rent")]

    public class RentController : ApiController
    {

        // שליפת רשימת השכרות
        [HttpGet]
        [Route("GetRentList")]
        public IHttpActionResult GetRentList()
        {
            return Ok(RentBl.GetRentList());
        }


        // שליפת השכרה לפי קוד
        [HttpGet]
        [Route("GetParkingById/{id}")]
        public IHttpActionResult GetParkingById(int id)
        {
            return Ok(RentBl.GetRentById(id));
        }

        // הוספת השכרה
        [HttpPut]
        [Route("addRent")]
        public IHttpActionResult addRent([FromBody] RentEntities r)
        {
            try
            {
                RentBl.addRent(r);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }

        // מחיקת השכרה
        [HttpDelete]
        [Route("deleteRent")]
        public IHttpActionResult de(int id)
        {
            try
            {
                RentBl.deleteRent(id);
                return Ok(true);
            }
            catch
            {
                return Ok(false);

            }
        }


        // עדכון השכרה
        [HttpPost]
        [Route("updateRent")]
        public IHttpActionResult updateRent([FromBody] RentEntities r)
        {
                RentBl.updateRent(r);
                    return Ok(true);
        }





     
        
 







    }
}
