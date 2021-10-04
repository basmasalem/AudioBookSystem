using Core.Data;
using Core.Model;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Core.Web.Controllers
{
    public class ClientController : BaseController
    {
        private IServiceWrapper _serviceWrapper;

        public ClientController(IConfiguration configuration,IServiceWrapper serviceWrapper, IRepositoryWrapper repoWrapper, IWebHostEnvironment webHostEnvironment, IStringLocalizer<BaseController> localizer, IDataProtectionProvider provider) : base(configuration, provider, repoWrapper, webHostEnvironment, localizer)
        {
            _serviceWrapper = serviceWrapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientProfile(string key)
        {

            return View(_serviceWrapper.clientService.GetClientData(int.Parse(_protector.Unprotect(key)), (CurrentUser == null ? 0 : CurrentUser.UserId)));
        }

        public IActionResult ClientAudios(string key, int page = 1)
        {
            var clientAudios = _serviceWrapper.clientService.GetClientAudioWithComment(int.Parse(_protector.Unprotect(key)), langId, CurrentUser==null?0:CurrentUser.UserId);
            ViewBag.Pagination = clientAudios.Count > EvenItemPerPage;
            ViewBag.key = key; 
            return PartialView("_ClientAudios", clientAudios.ToPagedList(page, EvenItemPerPage) );
        }

        public IActionResult ClientAudioShare(string key)
        {
            var clientAudios = _serviceWrapper.clientService.GetClientAudioShare(int.Parse(_protector.Unprotect(key))).ToList();

            ViewBag.key = key;
            ViewBag.langId = langId;
            ViewBag.showAllOrNot = clientAudios.Count > 4 ? true : false;
            return PartialView("_ClientAudioShare", clientAudios.Count > 4 ? clientAudios.Take(4) : clientAudios);
        }

        
        public IActionResult ClientDetails(string key, string item)
        {
            ViewBag.Item = item;
            ViewBag.key = key;

            List<ReaderVM> model;
            if (item == "followers")
                model= _serviceWrapper.ClientFollowerService.GetSubscribers(int.Parse(_protector.Unprotect(key)));
            else
                model= _serviceWrapper.ClientFollowerService.GetFollowers(int.Parse(_protector.Unprotect(key)));

            ViewBag.showAllOrNot = model.Count > 4?true:false;
            ViewBag.Count = model.Count;
            return PartialView("_ClientDetailsItem", model.Count>4?model.Take(4):model);
        }

        public IActionResult ClientSubscribersModal(string key)
        {
            ViewBag.Item = "subscribers";
            return PartialView("_ClientDetailsModal", _serviceWrapper.ClientFollowerService.GetSubscribers(int.Parse(_protector.Unprotect(key))));
        }

        public IActionResult ClientFollowersModal(string key)
        {
            ViewBag.Item = "followers";
            return PartialView("_ClientDetailsModal", _serviceWrapper.ClientFollowerService.GetFollowers(int.Parse(_protector.Unprotect(key))));
        }

        [Authorize]
        public IActionResult ClientSubscribers()
        {
            return View();
        }

        public IActionResult ClientSubscribersList(int page=1)
        {
            ViewBag.IsDeleted = true;
            var subscribers = _serviceWrapper.ClientFollowerService.GetSubscribers(CurrentUser.UserId);
            ViewBag.Pagination = subscribers.Count > EvenItemPerPage;

            return PartialView("_ClientSubscribersList", subscribers.ToPagedList(page, EvenItemPerPage));
        }


        [Authorize]
        public IActionResult DeleteSubscriber(string key)
        {
            _serviceWrapper.ClientFollowerService.DeleteClientSubscriber(CurrentUser.UserId, int.Parse(_protector.Unprotect(key)));
            return RedirectToAction("ClientSubscribersList");
        }


        [Authorize]
        public IActionResult Favorite()
        {
            return View();
        }
        public IActionResult FavoriteList(int page = 1)
        {
            var Audios = _serviceWrapper.AudioActionService.GetFavoriteAudio(CurrentUser.UserId);
            ViewBag.Pagination = Audios.Count > EvenItemPerPage;
            ViewBag.langId = langId;
            ViewBag.IsLikePage = true;
            return PartialView("_FavoriteList", Audios.ToPagedList(page, EvenItemPerPage));
        }

        [Authorize]
        public IActionResult Playlist()
        {
            return View();
        }
        public IActionResult GetPlaylist(int page = 1)
        {
            var playlists = _serviceWrapper.ClientPlaylistService.GetClientPlaylists(CurrentUser.UserId);
            ViewBag.Pagination = playlists.Count > EvenItemPerPage;
            ViewBag.langId = langId;
            return PartialView("_GetPlaylist", playlists.ToPagedList(page, EvenItemPerPage));
        }

        [Authorize]
        public IActionResult PlaylistAudio(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return RedirectToAction("NotFound", "Home");
            try
            {
                var model = _serviceWrapper.ClientPlaylistService.GetClientPlaylist(int.Parse(_protector.Unprotect(Id)));
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

        [Authorize]
        public IActionResult RemovePlaylist(string playlistId)
        {
            int id = int.Parse(_protector.Unprotect(playlistId));
            _serviceWrapper.ClientPlaylistService.DeleteClientPlaylist(id);
            return Json(1);
        }

        [Authorize]
        public IActionResult GetPlaylistAudio(string Id,int page = 1)
        {
            int playlistId = int.Parse(_protector.Unprotect(Id));
            var audios = _serviceWrapper.ClientPlaylistService.GetAudios(playlistId);
            ViewBag.Pagination = audios.Count > EvenItemPerPage;
            ViewBag.langId = langId;
            ViewBag.playlistId = Id;
            return PartialView("_GetPlaylistAudio", audios.ToPagedList(page, EvenItemPerPage));
        }


        public IActionResult Readers()
        {     
            return View();
        }

        public IActionResult ReaderList(int page = 1)
        {
            var Readers = _serviceWrapper.clientService.GetReaders();
            ViewBag.Pagination = Readers.Count > EvenItemPerPage;

            return PartialView("_ReaderList", Readers.ToPagedList(page, EvenItemPerPage));
        }

        public IActionResult GetAudioSrcOfPlaylist(string playlistId)
        {
            int id = int.Parse(_protector.Unprotect(playlistId));
            string attachName = _configuration.GetValue<string>("AdminUrl")+"Attachments/Audios/";
            var res = _serviceWrapper.ClientPlaylistService.GetPlaylistAudiosSrc(id,attachName);
            return Json(res);
        }


        [Authorize]
        public IActionResult UnFollowClient(string key)
        {
           _serviceWrapper.ClientFollowerService.DeleteClientSubscriber(CurrentUser.UserId, int.Parse(_protector.Unprotect(key)));
            return Json("1");
        }


        [Authorize]
        public IActionResult FollowClient(string key)
        {
            _serviceWrapper.ClientFollowerService.Follow(CurrentUser.UserId, int.Parse(_protector.Unprotect(key)));
            return Json("1");
        }

    }
}
