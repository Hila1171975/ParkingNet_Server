using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class BankAccountDal 
    {
        static PARKING_NETEntities db = new PARKING_NETEntities();

        // שליפת רשימת חשבונות בנק
        public static List<BANK_ACCOUNT> GetBankAccountList()
        {
            return db.BANK_ACCOUNT.ToList();
        }

        // הוספת חשבון בנק
        public static void addBankAccount(BANK_ACCOUNT b)
        {
            db.BANK_ACCOUNT.Add(b);
            db.SaveChanges();
        }

        // מחיקת חשבון בנק
        public static void deleteBankAccount(int id)
        {
            var b = db.BANK_ACCOUNT.FirstOrDefault(x => x.ID == id);
            db.BANK_ACCOUNT.Remove(b);
            db.SaveChanges();
        }

        // עדכון חשבון בנק
        public static void updateBankAccount(BANK_ACCOUNT b)
        {
            var up = db.BANK_ACCOUNT.FirstOrDefault(x => x.ID == b.ID);
            up.USER_ID = b.USER_ID;
            up.OWNER_NAME = b.OWNER_NAME;
            up.BANK = b.BANK;
            up.BRANCH = b.BRANCH;
            up.ACCOUNT_NUMBER = b.ACCOUNT_NUMBER;

            db.SaveChanges();
        }




    }
}
