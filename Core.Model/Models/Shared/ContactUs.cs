using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
   public class ContactUs :BaseData
   {
        public int ContactUsId { get; set; }
        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        public string Name { get; set; }
        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        public string Email { get; set; }

        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        public string Title { get; set; }

        [Required(ErrorMessage = " ")]
        public string Message { get; set; }
    }
}
