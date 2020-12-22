using BookWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using BookWeb.Common;


namespace BookWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginAdmin admin)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                var result = dao.Login(admin.Username, Encryptor.MD5Hash(admin.Password), admin.GroupID);
                if (result == 1)
                {
                    var account = dao.GetByID(admin.Username);
                    var accountSession = new LoginAccount();
                    accountSession.Username = account.username;
                    accountSession.IdAccount = account.id;
                    Session.Add(SessionConstant.USER_SESSION, accountSession);

                    return RedirectToAction("Index", "Home"); 
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tai khoan nay khong ton tai!!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tai khoan nay dang bi khoa!!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mat khau!!");
                }
                else
                {
                    ModelState.AddModelError("", "Dang nhap khong dung!!");
                }
            }
            return View("Index");
        }
    }
}