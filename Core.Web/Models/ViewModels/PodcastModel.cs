using Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.ViewModels
{
    public class PodcastModel
    {
        public int PodcastId { get; set; }
        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "No more than 200 characters")]
        [Remote("CheckExistingNameAr", "Podcast", AdditionalFields = "PodcastId", ErrorMessage = "Arabic name already exists")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = " ")]
        public string DescAr { get; set; }
        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "No more than 200 characters")]
        [Remote("CheckExistingNameEn", "Podcast", AdditionalFields = "PodcastId", ErrorMessage = "English name already exists")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = " ")]
        public string DescEn { get; set; }
        [Required(ErrorMessage = " "), MaxLength(300, ErrorMessage = "No more than 300 characters"), Url(ErrorMessage = "The link is incorrect")]
        public string Url { get; set; }
        [Required(ErrorMessage = " ")]
        public DateTime? StartDate { get; set; }
        public string Image { get; set; }
        public string Attachment { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int CreatedBy { get; set; }   //user ,client
        public PublishType PublishType { get; set; }
        [Required(ErrorMessage = " ")]
        public PodcastType Type { get; set; }
    }
}
