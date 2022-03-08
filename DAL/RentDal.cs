using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RentDal
    {
        static PARKING_NETEntities db = new PARKING_NETEntities();

        // שליפת השכרות
        public static List<RENT> GetRentList()
        {
            return db.RENT.ToList();
        }

        // הוספת השכרה
        public static void addRent(RENT r)
        {
            db.RENT.Add(r);
            db.SaveChanges();
        }

        // מחיקת השכרה
        public static void deleteRent(int id)
        {
            var r = db.RENT.FirstOrDefault(x => x.ID == id);
            db.RENT.Remove(r);
            db.SaveChanges();
        }

        // עדכון פרטי השכרה
        public static void updateRent(RENT r)
        {
            var up = db.RENT.FirstOrDefault(x => x.ID == r.ID);
            up.USER_ID = r.USER_ID;
            up.PARKING_ID = r.PARKING_ID;
            up.ENTERY_HOUR = r.ENTERY_HOUR;
            up.LEAVING_HOUR = r.LEAVING_HOUR;
            up.ENTERY_DATE = r.ENTERY_DATE;
            up.LEAVING_DATE = r.LEAVING_DATE;

            db.SaveChanges();
        }
    }
}
