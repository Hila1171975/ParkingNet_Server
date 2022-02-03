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
    [RoutePrefix("api/City")]

    public class CityController : ApiController
    {
        // שליפת רשימת ערים
        [HttpGet]
        [Route("GetRentList")]
        public IHttpActionResult GetCityList()
        {
            return Ok(CityBl.GetCityList());
        }


        // שליפת עיר לפי קוד
        [HttpGet]
        [Route("GetCityById/{id}")]
        public IHttpActionResult GetCityById(int id)
        {
            return Ok(CityBl.GetCityById(id));
        }

        // הוספת עיר
        [HttpPut]
        [Route("addCity")]
        public IHttpActionResult addCity([FromBody] CityEntities c)
        {
            try
            {
                CityBl.addCity(c);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }

        // מחיקת עיר
        // ???


        // עדכון עיר
        // ???

    }
}
