using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace General.WebUI.Models
{
    public class LoginModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Lütfen bir kullanıcı adı giriniz.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen bir şifre giriniz.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
