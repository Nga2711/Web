using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Database.EF;
using PagedList;

namespace OnlineShop.Database.DAO
{
  
    public class KhachHangDao
    {
        DBShop db;
        public KhachHangDao()
        {
            db = new DBShop();
        }

        public List<khachhang> GetAll ()
        {
            return db.khachhangs.ToList();
        }

        public IEnumerable<khachhang> GetByStr (string str, int page = 1, int pageSize = 8 )
        {
            IQueryable<khachhang> ls = db.khachhangs;
            if (!string.IsNullOrEmpty(str))
            {
                ls = ls.Where(x => x.ten.Contains(str) || x.email.Contains(str) || x.diachi.Contains(str) || x.dienthoai.Contains(str));
            }
            return ls.OrderBy(x => x.ten).ToPagedList(page, pageSize);
        }

        public int Insert(khachhang kh)
        {

            db.khachhangs.Add(kh);
            db.SaveChanges();
            return kh.ma;

        }
        public khachhang ViewDetail(int id)
        {
            return db.khachhangs.Find(id);
        }

        public bool Update(khachhang kh)
        {
            try
            {
                var khachhang = db.khachhangs.SingleOrDefault(x => x.ma == kh.ma);

                khachhang.ten = kh.ten;
                khachhang.matkhau = kh.matkhau;
                khachhang.email = kh.email;
                khachhang.dienthoai = kh.dienthoai;
                khachhang.diachi = kh.diachi;

                db.SaveChanges();


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {   
                // singleordefault : tra ve doi tuong thoa man dk va duy nhat
                // neu khong duy nhat hoac k tim thay se vang exc
                var khachhang = db.khachhangs.SingleOrDefault(x => x.ma == id);

                db.khachhangs.Remove(khachhang);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public khachhang GetByUser(string str)
        {
            return db.khachhangs.SingleOrDefault(x => x.ten == str || x.email == str);
        }

        public bool CheckUser(string username)
        {
            var user = db.khachhangs.SingleOrDefault(x => x.ten == username);
            if (user != null)
                return true;
            return false;
        }

        public bool CheckEmail(string email)
        {
            int cout = db.khachhangs.Where(x => x.email == email).Count();
            if (cout > 0)
                return true;
            return false;
        }
    }
}