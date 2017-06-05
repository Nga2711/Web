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
    public class SanPham_Size_MauSacController : Controller
    {
        DBShop db = new DBShop();
        // GET: Admin/SanPham_Size_MauSac
        public ActionResult Index(int PageNum = 1, int PageSize = 5)
        {
           SanPham_Size_MauSacDao  dao = new SanPham_Size_MauSacDao();
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
            myModel.Add(db.sanphams.ToList());         
            return View(myModel);
        }

        [HttpPost]
        public ActionResult Add(string sanphamma, string soluong, string sizema,string mauma)
        {
          
            sanpham_size_mausac  sp = new sanpham_size_mausac();
            sp.sanphamma = Int32.Parse(sanphamma);
            sp.soluong = Int32.Parse(soluong);
            sp.sizema = sizema;
            sp.mauma = mauma;                  
            SanPham_Size_MauSacDao dao = new SanPham_Size_MauSacDao();
            dao.Add(sp);
            return RedirectToAction("Index");          
        }
        #endregion

        #region Edit
        public ActionResult Edit(int sanphamma, string sizema, string mauma)
        {
            //   List<sanpham> sp = new List<sanpham>();
            //   SanPhamDao spdao = new SanPhamDao();           
            // ViewBag.sp = spdao.ListSP();
            SanPham_Size_MauSacDao dao = new SanPham_Size_MauSacDao();
            ViewBag.sss = dao.getById(sanphamma, sizema, mauma);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int sanphamma, string soluong, string sizema, string mauma)
        {
          
            SanPham_Size_MauSacDao dao = new SanPham_Size_MauSacDao();
            sanpham_size_mausac sp = dao.getById(sanphamma, sizema, mauma);
            sp.soluong = Int32.Parse(soluong);
            dao.Edit(sp);
            return RedirectToAction("Index");
        }
        #endregion


        #region Delete
        public ActionResult Delete(int sanphamma, string sizema, string mauma)
        {
            SanPham_Size_MauSacDao dao = new SanPham_Size_MauSacDao();
            dao.Delete(sanphamma, sizema, mauma);
            return Redirect("~/Admin/SanPham_Size_MauSac/Index");


        }
        #endregion
    }
}