using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class ClientPlayListViewModel
    {
        public int ClientPlaylistId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescAr { get; set; }
        public string DescEn { get; set; }
        public int AudiosCount { get; set; }
        public string Key { get; set; }
        public bool HasAudio { get; set; }
        public List<ClientPlayListAudioViewModel> Audios { get; set; }
    }
    public class ClientPlayListAudioViewModel
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string Image { get; set; }
        public string AudioSrc { get; set; }
    }
}
