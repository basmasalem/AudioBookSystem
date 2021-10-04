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
    public class TagController : BaseController
    {
        private const string TagCacheKey = "Tag-cache-key";
        private readonly IMemoryCache _cache;
        private IRepositoryWrapper _repoWrapper;
        public TagController(IRepositoryWrapper repoWrapper, IMemoryCache cache, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListTag(int page = 1)
        {
            IList<TagDataVM> Tags;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(TagCacheKey, out IList<TagDataVM> _Tags))
            {
                Tags = _Tags;
            }
            else
            {
                Tags = _repoWrapper.tagRepository.ListTags();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(TagCacheKey, Tags, cacheEntryOptions);
            }
            TagVModel model = new TagVModel { Tags = Tags.ToPagedList(page, ItemPerPage), SearchTagVModel = new SearchTagVModel { } };
            return PartialView("_ListTag", model);
        }
        [HttpPost]
        public ActionResult SearchTag(SearchTagVModel model, int page = 1)
        {
            IList<TagDataVM> Tags;

            ViewBag.type = 2;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(TagCacheKey, out IList<TagDataVM> _Articles))
            {
                Tags = _Articles;
            }
            else
            {
                Tags = _repoWrapper.tagRepository.ListTags();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(TagCacheKey, Tags, cacheEntryOptions);
            }
            TagVModel TagVModel = new TagVModel { Tags = Tags.Where(x => (string.IsNullOrEmpty(model.Name) || x.NameAr.Contains(model.Name) || x.NameEn.Contains(model.Name))).ToPagedList(page, 50), SearchTagVModel = model };
            return PartialView("_ListTag", TagVModel);
        }
        public IActionResult AddEdit(int? Id)
        {
            Tag model = new Tag() { Image = "0", IsDeleted = false, CreationDate = DateTime.Now.Date, IsActive = true };
            if (Id.HasValue && Id != 0)
                model = _repoWrapper.tagRepository.Find((int)Id);

            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(Tag model, string oldImage)
        {
            //validate Tag  
            if (!ModelState.IsValid)
                return View("AddEdit", model);

            //save Tag into database   
            try
            {
                if (model.TagId == 0)
                    _repoWrapper.tagRepository.Add(model);
                else
                {
                    if (oldImage != model.Image)
                        RemoveUpload(oldImage, 1);
                    _repoWrapper.tagRepository.Update(model);
                }

                _repoWrapper.tagRepository.Commit();
                _cache.Remove(TagCacheKey);
            }
            catch (Exception ex)
            {
                return Json(-1);

            }
            return Json(1);
        }
        public IActionResult DeleteTag(int id)
        {
            var tag = _repoWrapper.tagRepository.Find(id);
            if(tag.ClientTags.Where(x=>x.IsDeleted!=true).Count()>0)
                return Json("-1");
            _repoWrapper.tagRepository.Delete(tag);
            _repoWrapper.tagRepository.Commit();
            _cache.Remove(TagCacheKey);
            return Json("1");
        }
        public IActionResult ChangeStatus(int id)
        {
            var Tag = _repoWrapper.tagRepository.Find(id);
            Tag.IsActive = !Tag.IsActive;
            _repoWrapper.tagRepository.Update(Tag);
            _repoWrapper.tagRepository.Commit();
            _cache.Remove(TagCacheKey);
            return Json("1");
        }
        public JsonResult CheckExistingNameAr(string NameAr, int TagId)
        {
            var res = _repoWrapper.tagRepository.CheckNameAr(NameAr);
            if (res != null)
            {
                if (res.TagId != TagId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        public JsonResult CheckExistingNameEn(string NameEn, int TagId)
        {
            var res = _repoWrapper.tagRepository.CheckNameEn(NameEn);
            if (res != null)
            {
                if (res.TagId != TagId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
    }
}
