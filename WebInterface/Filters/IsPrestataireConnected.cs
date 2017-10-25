using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebInterface.Filters
{
    public class IsPrestataireConnected : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Request.Cookies["UserSettings"] != null)
                && (filterContext.HttpContext.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = filterContext.HttpContext.Request.Cookies["UserSettings"]["token"];
            
                Task<bool> t = Task.Run<bool>(async() => await "http://localhost:50631/api/IsProvider"
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<bool>());

                if (t.Result != true)
                    filterContext.HttpContext.Response.RedirectToRoute("Default", new { controller = "Prestataire", action = "login" });
            }
            else
            {
                filterContext.HttpContext.Response.RedirectToRoute("Default", new { controller = "home", action = "index" });
            }
        }      
    }
}