using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Admin.Controllers
{
    public class AboutUsController : BaseController
    {
        private IRepositoryWrapper _repoWrapper;
 
        public AboutUsController(IRepositoryWrapper repoWrapper, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
        }
        public IActionResult Index()
        {
            var model = _repoWrapper.aboutUsRepository.GetAboutUs();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(AboutUs model)
        {
            if (model.AboutUsId == 0)
                _repoWrapper.aboutUsRepository.Add(model);
            else
                _repoWrapper.aboutUsRepository.Update(model);
            _repoWrapper.aboutUsRepository.Commit();
            return Json("1");
        }
    }
}
