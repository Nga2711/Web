using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Database.EF;

namespace OnlineShop.Database.DAO
{
    public class AdminDao
    {
        DBShop db;
        public AdminDao()
        {
            db = new DBShop();
        }
        public bool ktDangNhap(string ten, string matkhau)
        {
            bool kt = false;
            //  int a = db.admins.Where(y => y.tentruycap== ten && y.matkhau == matkhau).ToList().Count();
            var a = from x in db.admins
                    where x.tentruycap.Equals(ten) && x.matkhau.Equals(matkhau)
                    select x;
            if (a.Count() > 0)
                kt = true;
            return kt;
        }
    }
}