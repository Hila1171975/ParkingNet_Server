using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CityDal
    {
        static PARKING_NETEntities db = new PARKING_NETEntities();


        // שליפת רשימת ערים
        public static List<CITY> GetCityList()
        {
           return db.CITY.ToList();
        }


        // הוספת עיר
        public static void addCity(CITY c)
        {
            db.CITY.Add(c);
            db.SaveChanges();
        }

        
        // מחיקת עיר
        // ???


        // עדכון עיר
        // ???


    }
}
