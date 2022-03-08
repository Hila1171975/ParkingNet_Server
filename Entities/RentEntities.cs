using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Entities
{
    public class RentEntities
    {

        public short Id { get; set; }
        public short UserId { get; set; }
        public short ParkingId { get; set; }
        public DateTime EntryHour { get; set; }
        public DateTime LeavingHour { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime LeavingDate { get; set; }



        // DB> ENTITIES
        public static RentEntities ConvertToEntities(RENT r)
        {
            return new RentEntities()
            {
                Id = r.ID,
                UserId = r.USER_ID,
                ParkingId=r.PARKING_ID,
                EntryHour=r.ENTRY_HOUR,
                LeavingHour=r.LEAVING_HOUR,
                EntryDate=r.ENTRY_DATE,
                LeavingDate=r.LEAVING_DATE
            };
        }


        // ENTITIES > DB 
        public static RENT ConvertToDB(RentEntities r)
        {
            return new RENT()
            {
                ID = r.Id,
                USER_ID = r.Id,
                PARKING_ID = r.ParkingId,
                ENTRY_HOUR = r.EntryHour,
                LEAVING_HOUR = r.LeavingHour,
                ENTRY_DATE=r.EntryDate,
                LEAVING_DATE=r.LeavingHour
            };
        }


        // DB_LIST> ENTITIES_LIST

        public static List<RentEntities> convertToEntitiesList(List<RENT> l)
        {
            List<RentEntities> lst = new List<RentEntities>();
            foreach (var item in l)
            {
                lst.Add(ConvertToEntities(item));
            }
            return lst;
        }

        // ENTITIES_LIST > DB_LIST

        public static List<RENT> convertToDBList(List<RentEntities> l)
        {
            List<RENT> lst = new List<RENT>();
            foreach (var item in l)
            {
                lst.Add(ConvertToDB(item));
            }
            return lst;
        }














    }
}
