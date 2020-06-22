using MilkTea_CNWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MilkTea_CNWeb.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            var acc = (LoginModel)Session[LoginController.strLoginNV];
             
        
            if(acc==null)
            {
               filterContext.Result = new RedirectToRouteResult(
                   new RouteValueDictionary(new { controller = "Home", action = "Index" }));

            }
        
          //Add whatever
            base.OnActionExecuting(filterContext);
        }
    }
}