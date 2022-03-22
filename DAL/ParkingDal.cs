using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ParkingDal
    {
         static PARKING_NETEntities db = new PARKING_NETEntities();

        // שליפת רשימת חניות
        public static List<PARKING> GetParkingList()
        {
           return db.PARKING.ToList();
        }

        //הוספת חניה
         public static void addParking(PARKING p)
        {
            try
                {
                db.PARKING.Add(p);
                db.SaveChanges();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
        }

        // מחיקת חניה
        public static void deleteParking(int id)
        {
            var p = db.PARKING.FirstOrDefault(x => x.ID == id);
            db.PARKING.Remove(p);
            db.SaveChanges();
        }

        // עדכון חניה
         public static void updateParking(PARKING p)
        {
            var up = db.PARKING.FirstOrDefault(x => x.ID == p.ID);
            up.USER_ID = p.USER_ID;
            up.ADRESS = p.ADRESS;
            up.LAT = p.LAT;
            up.LAN = p.LAN;
            up.PAY_PER_HOUR = p.PAY_PER_HOUR;
            up.ELECTRONIC_GATE = p.ELECTRONIC_GATE;
            up.INDOOR = p.INDOOR;
            up.SHADY = p.SHADY;
            up.SIZE_FOR = p.SIZE_FOR;
            up.CANCEL_TIME = p.CANCEL_TIME;
            up.NOTES = p.NOTES;
            up.IMG1 = p.IMG1;
            up.IMG2 = p.IMG2;
            up.IMG3 = p.IMG3;
            up.ACCOUNT_ID = p.ACCOUNT_ID;

            db.SaveChanges();
        }












    }
}
