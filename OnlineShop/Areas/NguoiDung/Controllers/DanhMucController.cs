using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Database.DAO;
using OnlineShop.Database.EF;

namespace OnlineShop.Areas.NguoiDung.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: NguoiDung/DanhMuc
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult left_sidebar()
        {
            var model = new DanhMucDao().DSDM();
         //   var model1 = new LoaiSanPhamDao().get();
            LoaiSanPhamDao dao = new LoaiSanPhamDao();
            ViewBag.lsp = dao.get();
            return PartialView(model);
        }

    }
}