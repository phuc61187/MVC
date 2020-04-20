using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;
using System.IO;

namespace MVC3.Controllers
{
    public class KhachHangController : Controller
    {
        public DBQLHSLinqSQLClassesDataContext con = new DBQLHSLinqSQLClassesDataContext();
        // GET: KhachHang
        public ActionResult Index()
        {
            var model = (from i in con.KhachHangs select i);
            return View(model);
        }
        public ActionResult ThemMoi() {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(KhachHang model) {
            con.KhachHangs.InsertOnSubmit(model);
            con.SubmitChanges();
            return RedirectToAction("Index", "KhachHang");
            //return View();
        }

        public ActionResult NapDSKHTuExcel() {
            return View();
        }

        [HttpPost]
        public ActionResult NapDSKHTuExcel(HttpPostedFileBase file) {
            try {
                if (file.ContentLength > 0) {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles/Client/"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "Tải file thành công";
                //RedirectToAction()
                return View();
            } catch {
                ViewBag.Message = "Không thể tải file, vui lòng thử lại.";
                return View();
            }
        }

        public ActionResult DownloadFile(string filePath) {
            string fullName = Server.MapPath("~" + filePath);

            byte[] fileBytes = GetFile(fullName);
            return File(
                fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filePath);
        }

        private byte[] GetFile(string fullName) {
            FileStream fs = System.IO.File.OpenRead(fullName);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new IOException(fullName);
            return data;
        }
    }
}