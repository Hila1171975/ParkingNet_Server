using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BL
{
    public class RentBl
    {
        // שליפת השכרות
        public static List<RentEntities> GetRentList()
        {
            return RentEntities.convertToEntitiesList(RentDal.GetRentList());
        }

        // שליפת השכרה לפי קוד
        public static RentEntities GetRentById(int id)
        {
            return RentEntities.ConvertToEntities(RentDal.GetRentList().FirstOrDefault(x => x.ID == id));
        }

        // הוספת השכרה
        public static void addRent(RentEntities r)
        {
            RentDal.addRent(RentEntities.ConvertToDB(r));
        }

        // מחיקת השכרה
        public static void deleteRent(int id)
        {
            RentDal.deleteRent(id);
        }

        // עדכון השכרה
        public static void updateRent(RentEntities r)
        {
            RentDal.updateRent(RentEntities.ConvertToDB(r));
        }
    }
}
