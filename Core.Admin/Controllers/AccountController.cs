using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Core.Admin.Models;
using Core.Admin.Models.ViewModels;
using Core.Data;
using Core.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.Admin.Controllers
{
    public class AccountController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public AccountController(IRepositoryWrapper repoWrapper) 
        {
            _repoWrapper = repoWrapper;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = _repoWrapper.userRepository.ValidateUser(model.Email, model.Password);
                if (user != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim("UserId",user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim("UserType",user.UserType.Name),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim("Image",user.Image)
                    };

                    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    return Json(1);
                }
                else
                {
                    return Json(-1);
                }
                
            }
            return Json(-1);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        [Authorize]
        public IActionResult profile()
        {
            return View();
        }
        public IActionResult ChangePhoto(int id)
        {
            var user = _repoWrapper.userRepository.Find(id);

            return PartialView("_ChangePhoto", new ChangeImageView() { Id = user.UserId, Image = user.Image });
        }

        [HttpPost]
        public IActionResult ChangePhoto(ChangeImageView model)
        {
            var user = _repoWrapper.userRepository.Find(model.Id);
            user.Image = model.Image;
            _repoWrapper.userRepository.Update(user);
            _repoWrapper.userRepository.Commit();
            string imgSrc = string.IsNullOrEmpty(user.Image) ? "/images/user4.png" : "/Attachments/Images/" + user.Image;
            return Json(new { code="1",imgSrc= imgSrc });
        }
        public ActionResult ResetPassword(int id)
        {
            var user = _repoWrapper.userRepository.Find(id);

            return PartialView("_ResetPassword", new ResetPasswordView() { Email = user.Email, Id = user.UserId });

        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordView resetPasswordView)
        {
            var user = _repoWrapper.userRepository.Find(resetPasswordView.Id);
            user.Password = resetPasswordView.Password;
            _repoWrapper.userRepository.Update(user);
            _repoWrapper.userRepository.Commit();
            //var userClaims = new List<Claim>()
            //        {
            //            new Claim("UserId",user.UserId.ToString()),
            //            new Claim(ClaimTypes.Name,user.Name),
            //            new Claim("UserType",user.UserType.Name),
            //            new Claim(ClaimTypes.Email,user.Email),
            //            new Claim("Image",user.Image)
            //        };

            //var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            //var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
            //HttpContext.SignInAsync(userPrincipal);


            return Json("1");

        }
    }
}
