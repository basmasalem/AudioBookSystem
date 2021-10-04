using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Models.ViewModels
{
    public class CategoryVModel
    {
        public SearchCategoryVModel SearchCategoryVModel { get; set; }
        public IPagedList<Category> Categories { get; set; }
    }

    public class SearchCategoryVModel
    {
        public string Name { get; set; }

    }

}
