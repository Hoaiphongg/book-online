using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWeb.Common
{
    [Serializable]
    public class LoginAccount
    {
        public int IdAccount { get; set; }
        public string Username { get; set; }
    }
}