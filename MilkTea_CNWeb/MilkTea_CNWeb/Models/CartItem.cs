using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MilkTea_CNWeb.Models
{
    public class CartItem
    {
        public SanPham product { get; set; }

        public string Topping { get; set; }

        public int? GiaSize { get; set; }

        public int Quanity { get; set; }

        public string TenSize { get; set; }


    }
    public class Cart
    {
        TraSuaModel db = new TraSuaModel();
        List<CartItem> listCart = new List<CartItem>();

        public void ThemSanPham(int idSP, int sl,string topping,int? giaSize,string tenSize)
        {
            var sp = db.SanPhams.Find(idSP);

            listCart.Add(new CartItem
            {
                product = sp,
                Quanity = sl,
                Topping = topping,
                GiaSize = giaSize,
                TenSize = tenSize
            });
        }
        public void XoaSanPham(SanPham sp)
        {
            listCart.RemoveAll(x => x.product.MaSanPham == sp.MaSanPham);
        }
        public bool isExistinCart(int idSP)
        {
            var entity = listCart.Find(x => x.product.MaSanPham == idSP);
            if(entity != null)
            return true;
            return false;
        }
        public double? TongTien()
        {
            
            return listCart.Sum(x => (x.product.Gia + x.GiaSize) * x.Quanity );
        }
        public IEnumerable<CartItem> DanhSachSP()
          {
            return listCart;
          }

        public int QuanityCart()
        {
            return listCart.Count;
        }
        
        public void UpdateCart(int idSP,int soluong)
        {
            var sp = listCart.Find(x => x.product.MaSanPham == idSP);
            sp.Quanity += soluong;

        }



    }

}