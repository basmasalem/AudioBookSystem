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
    public class SettingController : BaseController
    {
        private IRepositoryWrapper _repoWrapper;
        public SettingController(IRepositoryWrapper repoWrapper, IWebHostEnvironment webHostEnvironment) : base(repoWrapper, webHostEnvironment)
        {
            _repoWrapper = repoWrapper;
        }
        public IActionResult Index()
        {
            var model = _repoWrapper.settingRepository.GetSetting();
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(Setting model)
        {
            if (model.SettingId == 0)
                _repoWrapper.settingRepository.Add(model);
            else
                _repoWrapper.settingRepository.Update(model);
            _repoWrapper.settingRepository.Commit();
            return Json("1");
        }
    }
}
