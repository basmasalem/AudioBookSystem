using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Data;
using Core.Model;
using Core.Service;
using Core.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using X.PagedList;

namespace Core.Web.Controllers
{
    public class PodcastController : BaseController
    {
        private IServiceWrapper _serviceWrapper;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        public PodcastController(IMapper mapper, IServiceWrapper serviceWrapper, IRepositoryWrapper repoWrapper, IMemoryCache cache, IWebHostEnvironment webHostEnvironment, IStringLocalizer<BaseController> localizer, IDataProtectionProvider provider,IConfiguration configuration) : base(configuration,provider, repoWrapper, webHostEnvironment, localizer)
        {
            _serviceWrapper = serviceWrapper;
            _cache = cache;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListPodcast(int page = 1)
        {
            List<PodcastViewModel> Podcasts = new List<PodcastViewModel>();
            //if (_cache.TryGetValue(CacheModel.PodcastCacheWebKey, out List<PodcastViewModel> _Podcasts))
            //{
            //    Podcasts = _Podcasts;
            //}
            //else
            //{
            //    Podcasts = _serviceWrapper.podcastService.GetPodcasts();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(CacheModel.PodcastCacheWebKey, Podcasts, cacheEntryOptions);
            //}
            Podcasts = _serviceWrapper.podcastService.GetPodcasts();
            ViewBag.Pagination = Podcasts.Count > OddItemPerPage;
            IPagedList<PodcastViewModel> model = Podcasts.ToPagedList(page, OddItemPerPage);
            return PartialView("_ListPodcast", model);

        }

        public ActionResult Details(string Id)
        {
            ViewBag.langId = langId;
            if (string.IsNullOrEmpty(Id))
                return RedirectToAction("NotFound", "Home");
            try
            {
                var model = _serviceWrapper.podcastService.GetPodcast(int.Parse(_protector.Unprotect(Id)));
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
        public IActionResult SubscribePodcast(string Id, bool flag)
        {
            int podcastId = int.Parse(_protector.Unprotect(Id));
            PodcastParticipant model;
            model = _serviceWrapper.podcastService.GetPodcastParticipantByClient(podcastId, CurrentUser.UserId);
            if (model == null)
            {
                model = new PodcastParticipant
                {
                    ClientId = CurrentUser.UserId,
                    PodcastId = podcastId,
                    CreatedDate = DateTime.Now
                };
                _serviceWrapper.podcastService.CreatePodcastParticipant(model);
            }
              
            else
            {
                if (flag == true)
                    model.IsDeleted = false;
                else
                    model.IsDeleted = true;
                _serviceWrapper.podcastService.UpdatePodcastParticipant(model);

            }
            _serviceWrapper.podcastService.SavePodcast();

            return Json(1);
        }
        public ActionResult PodcastAudio(string Id, int page = 1)
        {

            if (string.IsNullOrEmpty(Id))
                return RedirectToAction("NotFound", "Home");
            try
            {
                ViewBag.podcastId = Id;
                var PodcastAudios = _serviceWrapper.podcastAudioService.GetAudiosDataByPodcastId(int.Parse(_protector.Unprotect(Id)));
                ViewBag.Pagination = PodcastAudios.Count > EvenItemPerPage;
                var model = PodcastAudios.ToPagedList(page, EvenItemPerPage);
                if (model == null)
                    return RedirectToAction("NotFound", "Home");
                else
                    return PartialView("_PodcastAudioList", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("NotFound", "Home");
            }

        }
        [Authorize]
        public IActionResult AddPodcast()
        {
            var model = new PodcastModel
            {
                Type = PodcastType.Special,
                PublishType = PublishType.Client,
                CreationDate = DateTime.Now,
                CreatedBy = CurrentUser.UserId,
                IsActive=false,
                IsDeleted=false,
                Image="0",
                Attachment="0"
            };
            return View(model);
        }

        public IActionResult SavePodcast(PodcastModel model)
        {
            if (model.StartDate.Value.Date < DateTime.Now.Date)
                return Json(-2);
            var podcast = _mapper.Map<Podcast>(model);
            _serviceWrapper.podcastService.CreatePodcast(podcast);
            _serviceWrapper.podcastService.SavePodcast();
            return Json(1);
        }
        public JsonResult CheckExistingNameAr(string NameAr, int PodcastId)
        {
            var res = _serviceWrapper.podcastService.CheckNameAr(NameAr);
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
            var res = _serviceWrapper.podcastService.CheckNameEn(NameEn);
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
