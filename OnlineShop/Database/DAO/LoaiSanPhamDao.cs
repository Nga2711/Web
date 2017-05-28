using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Database.EF;
using PagedList;

namespace OnlineShop.Database.DAO
{
    public class LoaiSanPhamDao
    {
        DBShop db;
        public LoaiSanPhamDao()
        {
            db = new DBShop();
        }
        public List<loaisanpham> DSLSP()
        {
            return db.loaisanphams.ToList();
        }
        public loaisanpham getById(int ma)
        {
            return db.loaisanphams.Single(i => i.ma == ma);
        }
        public List<loaisanpham> get()
        {
            var ct = from x in db.loaisanphams
                     join y in db.danhmucs on x.danhmucma equals y.ma
                     select x;


            return (ct.Count() > 0) ? ct.ToList() : null;
        }

        public void Add(loaisanpham lsp)
        {
            db.loaisanphams.Add(lsp);
            db.SaveChanges();
        }

        public void Edit(loaisanpham lsp)
        {
            loaisanpham pr = getById(lsp.ma);
            if (pr != null)
            {
                pr.ten = lsp.ten;            
                pr.danhmucma = lsp.danhmucma;
                db.SaveChanges();
            }

        }

        public int Delete(int ma)
        {
            loaisanpham lsp = db.loaisanphams.Find(ma);
            if (lsp != null)
            {
                db.loaisanphams.Remove(lsp);
                return db.SaveChanges();
            }
            else
                return -1;
        }
        public IEnumerable<loaisanpham> ListSPPage(int Pagenum, int PageSize)
        {

            return db.loaisanphams.OrderByDescending(a => a.ma).ToPagedList(Pagenum, PageSize);
        }
    }
}