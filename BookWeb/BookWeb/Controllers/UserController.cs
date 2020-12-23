using BookWeb.Models;
using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWeb.Common;


namespace BookWeb.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Logout()
        {
            Session[SessionConstant.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                var result = dao.LoginUser(model.UserName, Encryptor.MD5Hash(model.Password), model.Roll);
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new LoginAccount();
                    userSession.Username = user.username;
                    userSession.IdAccount = user.id;
                    Session.Add(SessionConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                if (dao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    string Member = "Member";
                    Member = model.GroupId;
                    bool status = true;
                    status = model.Status;
                    string password = Encryptor.MD5Hash(model.Password);
                    model.Password = password;

                    var user = new Account();
                    user.name = model.Name;
                    user.password = password;
                    user.groupid = Member;
                    user.gender = model.Gender;
                    user.birthday = model.Birthday;
                    user.phone = model.Phone;
                    user.email = model.Email;
                    user.address = model.Address;
                    user.status = status;

                    var result = dao.InsertUser(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký thành công";
                        model = new RegisterModel();
               
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công.");
                    }
                }
            }
            return View(model);
        }
    }
}