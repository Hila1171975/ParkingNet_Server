using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking_NET_Project.Models
{
    public class Parking
    {
        public int ID { get; set; }                // קוד חניה
        public int userID { get; set; }            // קוד בעל החניה
        public int cityID { get; set; }            // קוד עיר
        public string street { get; set; }         // רחוב
        public int houseNum { get; set; }          // מספר בית
        public int payPerHour { get; set; }        // תשלום לשעה
        public bool electronicGate { get; set; }   // שער אלקטרוני
        public bool indoor { get; set; }           // שער אלקטרוני
        public bool Shady { get; set; }            // מוצל/ לא מוצל
        public string sizeFor { get; set; }        // מתאים ל
        public int cancelTime { get; set; }        // זמן ביטול מראש
        public string notes { get; set; }          // הערות
        public string IMG1 { get; set; }           // תמונה 1
        public string IMG2 { get; set; }           // תמונה 2
        public string IMG3 { get; set; }           // תמונה 3
        public int accountID { get; set; }         // קוד חשבון
    }
}