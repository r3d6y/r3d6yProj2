using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using restMVC4.Models;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace restMVC4.Controllers
{
    public class ClientController : BaseController
    {
        public ClientController()
            :base(new Services.Services())
        {

        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogInModel user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect.");
                }
            }
            return RedirectToAction("Index", "Home");//View("Index", "Home");
        }

        [HttpPost]
        public ActionResult LoginAjax(string email, string password)
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //var model = js.Deserialize<LoginJsonMode>(data);
            if (IsValid(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);
                ViewBag.UserName = email;
                //return RedirectToAction("Index", "Home");
                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                var JsonResult = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(true, settings),
                    ContentType = "application/json"
                };
                return JsonResult;
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect.");
                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                var JsonResult = new ContentResult
                {
                    Content = JsonConvert.SerializeObject(false, settings),
                    ContentType = "application/json"
                };
                return JsonResult;
                //return RedirectToAction("Index", "Home");
            }
            //return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(ClientModel user)
        {
            if (ModelState.IsValid)
            {
                Session["UserId"] = null;
                var userEmaiValid = services.ClientService.GetByEmail(user.Mail);
                if (userEmaiValid == null)
                {
                    var crypto = new PBKDF2();
                    var encrPass = crypto.Compute(user.Password);
                    user.Password = encrPass;
                    user.PasswordSalt = crypto.Salt;

                    var _user = services.ClientService.Insert(user);
                    Session["UserId"] = _user.IdClient;
                    return RedirectToAction("RegistrationPacientStep", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Email уже используется");
                }
            }
            else
            {
                ModelState.AddModelError("", "Reg data invalid.");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }
        private bool IsValid(string email, string password)
        {
            bool isValid = false;
            var crypto = new PBKDF2();

            var user = services.ClientService.GetByEmail(email);
            if(user != null)
            {
                if (user.Password == crypto.Compute(password, user.PasswordSalt))
                    isValid = true;
                Session["UserName"] = user.Mail;
            }

            return isValid;
        }

    }
}
