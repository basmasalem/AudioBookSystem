using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class Setting
    {
        public int SettingId { get; set; }
        [MaxLength(200,ErrorMessage ="لا يزيد العنوان بالعربي عن 200 حرف")]
        public string AddressAr { get; set; }
        [MaxLength(200, ErrorMessage = "لا يزيد العنوان بالانجليزي عن 200 حرف")]
        public string AddressEn { get; set; }
        public string DescAr { get; set; }
        public string DescEn { get; set; }
        public string TermsAndConditionsAr { get; set; }
        public string TermsAndConditionsEn { get; set; }
        public string PrivacyAr { get; set; }
        public string PrivacyEn { get; set; }


        [MaxLength(50, ErrorMessage = "لا يزيد رقم الجوال عن 50 حرف")]
        public string Phone { get; set; }
        [MaxLength(150, ErrorMessage = "لا يزيد البريد الإلكتروني عن 150 حرف"),EmailAddress(ErrorMessage ="البريد الإلكتروني غير صحيح")]
        public string Email { get; set; }
        [MaxLength(200, ErrorMessage = "لا يزيد حساب الفيس بوك عن 200 حرف"), Url(ErrorMessage = "رابط الفيس بوك غير صحيح")]

        public string FacebookUrl { get; set; }
        [MaxLength(200, ErrorMessage = "لا يزيد حساب الانستجرام عن 200 حرف"), Url(ErrorMessage = "رابط الانستجرام غير صحيح")]
        public string InstgramUrl { get; set; }
        [MaxLength(50, ErrorMessage = "لا يزيد الواتس اب عن 50 حرف")]
        public string WhatsUp { get; set; }
        [MaxLength(200, ErrorMessage = "لا يزيد حساب اليوتيوب عن 200 حرف"), Url(ErrorMessage = "رابط اليوتيوب غير صحيح")]
        public string YouTubeUrl { get; set; }
        [MaxLength(200, ErrorMessage = "لا يزيد حساب التويتر عن 200 حرف"), Url(ErrorMessage = "رابط التويتر غير صحيح")]
        public string TwitterUrl { get; set; }
        [MaxLength(200, ErrorMessage = "لا يزيد حساب جوجل بلس عن 200 حرف"), Url(ErrorMessage = "رابط جوجل بلس غير صحيح")]
        public string GooglePlusUrl { get; set; }

    }
}
