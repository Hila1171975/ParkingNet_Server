using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PointEntities
    {
        public short Id { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public short ParkingId { get; set; }

        // DB> ENTITIES
        public static PointEntities ConvertToEntities(POINT p)
        {
            return new PointEntities()
            {
                Id = p.ID,
                x = p.X,
                y = p.Y,
                ParkingId = p.PARKING_ID
            };
        }

        // ENTITIES > DB 
        public static POINT ConvertToDB(PointEntities p)
        {
            return new POINT()
            {
                ID = p.Id,
                X = p.x,
                Y = p.y,
                PARKING_ID = p.ParkingId
            };
        }

        // DB_LIST> ENTITIES_LIST
        public static List<PointEntities> convertToEntitiesList(List<POINT> l)
        {
            List<PointEntities> lst = new List<PointEntities>();
            foreach (var item in l)
            {
                lst.Add(ConvertToEntities(item));
            }
            return lst;
        }


        // ENTITIES_LIST > DB_LIST
        public static List<POINT> convertToDBList(List<PointEntities> l)
        {
            List<POINT> lst = new List<POINT>();
            foreach (var item in l)
            {
                lst.Add(ConvertToDB(item));
            }
            return lst;
        }
    }
}
