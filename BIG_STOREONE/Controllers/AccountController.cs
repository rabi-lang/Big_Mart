using BIG_STOREONE.Models;
using BIG_STOREONE.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace BIG_STOREONE.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        eveningDBEntities _db = new eveningDBEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(LoginViewModel l, string ReturnUrl = "")
        {
            using (eveningDBEntities db = new eveningDBEntities())
            {
                var users = db.tbluserones.Where(a => a.UserName == l.Username && a.Password == l.Password).FirstOrDefault();
                if (users != null)
                {
                    Session.Add("username", users.UserName);
                    FormsAuthentication.SetAuthCookie(l.Username, l.RememberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User");
                }
            }
            return View();

        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult ChangePassword()
        {



            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel ch)
        {
            string username = Session["username"].ToString();

            tbluserone us = _db.tbluserones.Where(u => u.UserName == username && u.Password == ch.OldPassword).FirstOrDefault();
            if (us != null)
            {
                us.Password = ch.NewPassword;
                _db.SaveChanges();

            }
            else
            {
                return Json(new { success = false, message = "You Enter Wrong Password" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, message = "Password Changed Successfully" }, JsonRequestBehavior.AllowGet);
        }
    }
}