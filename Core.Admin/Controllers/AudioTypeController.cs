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
    public class AudioTypeController : BaseController
    {
        private const string AudioTypeCacheKey = "AudioType-cache-key";
        private IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
    

        public AudioTypeController(IMemoryCache cache, IMapper mapper, IRepositoryWrapper repoWrapper, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAudioType(int page = 1)
        {
            IList<AudioType> AudioTypes;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(AudioTypeCacheKey, out IList<AudioType> _AudioTypes))
            {
                AudioTypes = _AudioTypes;
            }
            else
            {
                AudioTypes = _repoWrapper.audioTypeRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(AudioTypeCacheKey, AudioTypes, cacheEntryOptions);
            }
            AudioTypeVModel model = new AudioTypeVModel { AudioTypes = AudioTypes.ToPagedList(page, ItemPerPage), SearchAudioTypeVModel = new SearchAudioTypeVModel { } };
            return PartialView("_ListAudioType", model);
        }
        [HttpPost]
        public ActionResult SearchAudioType(SearchAudioTypeVModel model, int page = 1)
        {
            IList<AudioType> AudioTypes;

            ViewBag.type = 2;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(AudioTypeCacheKey, out IList<AudioType> _AudioTypes))
            {
                AudioTypes = _AudioTypes;
            }
            else
            {
                AudioTypes = _repoWrapper.audioTypeRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(AudioTypeCacheKey, AudioTypes, cacheEntryOptions);
            }
            AudioTypeVModel AudioTypeVModel = new AudioTypeVModel
            {
                AudioTypes = AudioTypes.Where(x => (string.IsNullOrEmpty(model.Name) || x.NameAr.Contains(model.Name) || x.NameEn.Contains(model.Name))).ToPagedList(page, 50),
                SearchAudioTypeVModel = model
            };
            return PartialView("_ListAudioType", AudioTypeVModel);
        }

        public IActionResult AddEdit(int? Id)
        {
            AudioType model = new AudioType() { IsDeleted = false, CreationDate = DateTime.Now.Date, IsActive = true ,Image="0" };
            if (Id.HasValue)
                model = _repoWrapper.audioTypeRepository.Find((int)Id);

            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(AudioType model,string oldImage)
        {
            //validate Podcast  
            if (!ModelState.IsValid)
                return View("AddEdit", model);

            //save Podcast into database   
            try
            {
                if (model.AudioTypeId == 0)
                    _repoWrapper.audioTypeRepository.Add(model);
                else
                {
                    if (oldImage != model.Image)
                        RemoveUpload(oldImage, 1);

                    _repoWrapper.audioTypeRepository.Update(model);
                }

                _repoWrapper.audioTypeRepository.Commit();
                _cache.Remove(AudioTypeCacheKey);
            }
            catch (Exception ex)
            {
                return Json(-1);

            }
            return Json(1);
        }
        public IActionResult DeleteAudioType(int id)
        {
            var model = _repoWrapper.audioTypeRepository.Find(id);
            if (model.Audios.Where(x=>x.IsDeleted!=true).Count() > 0)
                return Json("-1");
            _repoWrapper.audioTypeRepository.Delete(model);
            _repoWrapper.audioTypeRepository.Commit();
            _cache.Remove(AudioTypeCacheKey);
            return Json("1");
        }

        public JsonResult CheckExistingNameAr(string NameAr, int AudioTypeId)
        {
            var res = _repoWrapper.audioTypeRepository.CheckNameAr(NameAr);
            if (res != null)
            {
                if (res.AudioTypeId != AudioTypeId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        public JsonResult CheckExistingNameEn(string NameEn, int AudioTypeId)
        {
            var res = _repoWrapper.audioTypeRepository.CheckNameEn(NameEn);
            if (res != null)
            {
                if (res.AudioTypeId != AudioTypeId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
    }
}
