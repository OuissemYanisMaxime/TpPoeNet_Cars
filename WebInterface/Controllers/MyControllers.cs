using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebInterface.Controllers
{
    public class MyControllers
    {
        public async Task<TR> InterrogerComptes<TR,T>(string url, T elt)
        {
            if ((HttpContext.Current.Request.Cookies["UserSettings"] != null)
               && (HttpContext.Current.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = HttpContext.Current.Request.Cookies["UserSettings"]["token"];

                url = "http://localhost:50631/" + url;
                Task<TR> result = Task.Run<TR>(async () => await url
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<TR>());

                return result.Result;
            }
            else
            {
                return default(TR);
            }
        }

        public async Task<TR> InterrogerPrestation<TR, T>(string url, T elt)
        {
            if ((HttpContext.Current.Request.Cookies["UserSettings"] != null)
               && (HttpContext.Current.Request.Cookies["UserSettings"]["token"] != null))
            {
                string userToken = HttpContext.Current.Request.Cookies["UserSettings"]["token"];

                url = "http://localhost:52467/" + url;
                Task<TR> result = Task.Run<TR>(async () => await url
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<TR>());

                return result.Result;
            }
            else
            {
                return default(TR);
            }
        }
    }
}
