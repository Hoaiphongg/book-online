 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookWeb.Areas.Admin.Models
{
    public class LoginAdmin
    {
        [Required(ErrorMessage = "Moi nhap Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Moi nhap Password")]
        public string Password { get; set; }

        public string GroupID { get; set; }
    }
}