using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BL 
{
    public class ParkingBl
    {
        // שליפת רשימת חניות
        public static List<ParkingEntities> GetParkingList()  
        {
            return ParkingEntities.convertToEntitiesList(ParkingDal.GetParkingList());
        }

        // שליפת חניה לפי קוד
        public static ParkingEntities GetParkingById(int id)
        {
            return ParkingEntities.ConvertToEntities(ParkingDal.GetParkingList().FirstOrDefault(x => x.ID == id));
        }

        //הוספת חניה
        public static void addParking(ParkingEntities p)
        {
            ParkingDal.addParking(ParkingEntities.ConvertToDB(p));
        }

        // מחיקת חניה
        public static void deleteParking(int id)
        {
            ParkingDal.deleteParking(id);
        }

        // עדכון חניה
        public static void updateParking(ParkingEntities p)
        {
            ParkingDal.updateParking(ParkingEntities.ConvertToDB(p));
        }

        // שליפת רשימת חניות לפי קוד משתמש
        public static List<ParkingEntities> GetParkingListByUserId(int userId)
        {
            return ParkingEntities.convertToEntitiesList(ParkingDal.GetParkingList().Where(x => x.USER_ID == userId).ToList());
        }
    }
}
