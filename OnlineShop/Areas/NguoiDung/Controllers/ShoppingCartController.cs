﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Areas.NguoiDung.Models.Bean;
using OnlineShop.Database.DAO;
using OnlineShop.Database.EF;


namespace OnlineShop.Areas.NguoiDung.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: NguoiDung/ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        // them san pham vao gio hang
        public ActionResult Add(int id)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart == null)
                Cart = new ShoppingCart();
            SanPhamDao dao = new SanPhamDao();
            sanpham sp = dao.getById(id);
            Cart.AddItem(sp.ma, sp.ten, 1, (double)sp.gia);
            Session["cart"] = Cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        // xoa toan bo san pham co id = id
        public ActionResult DeleteAll(int id)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart != null)
                Cart.DeleleAll(id);
            Session["cart"] = Cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        // giam so luong cua mot san pham co id = id
        public ActionResult Delete(int id, int amount) // khi goi cho : amount  = 1
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart != null)
                Cart.Delete(id, amount);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult List()
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            List<ItemCart> ls = new List<ItemCart>();
            if (Cart != null)
                ls = Cart.ListItem;
            return View(ls);
        }

        public ActionResult Info()
        {
            double total = 0;
            ShoppingCart Cart = (ShoppingCart)Session["cart"]; // gan list san pham trong shoppingcart = session["cart"]
            if(Cart != null)
            {
                total = Cart.GetToTalCart();
                ViewBag.Total = total;
            }
            else
            {
                ViewBag.Total = 0;
            }
            return View(Cart);
        }
    }
}