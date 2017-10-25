using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebInterface.CustomHelpers
{
    public static class MyHelpers
    {
        public static bool IsAdminConnected() //(this HtmlHelper helper)
        { 
             if ((HttpContext.Current.Request.Cookies["UserSettings"] != null) 
                && (HttpContext.Current.Request.Cookies["UserSettings"]["token"] != null))
            {                
                string userToken = HttpContext.Current.Request.Cookies["UserSettings"]["token"];

                Task<bool> result = Task.Run<bool>(async () => await "http://localhost:50631/api/IsAdmin"
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<bool>());

                return result.Result;
            }
            else
            {
                return false;
            }
        }

        public static bool IsClientConnected() //(this HtmlHelper helper)
        {
            if ((HttpContext.Current.Request.Cookies["UserSettings"] != null)
               && (HttpContext.Current.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = HttpContext.Current.Request.Cookies["UserSettings"]["token"];

                Task<bool> result = Task.Run<bool>(async () => await "http://localhost:50631/api/IsCustomer"
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<bool>());

                return result.Result;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPrestataireConnected() //(this HtmlHelper helper)
        {
            if ((HttpContext.Current.Request.Cookies["UserSettings"] != null)
               && (HttpContext.Current.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = HttpContext.Current.Request.Cookies["UserSettings"]["token"];

                Task<bool> result = Task.Run<bool>(async () => await "http://localhost:50631/api/IsProvider"
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<bool>());

                return result.Result;
            }
            else
            {
                return false;
            }
        }

        public static bool IsTechnicienConnected() //(this HtmlHelper helper)
        {
            if ((HttpContext.Current.Request.Cookies["UserSettings"] != null)
               && (HttpContext.Current.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = HttpContext.Current.Request.Cookies["UserSettings"]["token"];

                Task<bool> result = Task.Run<bool>(async () => await "http://localhost:50631/api/IsTechnical"
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<bool>());

                return result.Result;
            }
            else
            {
                return false;
            }
        }
    }
}