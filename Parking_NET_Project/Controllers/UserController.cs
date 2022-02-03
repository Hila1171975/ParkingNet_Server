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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        //הוספת לקוח
        [HttpPut]
        [Route("addUser")]
        public IHttpActionResult addUser([FromBody] UsersEntities user)
        {
            try
            {
                int id= UsersBl.addUser(user);
                return Ok(id);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return Ok(-1);
            }
        }



        //  עדכון משתמש  
       [HttpPost]
       [Route("updateUser")]
       public IHttpActionResult updateUser([FromBody] UsersEntities User)
        {
            try
            {
                UsersBl.updateUser(User);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }


        // האם לקוח קיים
        [HttpGet]
        [Route("isExist/{name}/{password}")]
        public IHttpActionResult isExist(string name, string password)
        {
            int id = UsersBl.isExist(name, password);
            return Ok(id);
        }
    }
}
