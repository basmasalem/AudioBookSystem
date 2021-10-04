using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.ViewModels
{
    public class EditProfileModel
    {
        public int ClientId { get; set; }
        public string Key { get; set; }

        [Required(ErrorMessage = " ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = " ")]
        public string FullNameEn { get; set; }
        [Required(ErrorMessage = " ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " ")]
        public string LastName { get; set; }

        public string HiddenOldPassword { get; set; }


        [Required(ErrorMessage = " ")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "علي الاقل 6 احرف او ارقام")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = " ")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "علي الاقل 6 احرف او ارقام")]
        public string NewPassword { get; set; }


        [Required(ErrorMessage = " ")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "علي الاقل 6 احرف او ارقام")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "كلمة المرور و تاكيد كلمة المرور غير متطابقين")]
        public string ConfirmNewPassword { get; set; }

        [Required(ErrorMessage = " ")]
        public string Email { get; set; }
        [Required(ErrorMessage = " ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = " ")]
        [Range(1, 10000)]
        public int? CityId { get; set; }

        public string Image { get; set; }
    }
}
