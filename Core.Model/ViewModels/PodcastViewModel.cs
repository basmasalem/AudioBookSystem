using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class PodcastViewModel
    {
        public int PodcastId { get; set; }
        public string NameAr { get; set; }
        public string DescAr { get; set; }
        public string ShortDescAr { get; set; }
        public string NameEn { get; set; }
        public string DescEn { get; set; }
        public string ShortDescEn { get; set; }
        public string Url { get; set; }
        public DateTime? StartDate { get; set; }
        public string Image { get; set; }
        public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }   //user ,client
        public PublishType PublishType { get; set; }
        public PodcastType Type { get; set; }
        public int AudioCount { get; set; }
        public int ParticipantCount { get; set; }
        public string Key { get; set; }

        public List<int> ParticipantIds { get; set; }

    }
}
