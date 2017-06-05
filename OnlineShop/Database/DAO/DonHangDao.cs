using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Database.EF;
using PagedList;

namespace OnlineShop.Database.DAO
{
    public class DonHangDao
    {
        DBShop db;

        public DonHangDao()
        {
            db = new DBShop();
        }
        public List<donhang> GetAll()
        {
            return db.donhangs.ToList();
        }

        public IEnumerable<donhang> GetByStr(long str, int page = 1, int pageSize = 8)
        {
            IQueryable<donhang> ls = db.donhangs;
            if (!string.IsNullOrEmpty(str.ToString()))
            {
                ls = ls.Where(x => x.ma == str || x.khachhangma == str || x.trangthai == str);
            }

            return ls.OrderByDescending(x => x.ngaylap).ToPagedList(page, pageSize);
        }

        public donhang ViewDetail(int ma)
        {
            return db.donhangs.SingleOrDefault(x => x.ma == ma);
        }

        public bool Delete(int ma)
        {
            try
            {
                var dh = db.donhangs.SingleOrDefault(x => x.ma == ma);
                db.donhangs.Remove(dh);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Insert(donhang dh)
        {
            db.donhangs.Add(dh);
            db.SaveChanges();
            return dh.ma;
        }

        public bool Update(donhang dh)
        {
            try
            {
                var res = db.donhangs.SingleOrDefault(x => x.ma == dh.ma);
                res.diadiemgiao = dh.diadiemgiao;
                res.khachhangma = dh.khachhangma;
                res.ngaygiao = dh.ngaygiao;
                res.ngaylap = dh.ngaylap;
                res.phivanchuyen = dh.phivanchuyen;
                res.tonggia = dh.tonggia;
                res.trangthai = dh.trangthai;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<int> SetById(int makhachhang)
        {
            return db.donhangs.Where(x => x.khachhangma == makhachhang).Select(x => x.ma).ToList();
        }
    }
}