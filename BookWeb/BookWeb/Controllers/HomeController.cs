using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Book = new BookDAO();
            ViewBag.SlideBook = Book.ListSlide(8);
            ViewBag.NewBook = Book.ListNewBook(8);
            ViewBag.SlideBookBottom = Book.BookSlideBottom(3);
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var dao = new MenuDAO().ListAll(1);
            return PartialView(dao);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var dao = new MenuDAO().ListAll(2);
            return PartialView(dao);
        }

    }
}