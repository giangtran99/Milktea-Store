using MilkTea_CNWeb.Controllers;
using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilkTea_CNWeb.DAO
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        TraSuaModel db = new TraSuaModel();
      
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var acc = (LoginModel)httpContext.Session[LoginController.strLogin];
        
            if (acc != null)
            {
                var kh = db.KhachHangs.Where(x => x.TenDangNhap == acc.userName).FirstOrDefault();
                if (kh.LoaiKH == "VIP")
                {
                    return true;
                }
            }

            return false;

                          
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult { ViewName = "ErrorQuyen" };

        }


    }
}