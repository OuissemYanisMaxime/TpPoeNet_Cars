using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using API_Comptes.ViewModels;
using System.Net;

namespace WebInterface.Filters
{
    public class CookieUserMail : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Request.Cookies["UserSettings"] != null)
                && (filterContext.HttpContext.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userEMail = filterContext.HttpContext.Request.Cookies["UserSettings"]["email"];
                string userName = filterContext.HttpContext.Request.Cookies["UserSettings"]["Name"];
                filterContext.Controller.ViewBag.UserMail = userEMail;
                filterContext.Controller.ViewBag.UserName = userName;
            }
        }      
    }
}