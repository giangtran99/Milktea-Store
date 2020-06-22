using MilkTea_CNWeb.Controllers;
using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkTea_CNWeb.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController, IController
    {
        TraSuaModel db = new TraSuaModel();
        // GET: Admin/Home
        public ActionResult index()
        {
            return View();
        }
        public ActionResult ShowTraSua()
        {
            var model = db.SanPhams.Select(x => x).ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult ThemTraSua(SanPham sp)
        {
            if(sp.TenSanPham !=null)
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
            }
         
            return View();
        }
    }
}