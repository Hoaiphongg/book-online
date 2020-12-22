using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class CategoryDAO
    {
        BookWebDataProvider db = null;

        public CategoryDAO()
        {
            db = new BookWebDataProvider();
        }

        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.status == true).OrderBy(x => x.id).ToList();
        }

        public List<Category> Category_new(int top)
        {
            return db.Categories.OrderByDescending(x => x.id).Take(top).ToList();
        }

        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id);
        }
    }
}
