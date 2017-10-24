using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebInterface.Models
{
    public class TokenResultModel
    {        
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string issued { get; set; }
        public DateTime expires { get; set; }
    }
}