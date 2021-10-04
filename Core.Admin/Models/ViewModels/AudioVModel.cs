using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Models.ViewModels
{
    public class AudioVModel
    {
        public SearchAudioVModel SearchAudioVModel { get; set; }
        public IPagedList<Audio> Audios { get; set; }
    }
    public class SearchAudioVModel
    {
        public int CategoryId { get; set; }
        public int AudioTypeId { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public Nullable<bool> Status { get; set; }
    }

}
