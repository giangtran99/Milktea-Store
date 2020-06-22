using MilkTea_CNWeb.DAO;
using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkTea_CNWeb.Controllers
{
    public class HomeController : Controller
    {
        homeDao homeDao = new homeDao();
        cartDao cart = new cartDao();
        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult ShopAll()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CustomAuthorize]
        public ActionResult ShopAllforVIP()
        {
            var result = homeDao.GetListTraSuaforVIP();
            ViewBag.Message = "Your application description page.";
            return View(result);
        }


        public ActionResult ShopDetail(int? id = 1)
        {
            ViewBag.Message = "Your application description page.";
            if(id != null)
            {
                ViewBag.TraSuaDetail = homeDao.GetSanPhambyID(id);
                ViewData["ListTopping"] = homeDao.GetListTopping();
                ViewBag.ListSize = homeDao.GetListSize();
            }
               
            return View();
        }
       

        [HttpGet]
        public JsonResult GetListTraSua()
        {
            var result = homeDao.GetListTraSua();
            return Json(new { status = true, data = result }, JsonRequestBehavior.AllowGet);
        }
   
        public ActionResult GetThongTinKH()
        {
            var acc = (LoginModel)Session[LoginController.strLogin];
            if(acc != null)
            {
                var kh = homeDao.GetKHbyTaiKhoan(acc.userName);
                return View(kh);
            }   
            return RedirectToAction("Index");
        }

        public ActionResult SuaThongTinKH(KhachHang kh)
        {
          
            try
            {
                if (ModelState.IsValid)
                {
                    homeDao.SuaKH(kh);
                    return Content("<script>alert('Sua Thanh Cong')</script>");
                    
                }

                var result = ModelState.Values.Select(x => x.Errors).ToList();
                
                return Json(new { data = result }, JsonRequestBehavior.AllowGet);

            }
            catch(Exception ex)
            {
                ModelState.AddModelError(kh.HoTen, ex.Message);
                return Json(new { data = "Sửa Thất Bại " }, JsonRequestBehavior.AllowGet);
            }
                     
        
        }


      


     


    }
}