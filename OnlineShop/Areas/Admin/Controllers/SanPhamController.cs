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
    public class SanPhamController : Controller
    {
        DBShop db = new DBShop();
        // GET: Admin/SanPham
        public ActionResult Index(int PageNum = 1, int PageSize = 9)
        {
            SanPhamDao dao = new SanPhamDao();
            return View(dao.ListSPPage(PageNum, PageSize));
        }


        #region Add
        public ActionResult Add()
        {
            List<object> myModel = new List<object>();
            myModel.Add(db.danhmucs.ToList());
            myModel.Add(db.loaisanphams.ToList());          
            return View(myModel);
        }

        [HttpPost]
        public ActionResult Add(string ten, string gia, string mota, string nhasanxuat, string loaisanphamma,string danhmucma, HttpPostedFileBase anh)
        {
            var img = Path.GetFileName(anh.FileName);
            sanpham sp = new sanpham();
            sp.ten = ten;
            sp.gia = Decimal.Parse(gia);
            sp.mota = mota;
            sp.nhasanxuat = nhasanxuat;          
            sp.loaisanphamma = Int32.Parse(loaisanphamma);
            if (danhmucma == "null")
            {
                sp.danhmucma = null;
            }
            else
            {
                sp.danhmucma = Int32.Parse(danhmucma);
            }
           
            if (ModelState.IsValid)
            {
                if (anh != null && anh.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"),
                                            System.IO.Path.GetFileName(anh.FileName));
                    anh.SaveAs(path);

                    sp.anh = anh.FileName;
                    SanPhamDao dao = new SanPhamDao();
                    dao.Add(sp);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(sp);
            }
        }
        #endregion

        #region Edit
        public ActionResult Edit(int ma)
        {
         //   List<loaisanpham> ls = new List<loaisanpham>();
            LoaiSanPhamDao dao = new LoaiSanPhamDao();
            SanPhamDao spdao = new SanPhamDao();
            ViewBag.lsp = dao.DSLSP();
            ViewBag.sp = spdao.getById(ma);
        //    List<danhmuc> dm = new List<danhmuc>();
            DanhMucDao dao1 = new DanhMucDao();
            ViewBag.dm = dao1.DSDM();           
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int ma, string ten, string gia, string mota, string nhasanxuat, string soluong, string loaisanphamma, string danhmucma, HttpPostedFileBase anh)
        {
            var img = Path.GetFileName(anh.FileName);
            SanPhamDao dao = new SanPhamDao();
            sanpham sp = dao.getById(ma);

            sp.ten = ten;
            sp.gia = Decimal.Parse(gia);
            sp.mota = mota;
            sp.nhasanxuat = nhasanxuat;
         
            sp.loaisanphamma = Int32.Parse(loaisanphamma);
            if (danhmucma == "null")
            {
                sp.danhmucma = null;
            }
            else
            {
                sp.danhmucma = Int32.Parse(danhmucma);
            }
            if (ModelState.IsValid)
            {
                if (anh != null && anh.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"),
                                            System.IO.Path.GetFileName(anh.FileName));
                    anh.SaveAs(path);

                    sp.anh = anh.FileName;

                    dao.Edit(sp);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(sp);
            }
        }
        #endregion

        #region Delete
        public ActionResult Delete(int ma)
        {
            SanPhamDao dao = new SanPhamDao();
            dao.Delete(ma);
            return Redirect("~/Admin/SanPham/Index");
        }
        #endregion
    }
}
