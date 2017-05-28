using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Database.DAO;

namespace OnlineShop.Areas.NguoiDung.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: NguoiDung/SanPham
        public ActionResult Index(int loaisanphamma)
        {
            var lsp = new LoaiSanPhamDao().getById(loaisanphamma);
            ViewBag.lsp = lsp;
            SanPhamDao dao = new SanPhamDao();
            var model = dao.ListSPById(loaisanphamma);
            return View(model);
        }

   

        [ChildActionOnly]
        public PartialViewResult SPMoi()
        {
            SanPhamDao dao = new SanPhamDao();
            ViewBag.spm = dao.ListSPMoi(6);
         
            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult SPDeNghi()
        {
            SanPhamDao dao = new SanPhamDao();
            ViewBag.spdn1 = dao.ListSPDeNghi(1,3);
            ViewBag.spdn2 = dao.ListSPDeNghi(3, 3);
            ViewBag.spdn3 = dao.ListSPDeNghi(5, 3);
            return PartialView();
        }

        public ActionResult ChiTietSanPham(int ma)
        {
            var sp = new SanPhamDao().getById(ma);
            return View(sp);
        }
    }
}