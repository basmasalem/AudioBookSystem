using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Model
{
    public class PodcastParticipant
    {
        public int PodcastParticipantId { get; set; }
        [ForeignKey("Podcast")]
        public int PodcastId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Podcast Podcast { get; set; }
        public virtual Client Client { get; set; }
    }
}
