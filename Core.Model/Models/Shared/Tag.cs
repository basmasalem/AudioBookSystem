using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class Tag:BaseData
    {
        public Tag()
        {
            ClientTags = new HashSet<ClientTag>();
        }
        public int TagId { get; set; }
        [Required(ErrorMessage = " "), MaxLength(150, ErrorMessage = "لا يزيد الاسم يالعربي عن 150")]
        [Remote("CheckExistingNameAr", "Tag", AdditionalFields = "TagId", ErrorMessage = "الاسم موجود بالفعل")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = " "), MaxLength(150, ErrorMessage = "لا يزيد الاسم بالانجليزي عن 150")]
        [Remote("CheckExistingNameEn", "Tag", AdditionalFields = "TagId", ErrorMessage = "الاسم موجود بالفعل")]
        public string NameEn { get; set; }
        [MaxLength(100)]
        public string Image { get; set; }
        public int FollowersCount { get; set; }
        public int ListenersCount { get; set; }
        public int LikesCount { get; set; }
        public int UploadAudiosCount { get; set; }
        public virtual ICollection<ClientTag> ClientTags { get; set; }
    }
}
