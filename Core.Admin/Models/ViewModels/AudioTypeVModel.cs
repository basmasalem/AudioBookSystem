using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Models.ViewModels
{
    public class AudioTypeVModel
    {
        public SearchAudioTypeVModel SearchAudioTypeVModel { get; set; }
        public IPagedList<AudioType> AudioTypes { get; set; }
    }

    public class SearchAudioTypeVModel
    {
        public string Name { get; set; }

    }
}
