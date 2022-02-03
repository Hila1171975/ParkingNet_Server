using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Entities
{
    public class CityEntities
    {
        public short Id { get; set; }
        public string Name { get; set; }


        // DB> ENTITIES
        public static CityEntities ConvertToEntities(CITY c)
        {
            return new CityEntities()
            {
                Id = c.ID,
                Name = c.NAME
            };
        }

        // ENTITIES > DB 
        public static CITY ConvertToDB(CityEntities c)
        {
            return new CITY()
            {
                ID = c.Id,
                NAME = c.Name
            };
        }

        // DB_LIST> ENTITIES_LIST
        public static List<CityEntities> convertToEntitiesList(List<CITY> l)
        {
            List<CityEntities> lst = new List<CityEntities>();
            foreach (var item in l)
            {
                lst.Add(ConvertToEntities(item));
            }
            return lst;
        }


        // ENTITIES_LIST > DB_LIST
        public static List<CITY> convertToDBList(List<CityEntities> l)
        {
            List<CITY> lst = new List<CITY>();
            foreach (var item in l)
            {
                lst.Add(ConvertToDB(item));
            }
            return lst;
        }
    }
}
