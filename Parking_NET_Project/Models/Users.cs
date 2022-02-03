using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking_NET_Project.Models
{
    public class Users
    {
        public int ID { get; set; }             // קוד משתמש
        public string name { get; set; }        // שם מלא
        public string password { get; set; }    // סיסמא
        public string phone { get; set; }       // טלפון  
    }
}