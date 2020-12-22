using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class MenuDAO
    {
        BookWebDataProvider db = null;

        public MenuDAO()
        {
            db = new BookWebDataProvider();
        }

        public List<Menu> ListAll(int typeid)
        {
            return db.Menus.Where(x => x.typeid == typeid && x.status == true).OrderBy(x => x.displayorder).ToList();
        }

    }
}
