using System.Web;
using System.Web.Mvc;
using WebInterface.Filters;

namespace WebInterface
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CookieUserMail());
        }
    }
}
