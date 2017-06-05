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
    public class LoaiSanPhamController : Controller
    {
        DBShop db = new DBShop();
        // GET: Admin/LoaiSanPham
        public ActionResult Index(int PageNum = 1, int PageSize = 5)
        {
            LoaiSanPhamDao dao = new LoaiSanPhamDao();
            if (Session["tentruycap"] == null)
            {
                return Redirect("../AdminHome/Login");
            }
            return View(dao.ListSPPage(PageNum, PageSize));
        }

        #region Add
        public ActionResult Add()
        {
            List<object> myModel = new List<object>();
            myModel.Add(db.danhmucs.ToList());
            return View(myModel);
        }

        [HttpPost]
        public ActionResult Add(string ten, string danhmucma)
        {
          
            loaisanpham lsp = new loaisanpham();
            lsp.ten = ten;
            if (danhmucma == "null")
            {
                lsp.danhmucma = null;
            }
            else
            {
                lsp.danhmucma = Int32.Parse(danhmucma);
            }

                   LoaiSanPhamDao dao = new LoaiSanPhamDao();
                    dao.Add(lsp);
                return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        public ActionResult Edit(int ma)
        {
            LoaiSanPhamDao dao = new LoaiSanPhamDao();
            ViewBag.lsp = dao.getById(ma);
            List<danhmuc> dm = new List<danhmuc>();
            DanhMucDao dao1 = new DanhMucDao();
            ViewBag.dm = dao1.DSDM();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int ma, string ten, string danhmucma)
        { 

         
            LoaiSanPhamDao dao = new LoaiSanPhamDao();
            loaisanpham sp = dao.getById(ma);

            sp.ten = ten;
            if (danhmucma == "null")
            {
                sp.danhmucma = null;
            }
            else
            {
                sp.danhmucma = Int32.Parse(danhmucma);
            }

                    dao.Edit(sp);
              
                return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        public ActionResult Delete(int ma)
        {
            LoaiSanPhamDao dao = new LoaiSanPhamDao();
            dao.Delete(ma);
            return Redirect("~/Admin/LoaiSanPham/Index");
        }
        #endregion
    }
}