using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Comptes.Models
{
    public class TokenModel
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}