using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace OnlineShop.Database.DAO
{
    public class History
    {
        public string SanPham { get; set; }
        public int? SoLuong { get; set; }
        public DateTime? NgayDat { get; set; }
        public decimal Gia { get; set; }
        public decimal TongTien { get; set; }
        public long TrangThai { get; set; }
    }
}