
using Core.Data;
using Core.Model;
using Core.Service;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Controllers
{
    public class SettingController : BaseController
    {

        private IServiceWrapper _serviceWrapper;
      
        public SettingController(IConfiguration configuration, IServiceWrapper serviceWrapper, IRepositoryWrapper repoWrapper, IMemoryCache cache, IWebHostEnvironment webHostEnvironment, IStringLocalizer<BaseController> localizer, IDataProtectionProvider provider) : base(configuration, provider, repoWrapper, webHostEnvironment, localizer)
        {
            _serviceWrapper = serviceWrapper;
     

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View(_serviceWrapper.SettingService.GetAboutUs());
        }


        public IActionResult ContactUs()
        {
            return View(_serviceWrapper.SettingService.GetSetting()??new Setting { });
        }


        [HttpPost]
        public IActionResult SendMessage(ContactUs model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _serviceWrapper.SettingService.AddContactUs(model);
                    _serviceWrapper.SettingService.Save();  

                    //send Email                 "repoteq.test@gmail.com"
                    MailRequest request = new MailRequest { Subject = model.Title + " _ AudioKetab", ToEmail = "emanshaker381@gmail.com", Body = "From " + model.Email + model.Message };
                    _serviceWrapper.MailService.SendEmailAsync(request);

                    return Json("1");
                }
                catch (Exception ex)
                {
                    return Json("-2");

                }

            }
            return Json("-1");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TermsAndCondition()
        {
            return View();
        }
    }
}
