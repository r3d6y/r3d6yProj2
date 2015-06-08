using restMVC4.Models;
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

        [Authorize]
        [HttpGet]
        public ActionResult ManageRest()
        {
            List<RestaurantModel> model = services.RestService.GetRestaurants().Select(x => new RestaurantModel(x)).ToList();//= new List<RestaurantModel>();
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ManageDish()
        {
            List<DishModel> model = services.DishService.GetDishes().Select(x => new DishModel(x)).ToList();
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ManageProduct()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddNewRest()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddNewRest(RestaurantModel model)
        {
            services.RestService.AddRest(model);
            return RedirectToAction("ManageRest", "Administrator");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddNewDish()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult ManageCategory()
        {
            List<CategoryModel> model;
            return View();
        }
    }
}
