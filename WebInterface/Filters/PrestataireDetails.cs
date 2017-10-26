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
    public class PrestataireDetails : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((filterContext.HttpContext.Request.Cookies["UserSettings"] != null)
                && (filterContext.HttpContext.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = filterContext.HttpContext.Request.Cookies["UserSettings"]["token"];
                string userEMail = filterContext.HttpContext.Request.Cookies["UserSettings"]["email"];

                string apiUrl = "http://localhost:50631/api/prestataires/email?email=" + userEMail;
                Task<System.Net.Http.HttpResponseMessage> t = Task.Run<System.Net.Http.HttpResponseMessage>(async () => await apiUrl
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .GetAsync());

                bool IsSuccess = false;
                try { IsSuccess = t.Result.IsSuccessStatusCode; }
                catch (Exception e)
                {
                }
                if (IsSuccess)
                {
                    Prestataire p = Task.Run<Prestataire>(async () => await t.ReceiveJson<Prestataire>()).Result;
                    filterContext.Controller.ViewBag.prestataire = p;
                }
                else
                {
                    filterContext.Controller.ViewBag.prestataire = default(Prestataire);
                }
            }
            else
            {                
                filterContext.Controller.ViewBag.prestataire = default(Client);
            }
        }      
    }
}