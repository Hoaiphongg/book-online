using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWeb.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ListNewBook()
        {
            var model = new BookDAO().ListNewBook(5);
            return PartialView(model);
        }

        public ActionResult Category(int cateid)
        {
            var category = new CategoryDAO().ViewDetail(cateid);
            ViewBag.Category = category;

/*            int totalRecord = 0;*/
            var model = new BookDAO().ListByCategoryId(cateid /*ref totalRecord, /*page, pageSize*/);

/*            ViewBag.Total = totalRecord;
*//*            ViewBag.Page = page;*//*

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

*/
            return View(model);
        }

        public ActionResult BookCategory()
        {
            var model = new BookCategoryDAO().ListAll().ToList();
            return PartialView(model);
        }

        public ActionResult BookSlideBottom()
        {
            var model = new BookDAO().BookSlideBottom(3).ToList();
            return PartialView(model);
        }

        public ActionResult Detail(int id)
        {
            var model = new BookDAO().ViewDetail(id);
            ViewBag.Category = new CategoryDAO().ViewDetail(model.idCategory);
            ViewBag.ListBookInCatogery = new BookDAO().ListBookDetail(id);
            return View(model);
        }

        public ActionResult AllBook()
        {
            var model = new BookDAO().AllList();
            return View(model);
        }
    }
}