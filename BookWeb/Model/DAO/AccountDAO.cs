using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AccountDAO
    {
        BookWebDataProvider db = null;

        public AccountDAO()
        {
            db = new BookWebDataProvider();
        }

        public int Insert(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();

            return account.id;
        }

        public Account GetByID(string Username)
        {
            return db.Accounts.SingleOrDefault(x => x.username == Username);
        }

        public int Login(string user, string pass, string groupid)
        {
            var result = db.Accounts.SingleOrDefault(x => x.username == user);
            if (result == null || result.groupid != "Admin")
            {
                return 0;
            }
            else
            {
                if (result.status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.password == pass)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }

        }
    }
}
