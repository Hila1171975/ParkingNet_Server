using DAL;
using Entities;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class FindParkingBl
    {
        List<PointEntities> pointList = new List<PointEntities>(); // רשימה שתכיל נקודות אורך ורוחב לכל חניה
        List<ParkingEntities> parkingList = new List<ParkingEntities>(); // רשימה של החניות
        List<ParkingEntities> freeParkingList = new List<ParkingEntities>(); // רשימה של החניות הפנויות
        List<RentEntities> Rental_list; //רשימת השכרות

        List<double> distanceList = new List<double>(); //רשימה של כל המרחקים בין המיקום הנוכחי לבין רשימת החניות הפנויות

        //מחזירה רשימה של שלוש חניות קרובות
        public static int start(double home_lat, double home_lan, RentEntities r)
        {
            parkingList = ParkingBl.GetParkingList();//שליפת כל החניות

            //סינון רק חנויות פנויות
            for (int i = 0; i < parkingList.Count; i++) //מעבר על כל רשימת החניות
            {
                //עבור כל חניה
                // נשלח אותה לפונקציה הבודקת האם החניה פנויה ומוסיפה את החניה לרשימת החניות הפנויות- במקרה שהיא פנויה
                freeParking(parkingList[i].Id, entryDate, leavingDate, entryHour, leavingHour);
            }

            //איתחול רשימת הנקודות בכתובות של החניות הפניות
            for (int i = 0; i < freeParkingList.Count; i++)
            {
                PointEntities p = new PointEntities();
                //p.x = freeParking[i].
                pointList.Add(new PointEntities());
            }

            //  pointList =//שליפה של כל הנקודת+
            for (int i = 0; i < freeParkingList.Count; i++)
            {
                distanceList.Add(GetDuration(home_lat, home_lan, pointList[i].x, pointList[i].y));
            }

            var shortDistanceList = distanceList.OrderBy(x => x).Take(3); // שליפת שלושת החניות הקרובות ביותר

            //var b = BankAccountDal.GetBankAccountList().FindAll(x => x.ACCOUNT_NUMBER == bank.AccountNumber && x.BANK == bank.Bank && x.BRANCH == bank.Branch).FirstOrDefault();
            return 0;

        }
        //פונקציה המקבלת קוד חנייה ובודקת האם החניה פנויה להשכרה בשעה והתאריך הרצויים
        //במקרה שהחניה פנויה הפונקציה מוסיפה את החניה לרשימת החניות הפנויות
        public void freeParking(int idParking, DateTime entryDate, DateTime leavingDate, DateTime entryHour, DateTime leavingHour)
        {
            bool flag = true; //בתחילה נגדיר שהחנייה פנויה
            Rental_list = RentBl.GetRentList();  //נכניס לרשימת ההשכרות את כל ההשכרות הקיימות
            for (int i = 0; i < Rental_list.Count; i++)  //נעבור על רשימת ההשכרות ונבדוק
            {
                //דבר ראשון: האם הקוד של החנייה בהשכרה הנוכחית שווה לקוד החנייה הרצויה
                if (idParking == Rental_list[i].ParkingId)
                {
                    //נבצע בדיקה האם החניה רצויה בתאריך/ים של ההשכרה הנוכחית
                    if ((Rental_list[i].EntryDate.Date >= entryDate.Date && Rental_list[i].LeavingDate.Date <= leavingDate.Date)
                        || (Rental_list[i].EntryDate.Date < entryDate.Date && Rental_list[i].LeavingDate.Date > entryDate.Date)
                        || (Rental_list[i].EntryDate.Date < leavingDate.Date && Rental_list[i].LeavingDate.Date > entryDate.Date))
                    {
                        //נבצע בדיקה האם החניה רצויה בשעה/ות של ההשכרה הנוכחית
                        if ((Rental_list[i].EntryHour.TimeOfDay >= entryHour.TimeOfDay && Rental_list[i].LeavingHour.TimeOfDay <= leavingHour.TimeOfDay)
                            || (Rental_list[i].EntryHour.TimeOfDay < entryHour.TimeOfDay && Rental_list[i].LeavingHour.TimeOfDay > entryHour.TimeOfDay)
                            || (Rental_list[i].EntryHour.TimeOfDay < leavingHour.TimeOfDay && Rental_list[i].LeavingHour.TimeOfDay > entryHour.TimeOfDay))
                        {
                            //במקרה שנמצאה השכרה בשעה ובתאריך הרצויים נעדכן את החניה הרצויה כתפוסה
                            flag = false;
                        }
                    }
                }
            }
            //במקרה והחניה הרצויה נשארה כפנויה נוסיף את החניה לרשימת החניות הפנויות בתאריך והשעה הרצויים
            if (flag == true)
                freeParkingList.Add(ParkingBl.GetParkingById(idParking));
        }




        //מקבלת 2 כתובות: כתובת יעד וכתובת מקור ומחזירה מרחק לפי זמן נסיעה
        public double GetDuration(double lat_1, double lng_1, double lat_2, double lng_2)
        {
            DirectionsRequest request = new DirectionsRequest();
            request.Key = "AIzaSyALloXnE20WhqF0szj5Ak2C6074nQQk9uE";//key of google maps
            request.Origin = new Location(lat_1, lng_1);
            request.Destination = new Location(lat_2, lng_2);
            var response = GoogleApi.GoogleMaps.Directions.Query(request);
            double duration;
            if (response.Routes.Count() > 0)
            {
                duration = response.Routes.First().Legs.First().Duration.Value;
                //מחזיר מס' דקות
                return duration / 60;
            }
            return 0;
        }

    }
}
