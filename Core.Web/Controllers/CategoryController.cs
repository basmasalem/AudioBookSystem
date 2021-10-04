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
    public class CategoryController : BaseController
    {

        private IServiceWrapper _serviceWrapper;
        private readonly IMemoryCache _cache;

        public CategoryController(IConfiguration configuration, IServiceWrapper serviceWrapper, IRepositoryWrapper repoWrapper, IMemoryCache cache, IWebHostEnvironment webHostEnvironment, IStringLocalizer<BaseController> localizer,IDataProtectionProvider provider) : base(configuration, provider,repoWrapper, webHostEnvironment, localizer)
        {
            _serviceWrapper = serviceWrapper;
            _cache = cache;
        }


        public IActionResult Index()
        {   
            return View();
        }

        public ActionResult CategoryList(int page = 1)
        {
            IPagedList<CategoryViewModel> Categories;
            ViewBag.langId = langId;
            //if (_cache.TryGetValue(CacheModel.CategoryCacheWebKey, out IPagedList<CategoryViewModel> _Categories))
            //{
            //    Categories = _Categories;
            //}
            //else
            //{
            //    Categories = _serviceWrapper.categoryService.GetCategories().ToPagedList();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(CacheModel.CategoryCacheWebKey, Categories, cacheEntryOptions);
            //}
            Categories = _serviceWrapper.categoryService.GetCategories().ToPagedList();
            ViewBag.Pagination = Categories.Count > OddItemPerPage;
            return PartialView("_CategoryList", Categories.ToPagedList(page, OddItemPerPage));
        }

        public ActionResult Sound(string Id)
        {
            if (string.IsNullOrEmpty( Id ))
               return RedirectToAction("NotFound", "Home");
            try
            {
                string Key = _protector.Unprotect(Id);
                int id = int.Parse(Key);
                var model = _serviceWrapper.categoryService.GetCategory(id);
                if (model == null)
                    return RedirectToAction("NotFound", "Home");
                else
                {
                    ViewBag.Name = langId == 1 ? model.NameAr : model.NameEn;
                    return View(id);
                }
                 
            }
            catch(Exception ex)
            {
                return RedirectToAction("NotFound", "Home");
            }
         
        }

        public IActionResult ListSound(int Id, int page = 1)
        {
            ViewBag.Id = Id;
            ViewBag.langId = langId;
            var data = _serviceWrapper.categoryService.GetAudiosData(Id);
            ViewBag.Pagination = data.Count > OddItemPerPage;
            IPagedList<AudioViewModel> model =data.ToPagedList(page, OddItemPerPage);
            return PartialView("_ListSound", model);

        }
    }
}
