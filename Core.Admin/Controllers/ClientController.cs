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
    public class ClientController : BaseController
    {
        private const string ClientCacheKey = "Client-cache-key";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        private IRepositoryWrapper _repoWrapper;
        public ClientController(IRepositoryWrapper repoWrapper, IMemoryCache cache, IMapper mapper, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListClient(int page = 1)
        {
            IList<Client> Clients;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            //if (_cache.TryGetValue(ClientCacheKey, out IList<Client> _Initiatives))
            //{
            //    Clients = _Initiatives;
            //}
            //else
            //{
            //    Clients = _repoWrapper.clientRepository.List().ToList();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(ClientCacheKey, Clients, cacheEntryOptions);
            //}
            Clients = _repoWrapper.clientRepository.List().ToList();
            ClientVModel model = new ClientVModel { Clients = Clients.ToPagedList(page, ItemPerPage), SearchClientVModel = new SearchClientVModel { } };
            return PartialView("_ListClient", model);
        }
        [HttpPost]
        public ActionResult SearchClient(SearchClientVModel model, int page = 1)
        {
            IList<Client> Clients;

            ViewBag.type = 2;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(ClientCacheKey, out IList<Client> _Clients))
            {
                Clients = _Clients;
            }
            else
            {
                Clients = _repoWrapper.clientRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(ClientCacheKey, Clients, cacheEntryOptions);
            }
            ClientVModel ClientVModel = new ClientVModel { Clients = Clients.Where(x => (string.IsNullOrEmpty(model.Name) || x.FullName.Contains(model.Name) || x.FirstName.Contains(model.Name) || x.LastName.Contains(model.Name)) &&
            (string.IsNullOrEmpty(model.Email) || x.Email.Contains(model.Email))).ToPagedList(page, 50), SearchClientVModel = model };
            return PartialView("_ListClient", ClientVModel);
        }

        public IActionResult Details(int? Id)
        {
            if (!Id.HasValue && Id == 0)
                return RedirectToAction("NotFound", "Home");
            var model = _repoWrapper.clientRepository.GetClientData((int)Id);
            if (model == null)
                return RedirectToAction("NotFound", "Home");
            return View(model);
        }
        public IActionResult GetClientPlayList(int Id)
        {
            var model = _repoWrapper.clientRepository.GetClientPlayList(Id);
            return PartialView("_GetClientPlayList",model);
        }
        public IActionResult GetClientTag(int Id)
        {
            var model = _repoWrapper.clientRepository.GetClientTags(Id);
            return PartialView("_GetClientTag", model);
        }
        public IActionResult DeleteClient(int id)
        {
            var Client = _repoWrapper.clientRepository.Find(id);
            if (Client.PodcastParticipants.Where(x=>x.IsDeleted!=true).Count() > 0 || Client.ClientPlaylists.Where(x=>x.IsDeleted!=true).Count()>0 || Client.ClientTags.Where(x=>x.IsDeleted!=true).Count()>0)
                return Json("-1");
            _repoWrapper.clientRepository.Delete(Client);
             _repoWrapper.clientRepository.Commit();
            _cache.Remove(ClientCacheKey);
            return Json("1");
        }
        public IActionResult ChangeStatus(int id)
        {
            var Client = _repoWrapper.clientRepository.Find(id);
            Client.IsActive = !Client.IsActive;
            _repoWrapper.clientRepository.Update(Client);
            _repoWrapper.clientRepository.Commit();
            _cache.Remove(ClientCacheKey);
            return Json("1");
        }
        public JsonResult CheckExistingEmail(string Email, int ClientId)
        {
            var res = _repoWrapper.clientRepository.CheckEmail(Email);
            if (res != null)
            {
                if (res.ClientId != ClientId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        public JsonResult CheckExistingNameAr(string NameAr, int ClientId)
        {
            var res = _repoWrapper.clientRepository.CheckNameAr(NameAr);
            if (res != null)
            {
                if (res.ClientId != ClientId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }

        public JsonResult CheckExistingNameEn(string NameEn, int ClientId)
        {
            var res = _repoWrapper.clientRepository.CheckNameEn(NameEn);
            if (res != null)
            {
                if (res.ClientId != ClientId)
                {
                    return Json(false);
                }
            }
            return Json(true);
        }
    }
}
