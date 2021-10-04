using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Models.ViewModels
{
    public class TagVModel
    {
        public SearchTagVModel SearchTagVModel { get; set; }
        public IPagedList<TagDataVM> Tags { get; set; }
    }

    public class SearchTagVModel
    {
        public string Name { get; set; }

    }
}
