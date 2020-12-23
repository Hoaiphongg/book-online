using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookWeb.Models
{
    public class LoginModel
    {
        [Key]
        public int ID { set; get; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Password { set; get; }

        public string Roll { get; set; }
    }
}