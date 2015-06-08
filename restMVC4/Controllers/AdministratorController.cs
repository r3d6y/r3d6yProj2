using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restMVC4.Controllers
{
    public class AdministratorController : BaseController
    {
        public AdministratorController()
            : base(new Services.Services())
        {

        }
        //
        // GET: /Administrator/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult Administrate()
        {
            if (Session["UserName"] != null)
            {
                var user = services.ClientService.GetByEmail(Session["UserName"].ToString());
                if (user.IsAdmin == null ? false : (bool)user.IsAdmin)
                    return View();
                else
                    return RedirectToAction("Inex", "Home");
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
