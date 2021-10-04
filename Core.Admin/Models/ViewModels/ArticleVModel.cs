using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Models.ViewModels
{
    public class ArticleVModel
    {
        public SearchArticleVModel SearchArticleVModel { get; set; }
        public IPagedList<Article> Articles { get; set; }
    }

    public class SearchArticleVModel
    {
        public string Name { get; set; }

    }
}
