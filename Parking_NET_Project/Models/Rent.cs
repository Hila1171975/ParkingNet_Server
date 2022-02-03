using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking_NET_Project.Models
{
    public class Rent
    {


        public int ID { get; set; }              // קוד השכרה
        public int userID { get; set; }        // קוד בעל החניה
        public int parkingID { get; set; }        // קוד בעל החניה
        public DateTime entryHour { get; set; }        // שעת כניסה
        public DateTime leavingHour { get; set; }        // שעת יציאה
        public DateTime entryDate { get; set; }        // תאריך כניסה
        public DateTime leavingDate { get; set; }       // תאריך יציאה
    }
}