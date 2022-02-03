using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking_NET_Project.Models
{
    public class BankAccount
    {
        public int MyProperty { get; set; }

        public int id { get; set; }                  // קוד חשבון בנק
        public int userID { get; set; }              // קוד בעל חשבון/ קוד משתמש
        public string ownerName { get; set; }        // שם בעל החשבון
        public string bank { get; set; }             // בנק
        public string branch { get; set; }           // סניף
        public string accountNumber { get; set; }    // מספר חשבון
    }
}