using Core.Admin.Models.ViewModels;
using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Controllers
{
    public class ArticleController : BaseController
    {

        private readonly IMemoryCache _cache;
        private IRepositoryWrapper _repoWrapper;
        public ArticleController(IRepositoryWrapper repoWrapper,IMemoryCache cache, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListArticle(int page = 1)
        {
            IList<Article> Articles;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(CacheModel.ArticleCacheKey, out IList<Article> _Articles))
            {
                Articles = _Articles;
            }
            else
            {
                Articles = _repoWrapper.articleRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(CacheModel.ArticleCacheKey, Articles, cacheEntryOptions);
            }
            ArticleVModel model = new ArticleVModel { Articles = Articles.ToPagedList(page, ItemPerPage), SearchArticleVModel = new SearchArticleVModel { } };
            return PartialView("_ListArticle", model);
        }
        [HttpPost]
        public ActionResult SearchArticle(SearchArticleVModel model, int page = 1)
        {
            IList<Article> Articles;

            ViewBag.type = 2;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(CacheModel.ArticleCacheKey, out IList<Article> _Articles))
            {
                Articles = _Articles;
            }
            else
            {
                Articles = _repoWrapper.articleRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(CacheModel.ArticleCacheKey, Articles, cacheEntryOptions);
            }
            ArticleVModel ArticleVModel = new ArticleVModel { Articles = Articles.Where(x => (string.IsNullOrEmpty(model.Name) || x.NameAr.Contains(model.Name) || x.NameEn.Contains(model.Name))).ToPagedList(page, 50), SearchArticleVModel = model };
            return PartialView("_ListArticle", ArticleVModel);
        }
        public IActionResult AddEdit(int? Id)
        {
            Article model = new Article() {Image="0", IsDeleted = false, CreationDate = DateTime.Now.Date, IsActive = true };
            if (Id.HasValue && Id!=0)
                model = _repoWrapper.articleRepository.Find((int)Id);

            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(Article model, string oldImage)
        {
            //validate Article  
            if (!ModelState.IsValid)
                return View("AddEdit", model);

            //save Article into database   
            try
            {
                if (model.ArticleId == 0)
                    _repoWrapper.articleRepository.Add(model);
                else
                {
                    if (oldImage != model.Image)
                        RemoveUpload(oldImage, 1);

                    _repoWrapper.articleRepository.Update(model);
                }

                _repoWrapper.articleRepository.Commit();
                _cache.Remove(CacheModel.ArticleCacheKey);
                _cache.Remove(CacheModel.ArticleCacheWebKey);

            }
            catch (Exception ex)
            {
                return Json(-1);

            }
            return Json(1);
        }
        public IActionResult DeleteArticle(int id)
        {
            var article = _repoWrapper.articleRepository.Find(id);
            _repoWrapper.articleRepository.Delete(article);
            _repoWrapper.articleRepository.Commit();
            _cache.Remove(CacheModel.ArticleCacheKey);
            _cache.Remove(CacheModel.ArticleCacheWebKey);

            return Json("1");
        }
        public IActionResult ChangeStatus(int id)
        {
            var article = _repoWrapper.articleRepository.Find(id);
            article.IsActive = !article.IsActive;
            _repoWrapper.articleRepository.Update(article);
            _repoWrapper.articleRepository.Commit();
            _cache.Remove(CacheModel.ArticleCacheKey);
            _cache.Remove(CacheModel.ArticleCacheWebKey);

            return Json("1");
        }
        public JsonResult CheckExistingNameAr(string NameAr, int ArticleId)
        {
            var res = _repoWrapper.articleRepository.CheckNameAr(NameAr);
            if (res != null)
            {
                if (res.ArticleId != ArticleId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        public JsonResult CheckExistingNameEn(string NameEn, int ArticleId)
        {
            var res = _repoWrapper.articleRepository.CheckNameEn(NameEn);
            if (res != null)
            {
                if (res.ArticleId != ArticleId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
    }
}
