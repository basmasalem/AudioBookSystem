using Core.Data;
using Core.Model;
using Core.Service;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Web.Controllers
{  
    public class ArticleController : BaseController
    {
        private IServiceWrapper _serviceWrapper;
        private readonly IMemoryCache _cache;


        public ArticleController(IServiceWrapper serviceWrapper, IRepositoryWrapper repoWrapper, IMemoryCache cache, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, IStringLocalizer<BaseController> localizer, IDataProtectionProvider provider) : base(configuration,provider, repoWrapper, webHostEnvironment, localizer)
        {
            _serviceWrapper = serviceWrapper;
            _cache = cache;
        }

        public IActionResult Index()
        {
       
            return View();
        }
        public IActionResult ListArticle(int page = 1)
        {
            List<ArticleViewModel> Articles = new List<ArticleViewModel>();
            //if (_cache.TryGetValue(CacheModel.ArticleCacheWebKey, out List<ArticleViewModel> _Articles) )
            //{
            //    Articles = _Articles;
            //}
            //else
            //{
            //    Articles = _serviceWrapper.articleService.GetArticles();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(CacheModel.ArticleCacheWebKey, Articles, cacheEntryOptions);
            //}
            Articles = _serviceWrapper.articleService.GetArticles();
            ViewBag.Pagination = Articles.Count > OddItemPerPage;
            IPagedList<ArticleViewModel> model = Articles.ToPagedList(page, OddItemPerPage);
            return PartialView("_ListArticle", model);

        }

        public ActionResult Details(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return RedirectToAction("NotFound", "Home");
            try
            {
                string Key = _protector.Unprotect(Id);
                int id = int.Parse(Key);
                var model = _serviceWrapper.articleService.GetArticle(id);
                if (model == null)
                    return RedirectToAction("NotFound", "Home");
                else
                    return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("NotFound", "Home");
            }

        }
    }
}
