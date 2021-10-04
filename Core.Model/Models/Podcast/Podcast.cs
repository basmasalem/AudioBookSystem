using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Model
{
    public class Podcast : BaseData
    {
        public Podcast()
        {
            PodcastAudios = new HashSet<PodcastAudio>();
            PodcastParticipants = new HashSet<PodcastParticipant>();

        }
        public int PodcastId { get; set; }
        [MaxLength(300)]
        public string Url { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(100)]

        public string Image { get; set; }
        [MaxLength(100)]

        public string Attachment { get; set; }

        [Required, MaxLength(200)]
        public string NameAr { get; set; }
        [Required, MaxLength(200)]
        public string NameEn { get; set; }

        public string DescAr { get; set; }

        public string DescEn { get; set; }

        public int CreatedBy { get; set; }   //user ,client
        public PublishType PublishType { get; set; }
        public PodcastType Type { get; set; }
        public virtual ICollection<PodcastAudio> PodcastAudios { get; set; }
        public virtual ICollection<PodcastParticipant> PodcastParticipants { get; set; }



    }

    public enum PodcastType
    {
        Public = 1,
        Special=2
    }
}
