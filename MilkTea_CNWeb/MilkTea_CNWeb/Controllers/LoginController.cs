using MilkTea_CNWeb.DAO;
using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkTea_CNWeb.Controllers
{
    public class LoginController : Controller
    {
        public const string strLogin = "LoginSession";
        public const string strLoginNV = "LoginSessionNV";
        loginDao db = new loginDao();
        // GET: Login
        public ActionResult DangNhap(string userName,string passWord)
        {
           
            if (db.isLogin(userName,passWord))
            {
                var acc = new LoginModel();
                acc.userName = userName;
                acc.passWord = passWord;
                Session[strLogin] = acc;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (db.isLoginNV(userName, passWord))
                {
                    var acc = new LoginModel();
                    acc.userName = userName;
                    acc.passWord = passWord;
                    Session[strLoginNV] = acc;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
    

        public ActionResult DangXuat()
        {
            Session[strLogin] = null;
            Session[CartController.strCart] = null;
            return RedirectToAction("Index", "Home");
        }
    }   
}