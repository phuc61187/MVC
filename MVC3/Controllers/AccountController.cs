using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;
using System.Web.Security;

namespace MVC3.Controllers {
    public class AccountController : Controller {
        DBQLHSLinqSQLClassesDataContext context;
        public AccountController() {
            //context = new DBQLHSLinqSQLClassesDataContext();
        }
        // GET: Account
        public ActionResult Index() {
            var listAcc = from item in context.Accounts select item;

            return View(listAcc);
        }

        public ActionResult Create() {
            return View();
        }

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin model) {
            if (ModelState.IsValid) {
                using (context = new DBQLHSLinqSQLClassesDataContext()) {
                    var listAcc = context.Accounts.Where(item => item.UserName == model.UserName).ToList();
                    // kiểm tra login trường hợp 1.sai username, 2. đúng username, sai pass
                    if (listAcc == null || listAcc.Count() == 0) {
                        ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    } else if (listAcc.Count() == 1) {
                        var acc = listAcc.First();
                        if (acc.Password != model.Password) {
                            ModelState.AddModelError("", "Mật khẩu chưa đúng.");
                        } else {
                            var sessionUser = new UserLogin() { UserName = model.UserName };
                            Session.Add("UserSession", sessionUser);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            return View(model);
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}