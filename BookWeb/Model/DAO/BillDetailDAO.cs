using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BillDetailDAO
    {

        BookWebDataProvider db = null;

        public BillDetailDAO()
        {
            db = new BookWebDataProvider();
        }

        public bool Insert(BillDetail detail)
        {
            try
            {
                db.BillDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
