
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
   public class Audio :BaseData
    {
        public Audio()
        {
            PodcastAudios = new HashSet<PodcastAudio>();
            PlaylistAudios = new HashSet<PlaylistAudio>();
            AudioActions = new HashSet<AudioAction>();
            AudioComments = new HashSet<AudioComment>();

        }
        public int AudioId { get; set; }

        [ForeignKey("AudioType")]
        public int AudioTypeId { get; set; }
       
        [ForeignKey("Category")]
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

        public bool ApproveStatus { get; set; }  


        public virtual AudioType AudioType { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<PlaylistAudio> PlaylistAudios { get; set; }
        public virtual ICollection<AudioAction> AudioActions { get; set; }
        public virtual ICollection<PodcastAudio> PodcastAudios { get; set; }
        public virtual ICollection<AudioComment> AudioComments { get; set; }

    }

    public enum PublishType
    {
        Admin=1,
        Client=2
    }

    public enum UploadType
    {
        Upload = 1,
        Record = 2
    }
}
