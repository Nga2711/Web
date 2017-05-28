using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShop.Database.EF;
using PagedList;

namespace OnlineShop.Database.DAO
{
    public class DanhMucDao
    {
        DBShop db;
        public DanhMucDao()
        {
            db = new DBShop();
        }
        public List<danhmuc> DSDM()
        {
            return db.danhmucs.ToList();
        }
        public danhmuc getById(int ma)
        {
            return db.danhmucs.Single(i => i.ma == ma);
        }
        public void Add(danhmuc dm)
        {
            db.danhmucs.Add(dm);
            db.SaveChanges();
        }

        public void Edit(danhmuc dm)
        {
            danhmuc dm1 = getById(dm.ma);
            if (dm1 != null)
            {
                dm1.ten = dm.ten;               
                db.SaveChanges();
            }

        }

        public int Delete(int ma)
        {
            danhmuc dm = db.danhmucs.Find(ma);
            if (dm != null)
            {
                db.danhmucs.Remove(dm);
                return db.SaveChanges();
            }
            else
                return -1;
        }
        public IEnumerable<danhmuc> ListSPPage(int Pagenum, int PageSize)
        {

            return db.danhmucs.OrderByDescending(a => a.ma).ToPagedList(Pagenum, PageSize);
        }
    }
}