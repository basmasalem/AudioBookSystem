using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Core.Admin.Models.ViewModels;

namespace Core.Admin.Controllers
{
    
    public class HomeController : BaseController
    {  
        private IRepositoryWrapper _repoWrapper;

        public HomeController(IRepositoryWrapper repoWrapper, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
   
        }
        public IActionResult Index()
        {
            HomeVModel model = new HomeVModel {
                ArticleCount = _repoWrapper.articleRepository.GetArticleCount(),
                AudioCount = _repoWrapper.audioRepository.GetAudioCount(),
                AudioTypeCount = _repoWrapper.audioTypeRepository.GetAudioTypeCount(),
                CategoryCount = _repoWrapper.categoryRepository.GetCategoryCount(),
                ClientCount= _repoWrapper.clientRepository.GetClientCount(),
                PodcastCount= _repoWrapper.podcastRepository.GetPodcastCount(),
                TagCount= _repoWrapper.tagRepository.GetTagCount()

            };
            return View(model);
        }

        public IActionResult Navbar()
        {
            return PartialView("_Navbar");
        }
        public IActionResult GetCategories()
        {
            var model = _repoWrapper.categoryRepository.GetLatestCategory();
            return PartialView("_GetCategories",model);
        }
        public IActionResult GetTags()
        {
            var model = _repoWrapper.tagRepository.GetLatestTags();
            return PartialView("_GetTags",model);
        }
        public IActionResult GetPodcasts()
        {
            var model = _repoWrapper.podcastRepository.GetLatestPodcast();
            return PartialView("_GetPodcasts", model);
        }
        public IActionResult CheckImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckImage(int img)
        {
            int xx = img;
            return View();
        }

        public IActionResult NotFound()
        {
            return View();
        }
    }
}
