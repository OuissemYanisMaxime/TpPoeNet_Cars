using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
//using System.Web.Mvc;
using API_Comptes.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using System.Web.Http.Description;
using System.Web.Http;

namespace API_Comptes.Controllers
{
    public class UserTesterController : ApiController
    {
        public UserTesterController() : base()
        {            
        }       

        [HttpPost]
        [ResponseType(typeof(bool))]
        [Route("api/IsAdmin")]
        public Boolean IsAdmin() // (IOwinContext actualContext)
        {
            IOwinContext actualContext = HttpContext.Current.GetOwinContext();

            if (actualContext.Authentication.User.Identity.IsAuthenticated)
            {
                var user = actualContext.Authentication.User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if ((s.Count > 0) && (s[0].ToString() == "Admin"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [ResponseType(typeof(bool))]
        [Route("API/IsTechnical")]
        public Boolean IsTechnical() // (IOwinContext actualContext)
        {
            IOwinContext actualContext = HttpContext.Current.GetOwinContext();
            if (actualContext.Authentication.User.Identity.IsAuthenticated)
            {
                var user = actualContext.Authentication.User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());               
                if ((s.Count > 0) && (s[0].ToString() == "Technicien"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [ResponseType(typeof(bool))]
        [Route("API/IsCustomer")]
        public Boolean IsCustomer() // (IOwinContext actualContext)
        {
            IOwinContext actualContext = HttpContext.Current.GetOwinContext();

            actualContext = HttpContext.Current.GetOwinContext();
            if (actualContext.Authentication.User.Identity.IsAuthenticated)
            {
                var user = actualContext.Authentication.User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var ch = user.GetUserId();
                var s = UserManager.GetRoles(user.GetUserId());
                if ((s.Count > 0) && (s[0].ToString() == "Client"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [ResponseType(typeof(bool))]
        [Route("API/IsProvider")]
        public Boolean IsProvider() // (IOwinContext actualContext)
        {
            IOwinContext actualContext = HttpContext.Current.GetOwinContext();

            if (actualContext.Authentication.User.Identity.IsAuthenticated)
            {
                var user = actualContext.Authentication.User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if ((s.Count > 0) && (s[0].ToString() == "Prestataire"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}

