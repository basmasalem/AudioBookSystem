using AutoMapper;
using Core.Data;
using Core.Model;
using Core.Service;
using Core.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Web.Controllers
{
    public class AudioController : BaseController
    {
        private IServiceWrapper _serviceWrapper;
        private IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;
        public AudioController(IConfiguration configuration, IServiceWrapper serviceWrapper, IRepositoryWrapper repoWrapper, IMapper mapper, IWebHostEnvironment webHostEnvironment, IStringLocalizer<BaseController> localizer, IDataProtectionProvider provider) : base(configuration, provider, repoWrapper, webHostEnvironment, localizer)
        {
            _serviceWrapper = serviceWrapper;
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }
        public IActionResult Index(string Category = "", string Name = "", string clientKey = "")
        {
            AudioSearchVM model = new AudioSearchVM() { Name = Name, ClientKey = clientKey };
            if (!string.IsNullOrEmpty(Category))
            {
                model.CategoryId = _serviceWrapper.categoryService.GetCategoryId(Category.Trim());
            }
            ViewBag.Categories = (List<SelectListItem>)_serviceWrapper.categoryService.GetSelectCategories(langId);
            ViewBag.Types = (List<SelectListItem>)_serviceWrapper.audioTypeService.GetSelectTypes(langId);
            return View(model);
        }
        public IActionResult ListSound(AudioSearchVM SearchAudio = null, int page = 1)
        {
            ViewBag.langId = langId;
            var data = _serviceWrapper.audioService.GetAudiosData();
            if (SearchAudio != null)
                data = data.Where(x => (string.IsNullOrEmpty(SearchAudio.Name) || x.BookNameAr.Contains(SearchAudio.Name) || x.BookNameEn.Contains(SearchAudio.Name) ||
                x.AuthorNameAr.Contains(SearchAudio.Name) || x.AuthorNameEn.Contains(SearchAudio.Name)) && (SearchAudio.CategoryId == 0 || x.CategoryId == SearchAudio.CategoryId) &&
                (SearchAudio.TypeId == 0 || x.TypeId == SearchAudio.TypeId) &&
                (string.IsNullOrEmpty(SearchAudio.ClientKey) || (x.CreatedBy == int.Parse(_protector.Unprotect(SearchAudio.ClientKey)) && x.PublishType == PublishType.Client))).ToList();

            ViewBag.Pagination = data.Count > EvenItemPerPage;
            AudioVM model = new AudioVM
            {
                Audios = data.ToPagedList(page, EvenItemPerPage),
                SearchAudio = SearchAudio
            };
            return PartialView("_ListSound", model);

        }

        [Authorize]
        public IActionResult AddAudio()
        {
            ViewBag.AudioTypes = _serviceWrapper.audioTypeService.GetSelectTypes(langId);
            ViewBag.Categories = _serviceWrapper.categoryService.GetSelectCategories(langId);
            ViewBag.Podcasts = _serviceWrapper.podcastService.GetSelectGeneralPodcasts(CurrentUser.UserId,langId);
            return View(new AudioModel { BookImage="0",AudioSrc="0"});
        }

        [HttpPost]
        public IActionResult AddAudio(AudioModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.AudioTypes = _serviceWrapper.audioTypeService.GetSelectTypes(langId);
                ViewBag.Categories = _serviceWrapper.categoryService.GetSelectCategories(langId);
                return View("AddEdit", model);
            }
            try
            {
                Audio audio = _mapper.Map<Audio>(model);
                audio.CreatedBy = CurrentUser.UserId;
                audio.PublishType = PublishType.Client;

                _repoWrapper.audioRepository.Add(audio);
                _repoWrapper.audioRepository.Commit();
                if (model.PodcastId != null)
                {
                    PodcastAudio podcastAudio = new PodcastAudio { AudioId=audio.AudioId,CreatedDate=DateTime.Now,PodcastId=model.PodcastId??0,CreatedBy=CurrentUser.UserId,};
                    _repoWrapper.podcastAudioRepository.Add(podcastAudio);
                    _repoWrapper.audioRepository.Commit();
                }
            }
            catch (Exception ex)
            {
                return Json("-1");
            }

            return Json("1");
        }
        [Authorize]
        public ActionResult Details(string Id)
        {
            ViewBag.langId = langId;
            if (string.IsNullOrEmpty(Id))
                return RedirectToAction("NotFound", "Home");
            try
            {
                var model = _serviceWrapper.audioService.GetAudio(int.Parse(_protector.Unprotect(Id)));
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

        public IActionResult ClientLike(int audioId, bool like)
        {
            AudioAction model;
            model = _serviceWrapper.AudioActionService.GetAudioAction(audioId, 2/*CurrentUser.UserId*/);
            if (model == null)
            {
                model = new AudioAction
                {
                    AudioId = audioId,
                    ClientId = CurrentUser.UserId,
                    Like = like
                };
                _serviceWrapper.AudioActionService.CreateAudioAction(model);
            }
            else
            {
                model.Like = !like;
                _serviceWrapper.AudioActionService.UpdateAudioAction(model);

            }
            _serviceWrapper.AudioActionService.SaveAudioAction();
            return Json(like ? false : true);
        }
        public IActionResult ClientShare(int SharedType, int SharedId, string redirectUrl)
        {
            if (SharedType == 2)
            {
                AudioAction model;
                model = _serviceWrapper.AudioActionService.GetAudioAction(SharedId, CurrentUser.UserId);
                if (model == null)
                {
                    model = new AudioAction
                    {
                        AudioId = SharedId,
                        ClientId = CurrentUser.UserId,
                        Share = 1
                    };
                    _serviceWrapper.AudioActionService.CreateAudioAction(model);
                }
                else
                {
                    model.Share = model.Share + 1;
                    _serviceWrapper.AudioActionService.UpdateAudioAction(model);

                }
                _serviceWrapper.AudioActionService.SaveAudioAction();
            }

            return Json(redirectUrl);
        }
        public IActionResult SaveClientListenAudio(string Id,string playlistId, string src)
        {
            int audioId;
            AudioAction model;
            if(playlistId=="0")
             audioId = int.Parse(_protector.Unprotect(Id));
            else
            {
                audioId = _serviceWrapper.PlaylistAudioService.GetAudioId(int.Parse(_protector.Unprotect(playlistId)), src);
            }
            model = _serviceWrapper.AudioActionService.GetAudioAction(audioId, 2/*CurrentUser.UserId*/);
            if (model == null)
            {
                model = new AudioAction
                {
                    AudioId = audioId,
                    ClientId = CurrentUser.UserId,
                    Listen = true
                };
                _serviceWrapper.AudioActionService.CreateAudioAction(model);
                _serviceWrapper.AudioActionService.SaveAudioAction();

            }
            else if(model.Listen!=true)
            {
                model.Listen = true;
                _serviceWrapper.AudioActionService.UpdateAudioAction(model);
                _serviceWrapper.AudioActionService.SaveAudioAction();

            }
            int res = _serviceWrapper.AudioActionService.GetListenersCount(audioId);
            return Json(res);
        }
        public IActionResult GetClientPlaylist(int audioId)
        {
            ViewBag.AudioId = audioId;
            var model = _serviceWrapper.ClientPlaylistService.GetClientPlaylistsByAudio(/*CurrentUser.UserId*/2, audioId);
            return PartialView("_GetClientPlaylist", model);
        }
        [HttpPost]
        public IActionResult SaveClientPlaylist(ClientPlaylist model, int audioId)
        {
            model.ClientId = CurrentUser.UserId;
            model.CreationDate = DateTime.Now;
            _serviceWrapper.ClientPlaylistService.CreateClientPlaylist(model);
            _serviceWrapper.PlaylistAudioService.CreatePlaylistAudio(new PlaylistAudio
            {
                AudioId = audioId,
                ClientPlaylist = model
            });
            _serviceWrapper.ClientPlaylistService.SaveClientPlaylist();
            return Json(1);
        }

        [HttpPost]
        public IActionResult SaveAudioPlaylist(int playlistId, int audioId)
        {
            _serviceWrapper.PlaylistAudioService.CreatePlaylistAudio(new PlaylistAudio
            {
                AudioId = audioId,
                ClientPlaylistId = playlistId
            });
            _serviceWrapper.PlaylistAudioService.SavePlaylistAudio();
            return Json(1);
        }
        [HttpPost]
        public IActionResult RemoveClientPlaylistAudio(int audioId)
        {
            _serviceWrapper.PlaylistAudioService.DeletePlaylistAudioByAudioId(audioId, 2/*CurrentUser.UserId*/);
            return Json(1);
        }

        [Authorize]
        public IActionResult WriteComment(int AudioId, string Text)
        {
            _serviceWrapper.audioCommentService.CreateAudioComment(new AudioComment
            {
                AudioId = AudioId,
                ClientId = CurrentUser.UserId,
                CreationDate = DateTime.Now,
                Text = Text,
                IsActive = true,
            });
            _serviceWrapper.audioCommentService.SaveAudioComment();
            return RedirectToAction("GetAudioComments", new { AudioId = AudioId });
        }

        [Authorize]
        public IActionResult EditComment(int AudioCommentId, string Text)
        {
           AudioComment audioComment=   _serviceWrapper.audioCommentService.GetAudioComment(AudioCommentId);
            audioComment.Text = Text;
            _serviceWrapper.audioCommentService.UpdateAudioComment(audioComment);
            _serviceWrapper.audioCommentService.SaveAudioComment();
            return Json("1");
        }

        [Authorize]
        public IActionResult RemoveComment(int AudioCommentId)
        {
            _serviceWrapper.audioCommentService.DeleteAudioComment(AudioCommentId);
            return Json("1");
        }
        public IActionResult GetAudioComments(int AudioId)
        {
            ViewBag.audio = AudioId;
            return PartialView("~/Views/Shared/ComponentItem/_AudioCommentsItem.cshtml", _serviceWrapper.audioCommentService.GetAudioComments(AudioId, CurrentUser == null ? 0 : CurrentUser.UserId, langId));
        }
        public IActionResult GetAudioRate(string Id)
        {
            int audioId = int.Parse(_protector.Unprotect(Id));
            ViewBag.audioId = Id;
            var model = _serviceWrapper.AudioActionService.GetAudioRate(audioId, CurrentUser == null ? 0 : CurrentUser.UserId);
            return PartialView("_GetAudioRate", model);
        }
       
        public IActionResult SaveClientAudioRate(string Id,string rateText,int rate)
        {
            AudioAction model;
            int audioId = int.Parse(_protector.Unprotect(Id));
            model = _serviceWrapper.AudioActionService.GetAudioAction(audioId, CurrentUser.UserId);
            if (model == null)
            {
                model = new AudioAction
                {
                    AudioId = audioId,
                    ClientId = CurrentUser.UserId,
                    Rate = rate,
                    RateText=rateText
                };
                _serviceWrapper.AudioActionService.CreateAudioAction(model);

            }
            else
            {
                model.Rate = rate;
                model.RateText = rateText;
                _serviceWrapper.AudioActionService.UpdateAudioAction(model);

            }
            _serviceWrapper.AudioActionService.SaveAudioAction();
            return Json(1);
        }
        
        public IActionResult AudioCity(int cityId)
        {
            ViewBag.cityId = cityId;
            ViewBag.cityName = langId==1? _serviceWrapper.CityService.GetCity(cityId).NameAr : _serviceWrapper.CityService.GetCity(cityId).NameEn;
            return View();
        }
        public IActionResult AudioCityList(int page = 1, int cityId=0)
        {
            var Audios = _serviceWrapper.AudioActionService.GetCityAudio(cityId);
            ViewBag.Pagination = Audios.Count > EvenItemPerPage;
            ViewBag.langId = langId;
            return PartialView("_AudioCityList", Audios.ToPagedList(page, EvenItemPerPage));
        }

    }
}
