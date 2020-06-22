using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilkTea_CNWeb.DAO
{
    public class homeDao
    {
        TraSuaModel db;
        public homeDao()
        {
            db = new TraSuaModel();
        }
        public List<SanPham> GetListTraSua()
        {
            return db.SanPhams.Where(x => x.LoaiSP == 2).ToList();
        }
        public List<SanPham> GetListTraSuaforVIP()
        {
            return db.SanPhams.Where(x => x.LoaiSP == 1).ToList();
        }
        public SanPham GetSanPhambyID(int? id)
        {
            return db.SanPhams.Find(id);
        }
        public List<Topping> GetListTopping()
        {
            return db.Toppings.Select(x => x).ToList();
        }
        public List<Size> GetListSize()
        {
            return db.Sizes.Select(x => x).ToList();
        }

        public KhachHang GetKHbyTaiKhoan(string tk)
        {
            return db.KhachHangs.Where(x => x.TenDangNhap == tk).FirstOrDefault();
        }
        public void SuaKH(KhachHang khModel)
        {
           
                var kh = db.KhachHangs.Where(x => x.TenDangNhap == khModel.TenDangNhap).FirstOrDefault();
                kh.TenDangNhap = khModel.TenDangNhap;
                kh.MatKhau = khModel.MatKhau;
                kh.Email = khModel.Email;
                kh.SDT = khModel.SDT;
                kh.Diachi = khModel.Diachi;
                kh.HoTen = khModel.HoTen;
                db.SaveChanges();
            
             
        }
    
        

    }
}