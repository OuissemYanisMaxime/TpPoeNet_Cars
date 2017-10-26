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
    public class ClientDetails : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Request.Cookies["UserSettings"] != null)
                && (filterContext.HttpContext.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = filterContext.HttpContext.Request.Cookies["UserSettings"]["token"];
                string userEMail = filterContext.HttpContext.Request.Cookies["UserSettings"]["email"];

                string apiUrl = "http://localhost:50631/api/clients/email?email=" + userEMail;
                Task<System.Net.Http.HttpResponseMessage> t = Task.Run<System.Net.Http.HttpResponseMessage>(async() => await apiUrl
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .GetAsync());

                bool IsSuccess = false;
                try { IsSuccess = t.Result.IsSuccessStatusCode; }
                catch(Exception e)
                {
                }
                if (IsSuccess)
                {
                    Client c =  Task.Run<Client>(async() => await t.ReceiveJson<Client>()).Result;                    
                    filterContext.Controller.ViewBag.client = c;
                }
                else                
                {                      
                    filterContext.Controller.ViewBag.client = default(Client);
                }
            }
            else
            {               
                filterContext.Controller.ViewBag.client = default(Client);
            }
        }      
    }
}