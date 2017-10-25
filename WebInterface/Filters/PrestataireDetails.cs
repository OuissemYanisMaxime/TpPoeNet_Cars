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

                string apiUrl = "http://localhost:50631/api/prestataires/email/?email=" + userEMail;
                Task<Prestataire> p = Task.Run<Prestataire>(async() => await apiUrl
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .GetAsync().ReceiveJson<Prestataire>());

                if (p.Result != null)
                    filterContext.Controller.ViewBag.user = p.Result;
            }
            else
            {
                Prestataire p = new Prestataire();
                filterContext.Controller.ViewBag.prestataire = p;
            }
        }      
    }
}