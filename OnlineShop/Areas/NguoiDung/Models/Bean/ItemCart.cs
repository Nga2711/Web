using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.NguoiDung.Models.Bean
{
    public class ItemCart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal GetTotal()
        {
            return Amount * Price;
        }

    }
}