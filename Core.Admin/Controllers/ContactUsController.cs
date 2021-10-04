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
    public class ContactUsController : BaseController
    {
        private const string ContactUsCacheKey = "ContactUs-cache-key";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private IRepositoryWrapper _repoWrapper;

        public ContactUsController(IRepositoryWrapper repoWrapper, IMemoryCache cache, IMapper mapper,  IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _cache = cache;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListContactUs(int page = 1)
        {
            IList<ContactUs> ContactUs;
            ViewBag.type = 1;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            //if (_cache.TryGetValue(ContactUsCacheKey, out IList<ContactUs> _ContactUs))
            //{
            //    ContactUs = _ContactUs;
            //}
            //else
            //{
            //    ContactUs = _repoWrapper.contactUsRepository.List().ToList();
            //    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
            //    _cache.Set(ContactUsCacheKey, ContactUs, cacheEntryOptions);
            //}
            ContactUs = _repoWrapper.contactUsRepository.List().ToList();
            ContactUsVModel model = new ContactUsVModel { ContactUs = ContactUs.ToPagedList(page, ItemPerPage), SearchContactUsVModel = new SearchContactUsVModel { } };
            return PartialView("_ListContactUs", model);
        }
        [HttpPost]
        public ActionResult SearchContactUs(SearchContactUsVModel model, int page = 1)
        {
            IList<ContactUs> ContactUs;

            ViewBag.type = 2;
            ViewBag.index = ItemPerPage * (page - 1) + 1;
            if (_cache.TryGetValue(ContactUsCacheKey, out IList<ContactUs> _ContactUs))
            {
                ContactUs = _ContactUs;
            }
            else
            {
                ContactUs = _repoWrapper.contactUsRepository.List().ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(2));
                _cache.Set(ContactUsCacheKey, ContactUs, cacheEntryOptions);
            }
            ContactUsVModel ContactUsVModel = new ContactUsVModel { ContactUs = ContactUs.Where(x => (string.IsNullOrEmpty(model.Name) || x.Name.Contains(model.Name) ) &&
                                                            (string.IsNullOrEmpty(model.Email) || x.Email.Contains(model.Email))).ToPagedList(page, 50), SearchContactUsVModel = model };
            return PartialView("_ListContactUs", ContactUsVModel);
        }

   

    }
}
