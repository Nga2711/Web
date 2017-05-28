using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.NguoiDung.Controllers
{
    public class HomeController : Controller
    {
        // GET: NguoiDung/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact1()
        {
            return View();
        }
    }
}