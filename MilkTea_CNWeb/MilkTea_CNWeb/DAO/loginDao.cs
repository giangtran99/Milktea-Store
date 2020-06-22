using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MilkTea_CNWeb.DAO
{
    public class loginDao
    {
        TraSuaModel db;
        public loginDao()
        {
            db = new TraSuaModel();
        }
        public bool isLogin(string name, string pass)
        {
            var count = db.KhachHangs.Where(x => x.TenDangNhap == name && x.MatKhau == pass).FirstOrDefault();
            if (count != null)
            {
                return true;
            }
            return false;
        }
        public bool isLoginNV(string name, string pass)
        {
            var count = db.Nhanviens.Where(x => x.TenDangNhap == name && x.MatKhau == pass).FirstOrDefault();
            if (count != null)
            {
                return true;
            }
            return false;
        }
    }
}