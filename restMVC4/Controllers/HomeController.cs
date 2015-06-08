using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace restMVC4.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public HomeController()
            : base(new Services.Services())
        {

        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Restaurants()
        {
            return View();
        }

        public ActionResult Dishes()
        {
            return View();
        }

        public ActionResult Basket()
        {
            return View();
        }

    }
}
