using AutoMapper;
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
    public class CategoryController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        private IRepositoryWrapper _repoWrapper;
        public CategoryController(  IRepositoryWrapper repoWrapper, IMemoryCache cache, IMapper mapper, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListCategory(int page = 1)
        {
            IList<Category> Categories;

            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(CacheModel.CategoryCacheKey, out IList<Category> _Categories))
            {
                Categories = _Categories;
            }
            else
            {
                Categories = _repoWrapper.categoryRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(CacheModel.CategoryCacheKey, Categories, cacheEntryOptions);

            }
            CategoryVModel model = new CategoryVModel { Categories = Categories.ToPagedList(page, ItemPerPage), SearchCategoryVModel = new SearchCategoryVModel { } };
            return PartialView("_ListCategory", model);
        }
        [HttpPost]
        public ActionResult SearchCategory(SearchCategoryVModel model, int page = 1)
        {
            IList<Category> Categories;

            ViewBag.type = 2;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(CacheModel.CategoryCacheKey, out IList<Category> _Categories))
            {
                Categories = _Categories;
            }
            else
            {
                Categories = _repoWrapper.categoryRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(CacheModel.CategoryCacheKey, Categories, cacheEntryOptions);
            }
            CategoryVModel CategoryVModel = new CategoryVModel { Categories = Categories.Where(x => (string.IsNullOrEmpty(model.Name) || x.NameAr.Contains(model.Name) || x.NameEn.Contains(model.Name))).ToPagedList(page, 50),  SearchCategoryVModel = model };
            return PartialView("_ListCategory", CategoryVModel);
        }
        public IActionResult AddEdit(int? Id)
        {
            Category model = new Category() {Image="0", IsDeleted = false, CreationDate = DateTime.Now.Date, IsActive = true,CreatedBy=CurrentUser.UserId };
            if (Id.HasValue)
                model = _repoWrapper.categoryRepository.Find((int)Id);
            
            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(Category model, string oldImage)
        {
            //validate Category  
            if (!ModelState.IsValid)
                return View("AddEdit", model);

            //save Category into database   
            try
            {
                if (model.CategoryId == 0)
                    _repoWrapper.categoryRepository.Add(model);
                else
                {
                    if (oldImage!=null&&oldImage != model.Image)
                        RemoveUpload(oldImage, 1);
                    _repoWrapper.categoryRepository.Update(model);
                }

                _repoWrapper.categoryRepository.Commit();
                _cache.Remove(CacheModel.CategoryCacheKey);
                _cache.Remove(CacheModel.CategoryCacheWebKey);
                if (_cache.TryGetValue(CacheModel.CategoryCacheWebKey, out IPagedList<CategoryViewModel> _Categories))
                {
                    int h = 1;
                }
            }
            catch (Exception ex)
            {
                return Json(-1);

            }
            return Json(1);
        }
        public IActionResult DeleteCategory(int id)
        {
            var category = _repoWrapper.categoryRepository.Find(id);
            if (category.Audios.Where(x=>x.IsDeleted!=true).Count() > 0)
                return Json("-1");
            _repoWrapper.categoryRepository.Delete(category);
             _repoWrapper.categoryRepository.Commit();
            _cache.Remove(CacheModel.CategoryCacheKey);
            _cache.Remove(CacheModel.CategoryCacheWebKey);
            return Json("1");
        }
        public IActionResult ChangeStatus(int id)
        {
            var Category = _repoWrapper.categoryRepository.Find(id);
            Category.IsActive = !Category.IsActive;
            _repoWrapper.categoryRepository.Update(Category);
             _repoWrapper.categoryRepository.Commit();
            _cache.Remove(CacheModel.CategoryCacheKey);
            _cache.Remove(CacheModel.CategoryCacheWebKey);
            return Json("1");
        }
        public JsonResult CheckExistingNameAr(string NameAr, int CategoryId)
        {
            var res = _repoWrapper.categoryRepository.CheckNameAr(NameAr);
            if (res != null)
            {
                if (res.CategoryId != CategoryId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        public JsonResult CheckExistingNameEn(string NameEn, int CategoryId)
        {
            var res = _repoWrapper.categoryRepository.CheckNameEn(NameEn);
            if (res != null)
            {
                if (res.CategoryId != CategoryId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
    }
}
