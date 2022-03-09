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
        List<ParkingEntities> parkingList = new List<ParkingEntities>(); // רשימה של החניות
        List<ParkingEntities> freeParkingList = new List<ParkingEntities>(); // רשימה של החניות הפנויות
        List<RentEntities> Rental_list; //רשימת השכרות
        List<double> distanceList = new List<double>(); //רשימה של כל המרחקים בין המיקום הנוכחי לבין רשימת החניות הפנויות                                                  
        List<ParkingEntities> closestParkings = new List<ParkingEntities>(); //רשימה שתכיל את החניות הקרובות

        //מחזירה רשימה של שלוש חניות קרובות
        public List<ParkingEntities> start(double home_lat, double home_lan, RentEntities rent)
        {
            parkingList = ParkingBl.GetParkingList();//שליפת כל החניות

            //סינון רק חנויות פנויות
            for (int i = 0; i < parkingList.Count; i++) //מעבר על כל רשימת החניות
            {
                //עבור כל חניה
                // נשלח אותה לפונקציה הבודקת האם החניה פנויה ומוסיפה את החניה לרשימת החניות הפנויות- במקרה שהיא פנויה
                freeParking(parkingList[i].Id, rent.EntryDate, rent.LeavingDate, rent.EntryHour, rent.LeavingHour);
            }

            //אתחול רשימת המרחקים בין כתובת המקור לכתובת היעד עבור כל החניות הפנוית
            for (int i = 0; i < freeParkingList.Count; i++)
            {
                distanceList.Add(GetDuration(home_lat, home_lan, freeParkingList[i].Lat, freeParkingList[i].Lan));
            }

            //סינון רשימת החניות הפנויות ורשימת המרחקים כך שהם יכילו רק מרחקים שזמן הנסיעה שלהם קטן מ-5 
            for (int i = 0; i < distanceList.Count; i++)
            {
                if(distanceList[i] > 5)
                {
                    distanceList.Remove(distanceList[i]); 
                    freeParkingList.Remove(freeParkingList[i]);    
                }
            }

            //במקרה ורשימת החניות הפנויות לאחר הסינון קטן מ-3 נציג פחות חניות
            int numDidplay = 3; //ברירת המחדל תהיה הצגת 3 חניות
            //כל עוד רשימת החניות הפנויות קטנה ממספר החניות שנרצה להציג- נקטין את מספר החניות שנרצה להציג
            while (freeParkingList.Count < numDidplay) 
                numDidplay--;

            //במקרה ולא קיים חניות פנויות להצגה, נחזיר כבר מעכשיו רשימת חניות ריקה
            if (numDidplay == 0)
                return closestParkings;

            //רשימה שתכיל את האינדקסים של המרחקים הקטנים ביותר
            List<int> MinDistanceIndex=new List<int>();
            double minDistance; //משתנה שיכיל את המרחק המינימלי הנוכחי
            int indexOfMin; //משתנה שיכיל את האינדקס של המרחק המינימלי הנוכחי

            //חיפוש 3 חניות עם המרחק המינימלי ביותר
            for (int i = 0; i < numDidplay; i++)
            {
                minDistance = distanceList.Min(); //נכניס לתוך המשתנה את המרחק המינימלי ביותר
                indexOfMin = distanceList.IndexOf(minDistance); //נכניס לתוך המשתנה את האינדקס של המרחק המינימלי ביותר שמצאנו
                MinDistanceIndex.Add(indexOfMin); //נוסיף לרשימת האינדקסים של המרחקים המינימלים את האינדקס שמצאנו
                distanceList[indexOfMin] = int.MaxValue; //נשנה את המרחק המינימלי ברשימת המרחקים למספר מקסימלי, כדי שלא נוכל להציג אותו פעם נוספת בחיפוש הבא 
            }

            //שליפת החניות הקרובות מרשימת החניות
            foreach (var item in MinDistanceIndex)
            {
                closestParkings.Add(freeParkingList[item]);
            }
            return closestParkings;
        }

        //פונקציה המקבלת קוד חנייה ובודקת האם החניה פנויה להשכרה בשעה והתאריך הרצויים
        //במקרה שהחניה פנויה הפונקציה מוסיפה את החניה לרשימת החניות הפנויות
        public void freeParking(int idParking, DateTime entryDate, DateTime leavingDate, DateTime entryHour, DateTime leavingHour)
        {
            bool free = true; //בתחילה נגדיר שהחנייה פנויה
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
                            free = false;
                        }
                    }
                }
            }
            //במקרה והחניה הרצויה נשארה כפנויה נוסיף את החניה לרשימת החניות הפנויות בתאריך והשעה הרצויים
            if (free == true)
                freeParkingList.Add(ParkingBl.GetParkingById(idParking));
        }




        //מקבלת 2 כתובות: כתובת יעד וכתובת מקור ומחזירה מרחק לפי זמן נסיעה
        public double GetDuration(double lat_1, double lng_1, double lat_2, double lng_2)
        {
            DirectionsRequest request = new DirectionsRequest();
            request.Key = "AIzaSyALloXnE20WhqF0szj5Ak2C6074nQQk9uE";//key of google maps
            //request.Origin = new Location(lat_1, lng_1);
            //request.Destination = new Location(lat_2, lng_2);
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
