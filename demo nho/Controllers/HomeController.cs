using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo_nho.Models;

namespace demo_nho.Controllers {
    public class Categories {
        public List<Category> CatModel { get; set; }
    }
    public class HomeController : Controller {
        private NWLinqToSQLDataContext con;
        public HomeController() {
            //con = new NWLinqToSQLDataContext();
        }

        public ActionResult Index() {
            IEnumerable<Category> listCat;
            //NWLinqToSQLDataContext con = new NWLinqToSQLDataContext();
            listCat = new List<Category>() {
                new Category() { CategoryID=1, CategoryName="name", Description="des", Picture=null }
            };
            con = new NWLinqToSQLDataContext();
            listCat = from item in con.Categories select item;
            List<Category> list2 = new List<Category>();
            var records = from item in con.Categories select item;
            foreach (var item in records) {
                list2.Add(new Category() { CategoryID = item.CategoryID, CategoryName = item.CategoryName, Description = item.Description, Picture = item.Picture });
            }
            Categories cat2 = new Categories();
            cat2.CatModel = list2;

            return View(cat2);
        }

        public ActionResult show() {
            con = new NWLinqToSQLDataContext();
            var list = from i in con.Categories select i;
            return View(list);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult ViewPhanLoai() {
        //    return View();
        //}

        public ActionResult ViewPhanLoai() {
            con = new NWLinqToSQLDataContext();
            List<Category> list = (from i in con.Categories select i).ToList();
            
            return View(list);
        }

    }
}