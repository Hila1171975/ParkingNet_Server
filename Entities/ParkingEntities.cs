using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Entities
{
    public class ParkingEntities
    {
        //  שמות כמו באנגולר 
        public short Id { get; set; }
        public short UserId { get; set; }
        public string Adress { get; set; }
        public double Lat { get; set; }
        public double Lan { get; set; }
        public double PayPerHour { get; set; }
        public Nullable<bool> ElectronicGate { get; set; }
        public Nullable<bool> Indoor { get; set; }
        public Nullable<bool> Shady { get; set; }
        public string SizeFor { get; set; }
        public Nullable<short> CancelTime { get; set; }
        public string Notes { get; set; }
        public string IMG1 { get; set; }
        public string IMG2 { get; set; }
        public string IMG3 { get; set; }
        public Nullable<short> AccountId { get; set; }



        // DB> ENTITIES
        public static ParkingEntities ConvertToEntities(PARKING p)
        {
            return new ParkingEntities()
            {
                Id = p.ID,
                UserId = p.USER_ID,
                Adress = p.ADRESS,
                Lat = p.LAT,
                Lan = p.LAN,
                PayPerHour = p.PAY_PER_HOUR,
                ElectronicGate = p.ELECTRONIC_GATE,
                Indoor = p.INDOOR,
                Shady = p.SHADY,
                SizeFor = p.SIZE_FOR,
                CancelTime = p.CANCEL_TIME,
                Notes = p.NOTES,
                IMG1 = p.IMG1,
                IMG2 = p.IMG2,
                IMG3 = p.IMG3,
                AccountId = p.ACCOUNT_ID
            };
        }


        // ENTITIES > DB 

        public static PARKING ConvertToDB(ParkingEntities p)
        {
            return new PARKING()
            {
                ID = p.Id,
                USER_ID = p.UserId,
                ADRESS = p.Adress,
                LAT = p.Lat,
                LAN = p.Lan,
                PAY_PER_HOUR = p.PayPerHour,
                ELECTRONIC_GATE = p.ElectronicGate,
                INDOOR = p.Indoor,
                SHADY = p.Shady,
                SIZE_FOR = p.SizeFor,
                CANCEL_TIME = p.CancelTime,
                NOTES = p.Notes,
                IMG1 = p.IMG1,
                IMG2 = p.IMG2,
                IMG3 = p.IMG3,
                ACCOUNT_ID = p.AccountId
            };
        }

        // DB_LIST> ENTITIES_LIST

        public static List<ParkingEntities> convertToEntitiesList(List<PARKING> l)
        {
            List<ParkingEntities> lst = new List<ParkingEntities>();
            foreach (var item in l)
            {
                lst.Add(ConvertToEntities(item));
            }
            return lst;
        }


        // ENTITIES_LIST > DB_LIST

        public static List<PARKING> convertToDBList(List<ParkingEntities> l)
        {
            List<PARKING> lst = new List<PARKING>();
            foreach (var item in l)
            {
                lst.Add(ConvertToDB(item));
            }
            return lst;
        }
    }
}