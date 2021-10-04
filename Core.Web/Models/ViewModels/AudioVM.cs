using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Web.Models.ViewModels
{
    public class AudioVM
    {
        public AudioSearchVM SearchAudio { get; set; }
        public IPagedList<AudioViewModel> Audios { get; set; }
    }
    public class  AudioSearchVM
    {
        public string Name { get; set; }
        public string ClientKey { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }

    }
}
