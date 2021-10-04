using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class PodcastAudioDataVM
    {
        public int PodcastAudioId { get; set; }
        public int AudioId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string BookNameAr { get; set; }
        public string BookNameEn { get; set; }
        public string BookImage { get; set; }
        public string AudioSrc { get; set; }
    }
}
