using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BillDAO
    {
        BookWebDataProvider db = null;

        public BillDAO()
        {
            db = new BookWebDataProvider();
        }

        public int Insert(Bill bill)
        {
            db.Bills.Add(bill);
            db.SaveChanges();
            return bill.id;
        }
    }
}
