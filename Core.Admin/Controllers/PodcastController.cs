using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Admin.Models.ViewModels;
using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using X.PagedList;

namespace Core.Admin.Controllers
{
    public class PodcastController : BaseController
    {
       
        private IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        public PodcastController(IRepositoryWrapper repoWrapper,IMemoryCache cache, IMapper mapper,IWebHostEnvironment webHostEnvironment) :base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Record()
        {
            return View();
        }
        public IActionResult ListPodcast(int page=1)
        {
            IList<PodcastViewModel> Podcasts;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            //if (_cache.TryGetValue(CacheModel.PodcastCacheKey , out IList <PodcastViewModel> _Podcasts))
            //{
            //    Podcasts= _Podcasts;
            //}
            //else
            //{
            //    Podcasts = _repoWrapper.podcastRepository.GetAllPodcastData();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(CacheModel.PodcastCacheKey , Podcasts, cacheEntryOptions);
            //}
            Podcasts = _repoWrapper.podcastRepository.GetAllPodcastData();
            PodcastVModel model = new PodcastVModel { Podcasts= Podcasts.ToPagedList(page, ItemPerPage), SearchPodcastVModel = new SearchPodcastVModel { } };
            return PartialView("_ListPodcast", model);
        }
        [HttpPost]
        public ActionResult SearchPodcast(SearchPodcastVModel model, int page = 1)
        {
            IList<PodcastViewModel> Podcasts;

            ViewBag.type = 2;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(CacheModel.PodcastCacheKey , out IList<PodcastViewModel> _Podcasts))
            {
                Podcasts = _Podcasts;
            }
            else
            {
                Podcasts = _repoWrapper.podcastRepository.GetAllPodcastData();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(CacheModel.PodcastCacheKey , Podcasts, cacheEntryOptions);
            }
            PodcastVModel podcast = new PodcastVModel { Podcasts = Podcasts.Where(x=> (string.IsNullOrEmpty(model.Name)||x.NameAr.Contains(model.Name)||x.NameEn.Contains(model.Name)) &&(model.Type==null||x.Type==model.Type) &&(model.StartDate==null||x.StartDate.Value.Date>=model.StartDate.Value.Date)).ToPagedList(page, 50), SearchPodcastVModel = model };
            return PartialView("_ListPodcast", podcast);
        }
        public IActionResult AddEdit(int? Id)
        {
            PodcastVM model = new PodcastVM() { IsDeleted=false ,Image="0",Attachment="0",CreationDate=DateTime.Now.Date,IsActive=true,CreatedBy=CurrentUser.UserId,PublishType=PublishType.Admin};
            if(Id.HasValue && Id!=0)
            {
                var podcast = _repoWrapper.podcastRepository.Find((int)Id);
                model = _mapper.Map<PodcastVM>(podcast);
                model.oldImage = model.Image;
                model.OldAttach = model.Attachment;

            }
            return View(model);
        }
        [HttpPost]
        public IActionResult AddEdit(PodcastVM model)
        {
            //validate Podcast  
            if (!ModelState.IsValid)
                return View("AddEdit", model);
            if (model.PodcastId==0 &&model.StartDate.Value.Date < DateTime.Now.Date)
                return Json(-2);
      
            //save Podcast into database   
            try
            {
                var podcast = _mapper.Map<Podcast>(model);

                if (model.PodcastId == 0)
                {
                    _repoWrapper.podcastRepository.Add(podcast);
                }
                else
                {
                    if (model.oldImage != model.Image)
                        RemoveUpload(model.oldImage, 1);
                    if (model.OldAttach != model.Attachment)
                        RemoveUpload(model.OldAttach, 2);
                    _repoWrapper.podcastRepository.Update(podcast);
                }
                _repoWrapper.podcastRepository.Commit();
                _cache.Remove(CacheModel.PodcastCacheKey );
                _cache.Remove(CacheModel.PodcastCacheWebKey);

            }
            catch (Exception ex)
            {
                return Json(-1);

            }
            return Json(1);
        }

        public IActionResult Details(int? Id)
        {
            if (!Id.HasValue && Id == 0)
                return RedirectToAction("NotFound", "Home");
            var model = _repoWrapper.podcastRepository.GetPodcastData((int)Id);
            if (model == null)
                return RedirectToAction("NotFound", "Home");
            return View(model);
        }
        public IActionResult GetPodcastAudio(int id)
        {
            var model = _repoWrapper.podcastAudioRepository.GetAllPodcastAudioData(id);
            return PartialView("_GetPodcastAudio", model);
        }
        public IActionResult GetPodcastAudioSrc(int id)
        {
            var model = _repoWrapper.podcastAudioRepository.GetPodcastAudioData(id);
            return PartialView("_GetPodcastAudioSrc", model);
        }
        public IActionResult GetPodcastParticipant(int id)
        {
            var model = _repoWrapper.podcastParticipantRepository.GetAllPodcastParticipantData(id);
            return PartialView("_GetPodcastParticipant", model);
        }
        public IActionResult DeletePodcast(int id)
        {
            var podcast = _repoWrapper.podcastRepository.Find(id);
            if (podcast.PodcastAudios.Where(x=>x.IsDeleted!=true).Count() > 0 || podcast.PodcastParticipants.Where(x => x.IsDeleted != true).Count() > 0)
                return Json("-1");
            _repoWrapper.podcastRepository.Delete(podcast);
            _repoWrapper.podcastRepository.Commit();
            _cache.Remove(CacheModel.PodcastCacheKey );
            _cache.Remove(CacheModel.PodcastCacheWebKey);
            return Json("1");
        }
        public IActionResult ChangeStatus(int id)
        {
            var podcast = _repoWrapper.podcastRepository.Find(id);
            podcast.IsActive = !podcast.IsActive;
            if(podcast.Type==PodcastType.Special && podcast.PublishType==PublishType.Client)
            {
               var Participant= _repoWrapper.podcastParticipantRepository.List().FirstOrDefault(x => x.ClientId == podcast.CreatedBy && x.PodcastId==podcast.PodcastId);
                if(Participant==null)
                {
                    _repoWrapper.podcastParticipantRepository.Add(new PodcastParticipant
                    {
                        ClientId=podcast.CreatedBy,
                        CreatedDate=DateTime.Now,
                        IsDeleted=false,
                        PodcastId=podcast.PodcastId
                    });
                }
            }
            _repoWrapper.podcastRepository.Update(podcast);
            _repoWrapper.podcastRepository.Commit();
            _cache.Remove(CacheModel.PodcastCacheKey );
            _cache.Remove(CacheModel.PodcastCacheWebKey); 
            return Json("1");
        }
        public JsonResult CheckExistingNameAr(string NameAr, int PodcastId)
        {
            var res = _repoWrapper.podcastRepository.CheckNameAr(NameAr);
            if (res != null)
            {
                if (res.PodcastId != PodcastId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        public JsonResult CheckExistingNameEn(string NameEn, int PodcastId)
        {
            var res = _repoWrapper.podcastRepository.CheckNameEn(NameEn);
            if (res != null)
            {
                if (res.PodcastId != PodcastId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
    }
}
