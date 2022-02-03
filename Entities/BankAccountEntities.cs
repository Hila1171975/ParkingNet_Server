using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Entities
{
    public class BankAccountEntities
    {
        public short Id { get; set; }
        public short UserId { get; set; }
        public string OwnerName { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string AccountNumber { get; set; }




        // DB> ENTITIES
        public static BankAccountEntities ConvertToEntities(BANK_ACCOUNT b)
        {
            return new BankAccountEntities()
            {
                Id = b.ID,
                UserId=b.USER_ID,
                OwnerName=b.OWNER_NAME,
                Bank=b.BANK,
                Branch=b.BRANCH,
                AccountNumber=b.ACCOUNT_NUMBER
            };
        }


        // ENTITIES > DB 
        public static BANK_ACCOUNT ConvertToDB(BankAccountEntities b)
        {
            return new BANK_ACCOUNT()
            {
                ID=b.Id,
                USER_ID=b.UserId,
                OWNER_NAME=b.OwnerName,
                BANK=b.Bank,
                BRANCH=b.Branch,
                ACCOUNT_NUMBER=b.AccountNumber
            };
        }


        // DB_LIST> ENTITIES_LIST
        public static List<BankAccountEntities> convertToEntitiesList(List<BANK_ACCOUNT> l)
        {
            List<BankAccountEntities> lst = new List<BankAccountEntities>();
            foreach (var item in l)
            {
                lst.Add(ConvertToEntities(item));
            }
            return lst;
        }

        // ENTITIES_LIST > DB_LIST
        public static List<BANK_ACCOUNT> convertToDBList(List<BankAccountEntities> l)
        {
            List<BANK_ACCOUNT> lst = new List<BANK_ACCOUNT>();
            foreach (var item in l)
            {
                lst.Add(ConvertToDB(item));
            }
            return lst;
        }

    }
}
