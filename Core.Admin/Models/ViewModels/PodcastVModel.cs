using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Models.ViewModels
{
    public class PodcastVModel
    {
        public SearchPodcastVModel SearchPodcastVModel { get; set; }
        public IPagedList<PodcastViewModel> Podcasts { get; set; }
    }
    public class SearchPodcastVModel
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public PodcastType? Type { get; set; }
    }
}
