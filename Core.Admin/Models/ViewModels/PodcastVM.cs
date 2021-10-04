using Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Admin.Models.ViewModels
{
    public class PodcastVM
    {
        public int PodcastId { get; set; }
        [Required(ErrorMessage =" "), MaxLength(200,ErrorMessage ="لا يزيد عن 200 حرف")]
        [Remote("CheckExistingNameAr", "Podcast", AdditionalFields = "PodcastId", ErrorMessage = "الاسم بالعربي موجود بالفعل")]
        public string NameAr { get; set; }
        public string DescAr { get; set; }
        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        [Remote("CheckExistingNameEn", "Podcast", AdditionalFields = "PodcastId", ErrorMessage = "الاسم بالانجليزي موجود بالفعل")]
        public string NameEn { get; set; }
        public string DescEn { get; set; }
        [Required(ErrorMessage = " "), MaxLength(300, ErrorMessage = "لا يزيد عن 300 حرف"), Url(ErrorMessage = "الرابط  غير صحيح")]
        public string Url { get; set; }
        [Required(ErrorMessage = " ")]
        public DateTime? StartDate { get; set; }
        public string Image { get; set; }
        public string oldImage { get; set; }
        public string Attachment { get; set; }
        public string OldAttach { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }   //user ,client
        public PublishType PublishType { get; set; }
        [Required(ErrorMessage = " ")]
        public PodcastType Type { get; set; }


    }
}
