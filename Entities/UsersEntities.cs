using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Entities
{
    public class UsersEntities
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }




        // DB> ENTITIES
        public static UsersEntities ConvertToEntities(USERS u)
        {
            return new UsersEntities()
            {
                Id = u.ID,
                Name = u.NAME,
                Password = u.PASSWORD,
                Phone = u.PHONE
            };
        }

        // ENTITIES > DB 
        public static USERS ConvertToDB(UsersEntities u)
        {
            return new USERS()
            {
                ID = u.Id,
                NAME = u.Name,
                PASSWORD = u.Password,
                PHONE = u.Phone
            };
        }


        // DB_LIST> ENTITIES_LIST
        public static List<UsersEntities> convertToEntitiesList(List<USERS> l)
        {
            List<UsersEntities> lst = new List<UsersEntities>();
            foreach (var item in l)
            {
                lst.Add(ConvertToEntities(item));
            }
            return lst;
        } 


        // ENTITIES_LIST > DB_LIST
        public static List<USERS> convertToDBList(List<UsersEntities> l)
        {
            List<USERS> lst = new List<USERS>();
            foreach (var item in l)
            {
                lst.Add(ConvertToDB(item));
            }
            return lst;
        }


    }
}

