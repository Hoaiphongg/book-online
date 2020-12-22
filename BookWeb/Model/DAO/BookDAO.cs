using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.ViewModel;

namespace Model.DAO
{
    public class BookDAO
    {
        BookWebDataProvider db = null;

        public BookDAO()
        {
            db = new BookWebDataProvider();
        }

        public List<Book> ListNewBook(int top)
        {
            return db.Books.OrderByDescending(x => x.id).Take(top).ToList();
        }

        public List<Book> ListSlide(int top)
        {
            return db.Books.OrderByDescending(x => x.id).Take(top).ToList();
        }

        public List<Book> BookSlideBottom( int top)
        {
            return db.Books.OrderByDescending(x => x.id).Take(top).ToList();
        }
        public Book ViewDetail(int id)
        {
            return db.Books.Find(id);
        }
        public List<Book> ListBookDetail(int categoryId)
        {
            var book = db.Books.Find(categoryId);
            return db.Books.Where(x => x.idCategory == book.idCategory).ToList();
        }

        public List<BookViewModel> ListByCategoryId(int categoryID/*, ref int totalRecord*/)
        {
/*            totalRecord = db.Books.Where(x => x.idCategory == categoryID).Count();*/
            var model = (from a in db.Books
                         join b in db.Categories
                         on a.idCategory equals b.id
                         where a.idCategory == categoryID
                         select new
                         {
                             catemetatitle = b.metatitle,
                             catename = b.name,
                             id = a.id,
                             image = a.image,
                             name = a.name,
                             metatitle = a.metatitle,
                             price = a.price
                         }).AsEnumerable().Select(x => new BookViewModel()
                         {
                             catemetatitle = x.catemetatitle,
                             catename = x.catename,
                             id = x.id,
                             image = x.image,
                             name = x.name,
                             metatitle = x.metatitle,
                             price = x.price
                         });
            model.OrderByDescending(x => x.id);
            return model.ToList();
        }
    }
}
