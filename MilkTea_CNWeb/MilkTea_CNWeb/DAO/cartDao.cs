using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace MilkTea_CNWeb.DAO
{
    public class cartDao
    {
        TraSuaModel db;
        public cartDao()
        {
            db = new TraSuaModel();
        }
        public bool isOnlyEmail(string email)
        {
            var temp = db.KhachHangs.Where(x => x.Email == email).FirstOrDefault();
            if (temp != null)
                return false;
            return true;
        }
        public bool isOnlyTaiKhoan(string taikhoan)
        {
            var temp = db.KhachHangs.Where(x => x.TenDangNhap == taikhoan).FirstOrDefault();
            if (temp != null)
                return false;
            return true;
        }

        public void ThemKhachHang(KhachHang kh)
        {
         
                db.KhachHangs.Add(kh);
                db.SaveChanges();
              
        }
        public void ThemHoaDon(DonHang hd)
        {
                
                db.DonHangs.Add(hd);
                db.SaveChanges();

            
            
        }
        public void ThemChiTietHoaDon(ChitietDonHang ctdh)
        {
          
                db.ChitietDonHangs.Add(ctdh);
                db.SaveChanges();
            
            
        }
        public KhachHang GetKhbyEmail(string email)
        {
            return db.KhachHangs.Where(x => x.Email == email).FirstOrDefault();
        }

        public int GetMaDH()
        {
            DateTime? date = db.DonHangs.Max(x => x.NgayDatHang);
            var list = db.DonHangs.Select(x => x).ToList();
            foreach (var item in list)
            {
                if (item.NgayDatHang.ToString().Contains(date.ToString()))
                {
                    return item.MaDonHang;
                }
            }
            return 1;
        }
      
        public Topping GetMaTopbyTen(string TenTopping)
        {
            return db.Toppings.Where(x => x.Ten == TenTopping).FirstOrDefault();
        }

      

        
        

    }
}