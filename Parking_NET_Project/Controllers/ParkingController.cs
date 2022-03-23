using BL;
using Entities;
using System;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Http;

namespace Parking_NET_Project.Controllers
{
    [RoutePrefix("api/Parking")]
    public class ParkingController : ApiController
    {
        //שליפת רשימת החניות

        [HttpGet]
        [Route("GetParkingList")]
        public IHttpActionResult GetParkingList()
        {
            return Ok(ParkingBl.GetParkingList());
        }


        // שליפת חניה לפי קוד

        [HttpGet]
        [Route("GetParkingById/{id}")]
        public IHttpActionResult GetParkingById(int id)
        {
            return Ok(ParkingBl.GetParkingById(id));
        }

        // שליפת חניה לפי קוד משתמש

        [HttpGet]
        [Route("GetParkingListByUserId/{UserId}")]
        public IHttpActionResult GetParkingListByUserId(int UserId)
        {
            return Ok(ParkingBl.GetParkingListByUserId(UserId));
        }


        // הוספת חניה

        [HttpPut]
        [Route("addParking")]
        public IHttpActionResult addParking([FromBody] ParkingEntities p)
        {
            //ParkingEntities p1 = new ParkingEntities()
            //{

            //    UserId = 1,
            //    CityId = 1,
            //    Street = "hh",
            //    HouseNum = null,
            //    PayPerHour = 1,
            //    ElectronicGate = true,
            //    Indoor = true,
            //    Shady = true,
            //    SizeFor = "alll",
            //    CancelTime = 2,
            //    Notes = null,
            //    IMG1 = null,
            //    IMG2 = null,
            //    IMG3 = null,
            //    AccountId = null
            //};
            //ParkingBl.addParking(p1);

            try
            {
                ParkingBl.addParking(p);
                return Ok(true);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return Ok(false);
            }
        }


        // מחיקת חניה

        [HttpDelete]
        [Route("deleteParking")]
        public IHttpActionResult deleteParking(int id)
        {
            try
            {
                ParkingBl.deleteParking(id);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }


        // עדכון חניה

        [HttpPost]
        [Route("updateParking")]
        public IHttpActionResult updateParking([FromBody] ParkingEntities p)
        {
            try
            {
                ParkingBl.updateParking(p);
                return Ok(true);
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                return Ok(false);
            }
        }

        [Route("uploadImage")]
        [HttpPost]
        public string[] uploadImage()
        {
            var httpRequest = HttpContext.Current.Request;
            string filePath = @"D:\Studies\פרויקט שנה ג\Git\ParkingNET\src\assets\gallery\";
            string name = "", fileName = "";
            string[] filesNames = new string[3];

            for (int i = 0; i < httpRequest.Files.Count; i++)
            {
                var postedFile = httpRequest.Files["myImage"+i];
                if (postedFile != null)
                {
                    name = postedFile.FileName;
                    name = name.Substring(0, name.IndexOf('.'));
                    fileName = name.ToString() + Path.GetExtension(postedFile.FileName);
                    filesNames[i] = fileName;
                    if (!File.Exists(filePath + fileName))
                        postedFile.SaveAs(filePath + fileName);
                }
            }
            return filesNames;
        }
    }
}
