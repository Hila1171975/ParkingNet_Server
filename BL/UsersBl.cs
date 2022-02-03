using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BL
{
    public class UsersBl
    {
        // שליפת משתמש לפי קוד
        public static UsersEntities GetUserById(int id)
        {
            return UsersEntities.ConvertToEntities(UsersDal.GetUsersList().FirstOrDefault(x => x.ID == id));
        }


        // הוספת משתמש
        public static int addUser(UsersEntities user)
        {
            UsersDal.addUser(UsersEntities.ConvertToDB(user));
            var u = UsersDal.GetUsersList().FindAll(x => x.PHONE == user.Phone && x.PASSWORD == user.Password).FirstOrDefault();
            return u.ID;
        }

        // עדכון משתמש ברשימה
        public static void updateUser(UsersEntities user)
        {
            UsersDal.updateUser(UsersEntities.ConvertToDB(user));
        }


        // האם לקוח קיים
        public static int isExist(string name, string password)
        {
            //var y = ClientDal.GetClientList().FindAll(x => x.NAME == name && x.PASSWORD == password).FirstOrDefault();
            //if(y!=null)
            //    return y.ID;
            //return -1;

            var y = UsersDal.GetUsersList().FirstOrDefault(x => x.NAME == name && x.PASSWORD == password);
            if (y != null)
                return y.ID;
            return -1;
        }
    }
}
