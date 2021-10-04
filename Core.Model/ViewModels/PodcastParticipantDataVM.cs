using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class PodcastParticipantDataVM
    {
        public int PodcastParticipantId { get; set; }
        public string ClientName { get; set; }
        public string ClientImg { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
