using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Core.Model
{
   public class Category :BaseData
    {
        public Category()
        {
            Audios = new HashSet<Audio>();
        }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        [Remote("CheckExistingNameAr", "Category", AdditionalFields = "CategoryId", ErrorMessage = "الاسم موجود بالفعل")]
        public string NameAr { get; set; }
       
        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        [Remote("CheckExistingNameEn", "Category", AdditionalFields = "CategoryId", ErrorMessage = "الاسم موجود بالفعل")]
        public string NameEn { get; set; }

        [MaxLength(100)]
        public string Image { get; set; } 


        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Audio> Audios { get; set; }
    }
}
