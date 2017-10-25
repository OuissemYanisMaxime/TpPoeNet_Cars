using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInterface.Models
{
    public class TokenModel
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public TokenModel(string gt, string user, string pwd)
        {
            grant_type = gt;
            username = user;
            password = pwd;
        }
    }
}