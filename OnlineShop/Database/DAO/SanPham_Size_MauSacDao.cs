using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Database.EF;
using PagedList;

namespace OnlineShop.Database.DAO
{
    public class SanPham_Size_MauSacDao
    {
        DBShop db;
        public SanPham_Size_MauSacDao()
        {
            db = new DBShop();
        }
        public IEnumerable<sanpham_size_mausac> ListSPPage(int Pagenum, int PageSize)
        {

            return db.sanpham_size_mausac.OrderByDescending(a => a.sanphamma).ToPagedList(Pagenum, PageSize);
        }

        public void Add(sanpham_size_mausac sp)
        {
            db.sanpham_size_mausac.Add(sp);
            db.SaveChanges();
        }

        public void Edit(sanpham_size_mausac sp)
        {
           sanpham_size_mausac pr = getById(sp.sanphamma, sp.sizema, sp.mauma);
            if (pr != null)
            {
                pr.soluong = sp.soluong;
                db.SaveChanges();
            }

        }

        public int Delete(int sanphamma, string sizema, string mauma)
        {
            sanpham_size_mausac lsp = db.sanpham_size_mausac.Find(sanphamma, sizema, mauma);
            if (lsp != null)
            {
                db.sanpham_size_mausac.Remove(lsp);
                return db.SaveChanges();
            }
            else
                return -1;
        }

        public sanpham_size_mausac getById(int sanphamma, string sizema, string mauma)
        {
            var ct = from x in db.sanpham_size_mausac
                     where x.sanphamma == sanphamma && x.sizema == sizema && x.mauma == mauma
                     select x;
            return (ct.Count() > 0) ? ct.Single() : null;
            //return db.sanpham_size_mausac.
        }
    }
}