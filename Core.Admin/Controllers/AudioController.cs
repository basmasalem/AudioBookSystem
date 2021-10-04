using AutoMapper;
using Core.Admin.Models.ViewModels;
using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Admin.Controllers
{
    public class AudioController : BaseController
    {
        private const string AudioCacheKey = "Audio-cache-key";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private IRepositoryWrapper _repoWrapper;

        public AudioController(IRepositoryWrapper repoWrapper,IMemoryCache cache, IMapper mapper, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _cache = cache;
        }

        public IActionResult Index()
        {
            ViewBag.AudioTypes = (List<SelectListItem>)_repoWrapper.audioTypeRepository.List().Select(x => new SelectListItem { Value = x.AudioTypeId.ToString(), Text = x.NameAr }).ToList();
            ViewBag.Categories = (List<SelectListItem>)_repoWrapper.categoryRepository.List().Select(x => new SelectListItem { Value = x.CategoryId.ToString(), Text = x.NameAr }).ToList();
            return View();
        }

        public IActionResult ListAudio(int page = 1)
        {
            IList<Audio> Audios;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            //if (_cache.TryGetValue(AudioCacheKey, out IList<Audio> _Audios))
            //{
            //    Audios = _Audios;
            //}
            //else
            //{
            //    Audios = _repoWrapper.audioRepository.List().ToList();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(AudioCacheKey, Audios, cacheEntryOptions);
            //}
            Audios = _repoWrapper.audioRepository.List().ToList();
            AudioVModel model = new AudioVModel { Audios = Audios.ToPagedList(page, ItemPerPage), SearchAudioVModel = new SearchAudioVModel { } };
            return PartialView("_ListAudio", model);
        }

        [HttpPost]
        public ActionResult SearchAudio(SearchAudioVModel model, int page = 1)
        {
            IList<Audio> Audios;

            ViewBag.type = 2;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(AudioCacheKey, out IList<Audio> _Audios))
            {
                Audios = _Audios;
            }
            else
            {
                Audios = _repoWrapper.audioRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(AudioCacheKey, Audios, cacheEntryOptions);
            }

            AudioVModel AudioVModel = new AudioVModel { Audios = Audios.Where(x => (string.IsNullOrEmpty(model.AuthorName) || x.AuthorNameAr.Contains(model.AuthorName) || x.AuthorNameEn.Contains(model.AuthorName)) &&
            (string.IsNullOrEmpty(model.BookName) || x.BookNameAr.Contains(model.BookName) || x.BookNameEn.Contains(model.BookName)) && (model.CategoryId==0||x.CategoryId==model.CategoryId) &&
            (model.AudioTypeId == 0 || x.AudioTypeId == model.AudioTypeId) && (model.Status==null || x.ApproveStatus==model.Status)).ToPagedList(page, 50), SearchAudioVModel = model };
            return PartialView("_ListAudio", AudioVModel);
        }

        public IActionResult AddEdit(int id=0)
        {
            ViewBag.AudioTypes = _repoWrapper.audioTypeRepository.List().ToList();
            ViewBag.Categories= (List<SelectListItem>)_repoWrapper.categoryRepository.List().Select(x => new SelectListItem { Value = x.CategoryId.ToString(), Text = x.NameAr }).ToList();
            var model = new Audio {BookImage="0" ,AudioSrc="0",AudioTypeId=new List<AudioType>(ViewBag.AudioTypes).FirstOrDefault().AudioTypeId, CreationDate=DateTime.Now,CreatedBy=CurrentUser.UserId,IsActive=true,PublishType=PublishType.Admin,UploadType=UploadType.Upload, ApproveStatus = true };
            if (id != 0)
            {
                model = _repoWrapper.audioRepository.Find(id);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult AddEdit(Audio model)
        {
            if (!ModelState.IsValid) {
                ViewBag.AudioTypes = _repoWrapper.audioTypeRepository.List().ToList();
                ViewBag.Categories = (List<SelectListItem>)_repoWrapper.categoryRepository.List().Select(x => new SelectListItem { Value = x.CategoryId.ToString(), Text = x.NameAr }).ToList();

                return View("AddEdit", model);
            }
            
            try
            {
                if (model.AudioId == 0)
                    _repoWrapper.audioRepository.Add(model);
                else
                    _repoWrapper.audioRepository.Update(model);

                _repoWrapper.audioRepository.Commit();
                _cache.Remove(AudioCacheKey);
            }
            catch (Exception ex)
            {
                return Json("-1");
            }
      
            return Json("1");
        }


        public ActionResult GetAudio()
        {
            return PartialView("_Audio", new Audio { AudioSrc="0"});
        }

        public ActionResult GetRecord()
        {
            return PartialView("_Record", new Audio { AudioSrc = "0" });
        }
        public IActionResult DeleteAudio(int id)
        {
            var audio = _repoWrapper.audioRepository.Find(id);
            if (audio.PodcastAudios.Count() > 0 )
                return Json("-1");
            audio.IsDeleted = true;
            _repoWrapper.audioRepository.Update(audio);
            _repoWrapper.audioRepository.Commit();
            _cache.Remove(AudioCacheKey);
            return Json("1");
        }

        public IActionResult ChangeStatus(int id)
        {
            var audio = _repoWrapper.audioRepository.Find(id);
            audio.ApproveStatus = !audio.ApproveStatus;
            _repoWrapper.audioRepository.Update(audio);
            _repoWrapper.audioRepository.Commit();
            _cache.Remove(AudioCacheKey);
            return Json("1");
        }

        public IActionResult Details(int? Id)
        {
            if (!Id.HasValue && Id == 0)
                return RedirectToAction("NotFound", "Home");
            var model = _repoWrapper.audioRepository.GetAudioDetails((int)Id);
            if (model == null)
                return RedirectToAction("NotFound", "Home");
            return View(model);
        }

        public IActionResult GetPodcastAudio(int id)
        {
            var model = _repoWrapper.audioRepository.GetAllPodcastAudioData(id);
            return PartialView("_GetPodcastAudio", model);
        }
        public IActionResult AudioRate(int? Id)
        {
            if (!Id.HasValue && Id == 0)
                return RedirectToAction("NotFound", "Home");    
            ViewBag.audioName=  _repoWrapper.audioRepository.GetAudioDetails((int)Id).BookNameAr;
            return View((int)Id);
        }
        public IActionResult ListAudioRate(int page = 1,int audioId=0)
        {
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            ViewBag.audioId = audioId;
            var model = _repoWrapper.audioActionRepository.List().Where(x => x.AudioId == audioId && x.Rate>0).ToPagedList(page, ItemPerPage);
            return PartialView("_ListAudioRate", model);
        }
        public IActionResult ChangeAudioRateApprove(int id,bool flag)
        {
            var action = _repoWrapper.audioActionRepository.Find(id);
            action.ApproveRate = flag;
            _repoWrapper.audioActionRepository.Update(action);
            _repoWrapper.audioActionRepository.Commit();
            return Json(new { code = "1", id = action.AudioId });
        }
    }
}
