using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = " ")]
        [EmailAddress(ErrorMessage = "البريد الإلكترونى غير صحيح")]
        public string Email { get; set; }
        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class ResetPasswordView
    {
        public string Key { get; set; }
       
        [Required(ErrorMessage = " ")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "علي الاقل 6 احرف او ارقام")]
        public string Password { get; set; }

        [Required(ErrorMessage = " ")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "علي الاقل 6 احرف او ارقام")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "كلمة المرور و تاكيد كلمة المرور غير متطابقين")]
        public string ConfirmPassword { get; set; }
    }
}
