using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    public class PodcastAudio
    {
        public int PodcastAudioId { get; set; }
        [ForeignKey("Podcast")]
        public int PodcastId { get; set; }
        [ForeignKey("Audio")]
        public int AudioId { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }


        public virtual Podcast Podcast { get; set; }
        public virtual Audio Audio { get; set; }
    }
}
