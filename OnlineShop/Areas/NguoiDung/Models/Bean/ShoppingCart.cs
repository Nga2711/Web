
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.NguoiDung.Models.Bean
{
    public class ShoppingCart
    {
        public List<ItemCart> ListItem = new List<ItemCart>();
        public void AddItem (int ID, string Name, string Picture, int Amount, decimal Price)
        {
            bool Check = false;
            foreach (var item in ListItem)
            {
                if (item.ID == ID)
                {
                    Check = true;
                    item.Amount += Amount;
                    break;
                }
            }
            if (!Check)
            {
                ItemCart item = new ItemCart();
                item.ID = ID;
                item.Name = Name;
                item.Picture = Picture;
                item.Amount = Amount;
                item.Price = Price;
                ListItem.Add(item);
            
            }
        }

        // tang so luong cua mot san pham
        public void AddAmount (int ID, int Amount)
        {
            foreach (var item in ListItem)
            {
                if ( item.ID == ID) // neu mat hang da co trong gio hang >> tang so luong cua no len
                {
                    item.Amount += Amount;
                    break;
                }
            }
        }

        //xoa tat ca mot san pham 
        public void DeleleAll (int ID)
        {
            foreach (var item in ListItem)
            {
                if(item.ID == ID)
                {
                    ListItem.Remove(item);
                    break;
                }
            }
        }

        // giam so luong cua mot san pham
        public void Delete (int ID, int Amount)
        {
            foreach(var item in ListItem)
            {
                if (item.ID == ID)
                {
                    item.Amount -= Amount;
                    break;
                }
            }
        }

        // tong tien trong gio hang
        public decimal GetToTalCart()
        {
            decimal ToTal = 0;
            foreach(var item in ListItem)
            {
                ToTal += item.GetTotal();
            }
            return ToTal;
        }

        // dua ra tong san pham trong gio hang
        public int GetAmount()
        {
            int Amount = 0;
            foreach(var item in ListItem)
            {
                Amount += item.Amount;
            }
            return Amount;
        }
        
    }
}