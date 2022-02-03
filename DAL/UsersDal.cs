using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersDal
    {
        static PARKING_NETEntities db = new PARKING_NETEntities();

        // שליפת רשימת משתמשים
        public static List<USERS> GetUsersList()
        {
            return db.USERS.ToList();
        }

        // הוספת משתמש
        public static void addUser(USERS u)
        {
            db.USERS.Add(u);
            db.SaveChanges();
        }


        // מחיקת משתמש
        // ????



        // עדכון משתמש
        public static void updateUser(USERS u)
        {
            var up = db.USERS.FirstOrDefault(x => x.ID == u.ID);
            up.NAME = u.NAME;
            up.PASSWORD = u.PASSWORD;
            up.PHONE = u.PHONE;

            db.SaveChanges();
        }

    }
}
