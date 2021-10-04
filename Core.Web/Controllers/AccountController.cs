using AutoMapper;
using Core.Data;
using Core.Model;
using Core.Service;
using Core.Web.Models;
using Core.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Web.Controllers
{
    public class AccountController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        private IServiceWrapper _serviceWrapper;
        public readonly IDataProtector _protector;
        public readonly IConfiguration _configuration;

        private readonly IStringLocalizer<AccountController> _localizer;
        private readonly IMapper _mapper;
        public readonly int langId;
        public AccountController(IConfiguration configuration, IDataProtectionProvider provider, IMapper mapper, IRepositoryWrapper repoWrapper, IServiceWrapper serviceWrapper, IStringLocalizer<AccountController> localizer)
        {
            _localizer = localizer;
            _repoWrapper = repoWrapper;
            _protector = provider.CreateProtector("AudioWeb");
            _configuration = configuration;
            _serviceWrapper = serviceWrapper;
            _localizer = localizer;
            _mapper = mapper;
            langId = int.Parse(_localizer.GetString("langId"));
        }


        public UserData CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var claims = User.Claims;
                    return new UserData
                    {
                        UserId = int.Parse(claims?.FirstOrDefault(x => x.Type.Equals("ClientId", StringComparison.OrdinalIgnoreCase))?.Value),
                        Email = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase))?.Value,
                        Name = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name, StringComparison.OrdinalIgnoreCase))?.Value,
                        Image = claims?.FirstOrDefault(x => x.Type.Equals("Image", StringComparison.OrdinalIgnoreCase))?.Value,
                    };
                }
                else
                {
                    return null;
                }
            }
        }


        public IActionResult Login()
        {
            ViewBag.IsLogin = false;
            ViewBag.AudioDesc = _serviceWrapper.SettingService.GetDesc(langId);
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var client = _serviceWrapper.clientService.ValidateClient(model.Email, model.Password);
                if (client != null)
                {
                    if (client.IsEmailVerified == false)
                        return Json(-2);

                    if (client.IsActive == false)
                        return Json(-3);

                    var clientClaims = new List<Claim>()
                    {
                        new Claim("ClientId",client.ClientId.ToString()),
                        new Claim("ClientKey",client.Key),
                        new Claim(ClaimTypes.Name, client.FullName),
                        new Claim(ClaimTypes.Email,client.Email),
                        new Claim("Image",client.Image??" "),
                        new Claim("Phone",client.Phone??" ")

                    };

                    var userIdentity = new ClaimsIdentity(clientClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    return Json(1);
                }
                else
                {
                    return Json(-1);
                }
            }
            return Json(0);
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            ViewBag.Cities = _serviceWrapper.CityService.GetSelectCities(langId);
            return PartialView("_Register");
        }
        public ActionResult ResetPassword(string key)
        {

            var client = _serviceWrapper.clientService.GetClient(int.Parse(_protector.Unprotect(key)));
            if (client != null)
                return View("ResetPassword", new ResetPasswordView() { Key = key });
            return View("notFound");
        }
        [HttpPost]
        public ActionResult Register(RegisterVM registerVM)
        {
            string res = _serviceWrapper.clientService.ValidateRegisterdClient(registerVM.Email, registerVM.Password);
            if (res != "1")
                return Json(res);
            else
            {
                Client newClient = _mapper.Map<Client>(registerVM);
                newClient.RegisterationDate = DateTime.Now;
                newClient.CreationDate = DateTime.Now;
                _serviceWrapper.clientService.CreateClient(newClient);

                //send Email
                string WebUrl = _configuration.GetValue<string>("WebUrl");
                string url = @WebUrl + "Account/ActivationAccount?key=" + _protector.Protect(newClient.ClientId.ToString());
                MailRequest request = new MailRequest { Subject = _localizer.GetString("audioketab"), ToEmail = registerVM.Email, Body = "To Activation Account click on link <a href='" + url + "'>Click</a>" };
                _serviceWrapper.MailService.SendEmailAsync(request);
            }
            return Json("1");
        }

        public IActionResult ActivationAccount(string key)
        {
            var client = _serviceWrapper.clientService.GetClient(int.Parse(_protector.Unprotect(key)));
            if (client != null && !client.IsEmailVerified)
            {
                client.IsEmailVerified = true;
                client.IsActive = true;
                _serviceWrapper.clientService.UpdateClient(client);
                _serviceWrapper.clientService.SaveClient();

                SetClaimsToClient(client);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordView resetPasswordView)
        {
            if (ModelState.IsValid)
            {
                var client = _serviceWrapper.clientService.GetClient(int.Parse(_protector.Unprotect(resetPasswordView.Key)));
                client.Password = resetPasswordView.Password;
                _serviceWrapper.clientService.UpdateClient(client);
                _serviceWrapper.clientService.SaveClient();

                SetClaimsToClient(client);
                return Json(1);
            }

            return Json(-1);

        }


        [HttpPost]
        public IActionResult ForgetPassword(string email)
        {
            var client = _serviceWrapper.clientService.GetClientByEmail(email);
            if (client != null)
            {
                try
                {
                    string WebUrl = _configuration.GetValue<string>("WebUrl");
                    string url = @WebUrl + "Account/ResetPassword?key=" + _protector.Protect(client.ClientId.ToString());
                    MailRequest request = new MailRequest { Subject = _localizer.GetString("audioketab"), ToEmail = email, Body = "To reset password click on link <a href='" + url + "'>Click</a>" };
                    _serviceWrapper.MailService.SendEmailAsync(request);
                    ViewBag.recoveryEmail = email;
                    return Json(1);
                }
                catch (Exception ex)
                {
                    return Json(-2);
                }

            }
            return Json(-1);
        }

        public void SetClaimsToClient(Client client)
        {
            var clientClaims = new List<Claim>()
                    {
                        new Claim("ClientId",client.ClientId.ToString()),
                        new Claim("ClientKey",_protector.Protect(client.ClientId.ToString())),
                        new Claim(ClaimTypes.Name, client.FullName),
                        new Claim(ClaimTypes.Email,client.Email),
                        new Claim("Image",client.Image??" "),
                        new Claim("Phone",client.Phone??" "),

                    };

            var userIdentity = new ClaimsIdentity(clientClaims, "User Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
            HttpContext.SignInAsync(userPrincipal);
        }


        public IActionResult EditProfile()
        {
            ViewBag.Cities = _serviceWrapper.CityService.GetSelectCities(langId);

            ClientViewModel model = _serviceWrapper.clientService.GetClientData(CurrentUser.UserId,0);
            return View(new EditProfileModel
            {
                Key = model.Key,
                ClientId = model.ClientId,
                CityId = model.CityId,
                Email = model.Email,
                FullName = model.FullName,
                FullNameEn = model.FullNameEn,
                FirstName = model.FirstName,
                LastName = model.LastName,
                HiddenOldPassword = model.Password,
                Phone = model.Phone,
                Image = model.Image
            });
        }

        [HttpPost]
        public IActionResult EditProfile(EditProfileModel model)
        {
            if (ModelState.IsValid)
            {
                var clientVM = _serviceWrapper.clientService.ValidateClient(model.Email, model.OldPassword);
                if (clientVM == null)
                    return Json("-2");


                Client client = _serviceWrapper.clientService.GetClient(int.Parse(_protector.Unprotect(model.Key)));
                client.CityId = model.CityId;
                client.Email = model.Email;
                client.FirstName = model.FirstName;
                client.LastName = model.LastName;
                client.FullName = model.FullName;
                client.FullNameEn = model.FullNameEn;
                client.Phone = model.Phone;
                client.Image = model.Image;

                if (model.NewPassword != model.OldPassword)
                    client.Password = model.NewPassword;

                _serviceWrapper.clientService.UpdateClient(client);
                _serviceWrapper.clientService.SaveClient();
                SetClaimsToClient(client);

                return Json("1");

            }
            return Json("-1");
        }


    }
}
