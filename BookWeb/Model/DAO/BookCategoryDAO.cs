using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BookCategoryDAO
    {
        BookWebDataProvider db = null;
        
        public BookCategoryDAO()
        {
            db = new BookWebDataProvider();
        }

        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.status == true).ToList();
        }
    }
}
