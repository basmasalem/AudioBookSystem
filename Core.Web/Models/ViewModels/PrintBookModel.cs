using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.ViewModels
{
    public class PrintBookModel
    {
        public int PrintBookId { get; set; }
        [Required(ErrorMessage =" "),MaxLength(100,ErrorMessage = "No more than 100 characters")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = " "), MaxLength(20, ErrorMessage = "No more than 20 characters"), RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{6})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = " "), MaxLength(500, ErrorMessage = "No more than 500 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = " "), MaxLength(100, ErrorMessage = "No more than 100 characters"), EmailAddress(ErrorMessage = "Not a valid Email")]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
