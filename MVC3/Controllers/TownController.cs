using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class TownController : Controller
    {
        //private WiseEyeDataContext db;
        //public TownController() { db = new WiseEyeDataContext(); }
        //// GET: Town
        //public ActionResult Index()
        //{
        //    IList<TownModel> list = new List<TownModel>();
        //    var query = from item in db.Towns select item;
        //    var kq = query.ToList();
        //    foreach (var item in kq) {
        //        list.Add(new TownModel { ID = item.ID, Area = item.Area, Population = item.Pupulation, TownName = item.TownName, TownShip = item.TownShip });
        //    }
        //    return View(list);
        //}
    }
}