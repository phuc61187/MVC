using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class AccountController : Controller
    {
        DBQLHSLinqSQLClassesDataContext context;
        public AccountController() {
            context = new DBQLHSLinqSQLClassesDataContext();
        }
        // GET: Account
        public ActionResult Index()
        {
            var listAcc = from item in context.Accounts select item;
            
            return View(listAcc);
        }

        public ActionResult Create() {
            return View();
        }
    }
}