using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Database.DAO;
using OnlineShop.Database.EF;
using System.IO;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        public ActionResult Index(long searchStr, int page = 1, int pageSize = 8)
        {
            var ls = new DonHangDao().GetByStr(searchStr, page, pageSize);
            ViewBag.searchStr = searchStr;
            return View(ls);
        }

        // GET: Admin/DonDatHang/Details/5
        public ActionResult Details(int id)
        {
            return View(new DonHangDao().ViewDetail(id));
        }


        // GET: Admin/DonDatHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new DonHangDao().ViewDetail(id));
        }

        // POST: Admin/DonDatHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (new DonHangDao().Delete(id))
                return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(new DonHangDao().ViewDetail(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(donhang ddh)
        {
            if (new DonHangDao().Update(ddh))
                return RedirectToAction("Index");
            return View();

        }
    }
}