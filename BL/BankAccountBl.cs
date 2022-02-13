using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace BL
{
    public class BankAccountBl
    {

        // שליפת רשימת חשבונות בנק
        public static List<BankAccountEntities> GetBankAccountList()
        {
            return BankAccountEntities.convertToEntitiesList(BankAccountDal.GetBankAccountList());
        }


        // שליפת חשבון בנק לפי קוד
        public static BankAccountEntities GetBankAccountById(int id)
        {
            return BankAccountEntities.ConvertToEntities(BankAccountDal.GetBankAccountList().FirstOrDefault(x => x.ID == id));
        }


        //הוספת חשבון בנק
        public static int addBankAccount(BankAccountEntities bank)
        {
            BankAccountDal.addBankAccount(BankAccountEntities.ConvertToDB(bank));
            var b = BankAccountDal.GetBankAccountList().FindAll(x => x.ACCOUNT_NUMBER == bank.AccountNumber && x.BANK == bank.Bank && x.BRANCH == bank.Branch).FirstOrDefault();
            return b.ID;
        }
      

        // מחיקת חשבון בנק
        public static void deleteBankAccount(int id)
        {
            BankAccountDal.deleteBankAccount(id);
        }
      

        // עדכון חשבון בנק
        public static void updateBankAccount(BankAccountEntities b)
        {
            BankAccountDal.updateBankAccount(BankAccountEntities.ConvertToDB(b));
        }

        // שליפת חשבון בנק לפי קוד משתמש
        public static BankAccountEntities GetBankAccountByUserId(int UserId)
        {
            return BankAccountEntities.ConvertToEntities(BankAccountDal.GetBankAccountList().FirstOrDefault(x => x.USER_ID == UserId));
        }

    }
}
