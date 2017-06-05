using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Database.EF;
using PagedList;

namespace OnlineShop.Database.DAO
{
    public class ChiTietDonHangDao
    {
        DBShop db;

        public ChiTietDonHangDao()
        {
            db = new DBShop();
        }

        public List<chitietdonhang> GetAll()
        {
            return db.chitietdonhangs.ToList();
        }

        public IEnumerable<chitietdonhang> GetByStr(int? str, int page = 1, int pageSize = 8)
        {
            IQueryable<chitietdonhang> ls = db.chitietdonhangs;
            if (!string.IsNullOrEmpty(str.ToString()))
            {
                ls = ls.Where(x => x.hoadonma == str || x.sanphamma == str || x.soluong == str || x.thanhtien == (decimal)str);
            }

            return ls.OrderBy(x => x.hoadonma).ToPagedList(page, pageSize);
        }


        public List<chitietdonhang> GetByCatagory(int sohoadon)
        {
            return db.chitietdonhangs.Where(x => x.hoadonma == sohoadon).ToList();
        }

        public List<chitietdonhang> GetByProduct(int mahang)
        {
            return db.chitietdonhangs.Where(x => x.sanphamma == mahang).ToList();
        }

        public IEnumerable<History> GetByObj(int makhachhang)
        {
            IQueryable<History> res = from h in db.donhangs
                                      join c in db.donhangs
                                      on h.ma equals c.khachhangma
                                      join d in db.chitietdonhangs
                                      on c.ma equals d.hoadonma
                                      join p in db.sanphams
                                      on d.sanphamma equals p.ma
                                      where h.ma == makhachhang
                                      select new History
                                      {
                                          SanPham = p.ten,
                                          SoLuong = d.soluong,
                                          NgayDat = c.ngaylap,
                                          Gia = (decimal)p.gia,
                                          TongTien = d.soluong * (decimal)p.gia,
                                          TrangThai = c.trangthai
                                      };
            return res.ToList();

        }

        public bool Delete(int sohoadon)
        {
            try
            {
                var ls = db.chitietdonhangs.Where(x => x.hoadonma == sohoadon).ToList();
                foreach (var item in ls)
                {
                    db.chitietdonhangs.Remove(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert(chitietdonhang ctdh)
        {
            try
            {
                db.chitietdonhangs.Add(ctdh);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(chitietdonhang ctdh)
        {
            try
            {
                var hdct = db.chitietdonhangs.SingleOrDefault(x => x.hoadonma == ctdh.hoadonma && x.sanphamma == ctdh.sanphamma);
                var mh = db.sanphams.SingleOrDefault(x => x.ma == hdct.sanphamma);

                hdct.thanhtien = (decimal)mh.gia;
                hdct.soluong = ctdh.soluong;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}