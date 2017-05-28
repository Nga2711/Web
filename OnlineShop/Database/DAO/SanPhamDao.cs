using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Database.EF;
using PagedList;

namespace OnlineShop.Database.DAO
{
    public class SanPhamDao
    {
        DBShop db;
        public SanPhamDao()
        {
            db = new DBShop();
        }

        public List<sanpham> ListSPMoi(int lay)
        {
            return db.sanphams.OrderByDescending(a=>a.ma).Take(lay).ToList();
        }

        public List<sanpham> ListSPDeNghi(int loaisanphamma, int top)
        {
            return db.sanphams.Where(a=>a.loaisanphamma==loaisanphamma).OrderBy(a => a.ma).Take(top).ToList();
        }

        public List<sanpham> ListSPById(int loaisanphamma)
        {
            return db.sanphams.Where(x=>x.loaisanphamma==loaisanphamma).OrderBy(a => a.ma).ToList();
        }

        //public List<sanpham> ChiTietSanPham(sanpham sp)
        //{
        //    return db.sanphams.Where(a => a.ma == ma).ToList();
        //}
        public void Add(sanpham sp)
        {
            db.sanphams.Add(sp);
            db.SaveChanges();
        }

        public void Edit(sanpham sp)
        {
            sanpham pr = getById(sp.ma);
            if (pr != null)
            {
                pr.ten = sp.ten;
                pr.gia = sp.gia;
                pr.mota = sp.mota;
                pr.nhasanxuat = sp.nhasanxuat;               
                pr.anh = sp.anh;
                pr.loaisanphamma = sp.loaisanphamma;
                pr.danhmucma = sp.danhmucma;
                db.SaveChanges();
            }

        }

        public int Delete(int ma)
        {
            sanpham sp = db.sanphams.Find(ma);
            if (sp != null)
            {
                db.sanphams.Remove(sp);
                return db.SaveChanges();
            }
            else
                return -1;
        }

        public sanpham getById(int ma)
        {
            return db.sanphams.Where(i => i.ma == ma).SingleOrDefault();
        }

      

        //public List<sanpham> ListSP(int Pagenum, int PageSize)
        //{
        //    return db.sanphams.Skip((Pagenum - 1) * PageSize).Take(PageSize).ToList();
        //}

        

        public IEnumerable<sanpham> ListSPPage(int Pagenum, int PageSize)
        {

            return db.sanphams.OrderByDescending(a => a.ma).ToPagedList(Pagenum, PageSize);
        }
    }
}