using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Database.EF;
using OnlineShop.Database.DAO;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string ten, string matkhau)
        {
            AdminDao dao = new AdminDao();
            if (dao.ktDangNhap(ten, matkhau))
            {
                Session["tentruycap"] = ten;
                return Redirect("../AdminHome/Index");
            }
            else
                return Redirect("Login");
        }
    }
}