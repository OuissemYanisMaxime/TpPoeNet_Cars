using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using API_Comptes.ViewModels;

namespace WebInterface.Filters
{
    public class ClientDetails : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Request.Cookies["UserSettings"] != null)
                && (filterContext.HttpContext.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = filterContext.HttpContext.Request.Cookies["UserSettings"]["token"];
                string userEMail = filterContext.HttpContext.Request.Cookies["UserSettings"]["email"];

                string apiUrl = "http://localhost:50631/api/clients/email/?email=" + userEMail;
                Task<Client> c = Task.Run<Client>(async() => await apiUrl
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .GetAsync().ReceiveJson<Client>());

                if (c.Result != null)
                    filterContext.Controller.ViewBag.user = c.Result;
            }
            else
            {
                Client c = new Client();
                filterContext.Controller.ViewBag.client = c;
            }
        }      
    }
}