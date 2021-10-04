
using Core.Data;
using Core.Model;
using Core.Service;
using Core.Web.Filters;
using Core.Web.Models;
using Core.Web.Models.ViewModels;
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

namespace Core.Web.Controllers
{
    public class HomeController : BaseController
    {
       
        private readonly IServiceWrapper _serviceWrapper;
        private readonly IMemoryCache _cache;

        public HomeController(IConfiguration configuration, IDataProtectionProvider provider,IStringLocalizer<BaseController> localizer,IServiceWrapper serviceWrapper, IMemoryCache cache, IRepositoryWrapper repoWrapper, IWebHostEnvironment webHostEnvironment) : base(configuration, provider,repoWrapper, webHostEnvironment, localizer)
        {
            this._serviceWrapper = serviceWrapper;
            _cache = cache;
        }

        public IActionResult Index()
        {
            ViewBag.ShowLogin = User.Identity.IsAuthenticated;
         
            ViewBag.AudioDesc = _serviceWrapper.SettingService.GetDesc(langId);
            return View();
        }

       
        public IActionResult GetPodcastSection()
        {
            List<PodcastViewModel> podcasts;
            ViewBag.langId = langId;

            //if (_cache.TryGetValue(CacheModel.PodcastCacheWebKey, out List<PodcastViewModel> _podcasts))
            //{
            //    podcasts = _podcasts;
            //}
            //else
            //{
            //    podcasts = _serviceWrapper.podcastService.GetPodcasts();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(CacheModel.PodcastCacheWebKey, podcasts, cacheEntryOptions);
            //}
            podcasts = _serviceWrapper.podcastService.GetPodcasts();
            return PartialView("_GetPodcastSection", podcasts.Take(ItemSliderInHome).ToList());
        }

        public IActionResult GetCategorySection()
        {
            List<CategoryViewModel> Categories;
            ViewBag.langId = langId;

            //if (_cache.TryGetValue(CacheModel.CategoryCacheWebKey, out List<CategoryViewModel> _Categories))
            //{
            //    Categories = _Categories;
            //}
            //else
            //{
            //    Categories = _serviceWrapper.categoryService.GetCategories();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(CacheModel.CategoryCacheWebKey, Categories, cacheEntryOptions);
            //}
            Categories = _serviceWrapper.categoryService.GetCategories();
            return PartialView("_GetCategorySection",Categories.Take(ItemSliderInHome).ToList());
        }
        public IActionResult GetArticleSection()
        {
            List<ArticleViewModel> articles;

            //if (_cache.TryGetValue(CacheModel.ArticleCacheWebKey, out List<ArticleViewModel> _articles))
            //{
            //    articles = _articles;
            //}
            //else
            //{
            //    articles = _serviceWrapper.articleService.GetArticles();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(CacheModel.ArticleCacheWebKey, articles, cacheEntryOptions);
            //}
            articles = _serviceWrapper.articleService.GetArticles();
            return PartialView("_GetArticleSection", articles.Take(ItemSliderInHome).ToList());
        }
        public IActionResult GetAudioSection()
        {
            ViewBag.langId = langId;
            return PartialView("_GetAudioSection", _serviceWrapper.audioService.GetAudiosData( ItemSliderInHome));
        }

        public IActionResult GetClientSection()
        {
            return PartialView("_GetClientSection", _serviceWrapper.clientService.GetReaders(ItemSliderInHome));
        }

        public IActionResult GetEmail()
        {
            return PartialView("_GetEmail", _serviceWrapper.SettingService.GetEmail());
        }
        public IActionResult GetSocialMedia()
        {
            return PartialView("_GetSocialMedia", _serviceWrapper.SettingService.GetSetting());
        }
        [Authorize]
        public IActionResult GetShareModal(string shareLink, int sharedId, int sharedType)
        {
            ViewBag.ClientPhone = CurrentUser.Phone;
            ShareModel shareModel = new ShareModel() {Url=shareLink,ClintId=CurrentUser.UserId,SharedId= sharedId,SharedType=sharedType};
            return PartialView("~/Views/Shared/_ShareModal.cshtml", shareModel);
        }
        public JsonResult GetCategory()
        {
            var categories = _serviceWrapper.categoryService.GetSelectCategories(langId);
            return Json(categories);
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
