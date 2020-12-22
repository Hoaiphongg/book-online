using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWeb.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult SlideCate()
        {
            var model = new BookDAO().ListNewBook(6);
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult Navitation_Left()
        {
            var model = new CategoryDAO().ListAll();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult Category_new()
        {
            var model = new CategoryDAO().Category_new(5);
            return PartialView(model);
        }
    }
}