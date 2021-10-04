using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class Article : BaseData
    {
        public int ArticleId { get; set; }
        [Required(ErrorMessage = " "), MaxLength(250, ErrorMessage = "لا يزيد الاسم يالعربي عن 250")]
        [Remote("CheckExistingNameAr", "Article", AdditionalFields = "ArticleId", ErrorMessage = "الاسم موجود بالفعل")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = " "), MaxLength(250, ErrorMessage = "لا يزيد الاسم بالانجليزي عن 250")]
        [Remote("CheckExistingNameEn", "Article", AdditionalFields = "ArticleId", ErrorMessage = "الاسم موجود بالفعل")]
        public string NameEn { get; set; }
        public string DescAr { get; set; }
        public string DescEn { get; set; }
        [Required(ErrorMessage = " "), MaxLength(100, ErrorMessage = "لا يزيد كاتب المقال بالعربي عن 100")]
        public string ArticleOwnerAr { get; set; }
        [Required(ErrorMessage = " "), MaxLength(100, ErrorMessage = "لا يزيد كاتب المقال بالانجليزي عن 100")]
        public string ArticleOwnerEn { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }


    }
}
