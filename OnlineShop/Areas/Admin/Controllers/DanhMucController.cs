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
    public class DanhMucController : Controller
    {
        // GET: Admin/DanhMuc
        public ActionResult Index(int PageNum = 1, int PageSize = 5)
        {
            DanhMucDao dao = new DanhMucDao();
            return View(dao.ListSPPage(PageNum, PageSize));
        }
        #region Add
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string ten)
        {
            
            danhmuc dm = new danhmuc();
            dm.ten = ten;         
            DanhMucDao dao = new DanhMucDao();
            dao.Add(dm);
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        public ActionResult Edit(int ma)
        {   
            DanhMucDao spdao = new DanhMucDao();          
            ViewBag.dm = spdao.getById(ma);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int ma, string ten)
        {      
            DanhMucDao dao = new DanhMucDao();
            danhmuc dm = dao.getById(ma);
            dm.ten = ten;
            dao.Edit(dm);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public ActionResult Delete(int ma)
        {
            DanhMucDao dao = new DanhMucDao();
            dao.Delete(ma);
            return Redirect("~/Admin/DanhMuc/Index");
        }
        #endregion
    }
}