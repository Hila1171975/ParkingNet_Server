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

    [RoutePrefix("api/BankAccount")]
    public class BankAccountController : ApiController
    {
        // שליפת רשימת חשבונות בנק
        //  !!!!!


        // שליפת חשבון בנק לפי קוד
        [HttpGet]
        [Route("GetBankAccountById/{id}")]
        public IHttpActionResult GetBankAccountById(int id)
        {
            return Ok(BankAccountBl.GetBankAccountById(id));
        }


        // הוספת חשבון בנק
        [HttpPut]
        [Route("addBankAccount")]
        public IHttpActionResult addBankAccount([FromBody] BankAccountEntities b)
        {
            try
            {
                BankAccountBl.addBankAccount(b);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }

      

        // מחיקת חשבון בנק
        [HttpDelete]
        [Route("deleteBankAccount")]
        public IHttpActionResult deleteBankAccount(int id)
        {
            try
            {
                BankAccountBl.deleteBankAccount(id);
                return Ok(true);
            }
            catch
            {
                return Ok(false);

            }

        }

        // עדכון

        [HttpPost]
        [Route("updateBankAccount")]
        public IHttpActionResult updateBankAccount([FromBody] BankAccountEntities b)
        {
            try
            {
                BankAccountBl.updateBankAccount(b);
                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }




    }
}
