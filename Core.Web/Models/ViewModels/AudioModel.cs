using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.ViewModels
{
    public class AudioModel
    {

        public int AudioId { get; set; }

        public int? PodcastId { get; set; }

        [Required(ErrorMessage = " ")]
        public int AudioTypeId { get; set; }


        [Required(ErrorMessage = " ")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        public string BookNameAr { get; set; }

        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        public string BookNameEn { get; set; }

        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        public string AuthorNameAr { get; set; }

        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        public string AuthorNameEn { get; set; }


        [Url(ErrorMessage = "رابط المقال غير صحيح")]
        public string ArticleUrl { get; set; }
        [Url(ErrorMessage = "رابط الفيديو غير صحيح")]
        public string VideoUrl { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        [MaxLength(100)]
        public string BookImage { get; set; }

        [MaxLength(100)]
        public string AudioSrc { get; set; }

        public int CreatedBy { get; set; }   //user ,client
        public PublishType PublishType { get; set; }
        public UploadType UploadType { get; set; }




    }
}
