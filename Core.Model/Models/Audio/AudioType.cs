using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
  public class AudioType :BaseData
    {
        public AudioType()
        {
            Audios = new HashSet<Audio>();
        }
        public int AudioTypeId { get; set; }

        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        [Remote("CheckExistingNameAr", "AudioType", AdditionalFields = "AudioTypeId", ErrorMessage = "الاسم موجود بالفعل")]

        public string NameAr { get; set; }

        [Required(ErrorMessage = " "), MaxLength(200, ErrorMessage = "لا يزيد عن 200 حرف")]
        [Remote("CheckExistingNameEn", "AudioType", AdditionalFields = "AudioTypeId", ErrorMessage = "الاسم موجود بالفعل")]
        public string NameEn { get; set; }
        [MaxLength(100)]
        public string Image { get; set; } //icon
        public virtual ICollection<Audio> Audios { get; set; }

    }
}
