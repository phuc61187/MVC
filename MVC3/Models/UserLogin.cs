using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC3.Models {
    public class UserLogin {
        //[Key]
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Chưa nhập tài khoản")]
        public string UserName { get; set; }

        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage ="Bạn chưa nhập Password")]
        public string Password { get; set; }

    }
}