using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BL
{
    public class CityBl
    {

        // שליפת רשימת ערים
        public static List<CityEntities> GetCityList()
        {
            return CityEntities.convertToEntitiesList(CityDal.GetCityList());
        }

        // שליפת עיר לפי קוד
        public static CityEntities GetCityById(int id)
        {
            return CityEntities.ConvertToEntities(CityDal.GetCityList().FirstOrDefault(x=> x.ID==id));
        }

        // הוספת עיר
        public static void addCity(CityEntities c)
        {
            CityDal.addCity(CityEntities.ConvertToDB(c));
        }

        // מחיקת עיר
        // ???


        // עדכון עיר
        // ???
    }
}
