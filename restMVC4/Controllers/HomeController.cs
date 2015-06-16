using restMVC4.Models;
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
            List<RestaurantModel> model = services.RestService.GetRestaurants().Select(x => new RestaurantModel(x)).ToList();
            return View(model);
        }

        public ActionResult Dishes(int id)
        {
            List<DishModel> model = services.DishService.GetDishes().Where(x => x.IdRestaurant == id).Select(x => new DishModel(x)).ToList();
            return View(model);
        }

        public ActionResult AddToBasket(int id)
        {
            int restId = services.DishService.GetDishes().FirstOrDefault(x => x.IdDish == id).IdRestaurant;
            if(Session["UsersDishes"] == null)
            {
                List<BasketKeyValueModel> usersDihses = new List<BasketKeyValueModel>();
                usersDihses.Add(new BasketKeyValueModel
                {
                    id = id,
                    count = 1
                });
                Session["UsersDishes"] = usersDihses;
            }
            else
            {
                List<BasketKeyValueModel> usersDihses = (List<BasketKeyValueModel>)Session["UsersDishes"];
                if(usersDihses.FirstOrDefault(x => x.id == id) == null)
                    usersDihses.Add(new BasketKeyValueModel { 
                    id = id,
                    count = 1
                    });
                else
                {
                    var tmp = usersDihses.FirstOrDefault(x => x.id == id);
                    usersDihses.Remove(tmp);
                    tmp.count++;
                    usersDihses.Add(tmp);
                }
                Session["UsersDishes"] = usersDihses;
            }

            //string userMail = Session["UserName"].ToString();
            //var user = services.ClientService.GetByEmail(userMail);
            return RedirectToAction("Dishes", "Home", new { id = restId });
        }

        public ActionResult Basket()
        {
            List<BasketKeyValueModel> usersDihses;
            if (Session["UsersDishes"] != null)
                usersDihses = (List<BasketKeyValueModel>)Session["UsersDishes"];
            else
                usersDihses = new List<BasketKeyValueModel>();
            foreach (var ud in usersDihses)
                ud.dish = new DishModel(services.DishService.GetDishById(ud.id));
            return View(usersDihses);
        }

        public ActionResult Buy()
        {
            string userMail = Session["UserName"].ToString();
            var user = services.ClientService.GetByEmail(userMail);
            List<BasketKeyValueModel> usersDihses;
            if (Session["UsersDishes"] != null)
                usersDihses = (List<BasketKeyValueModel>)Session["UsersDishes"];
            else
                usersDihses = new List<BasketKeyValueModel>();
            services.DishService.BuyDishes(usersDihses, user);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult OneNews()
        {
            return View();
        }

        public ActionResult SpecialOffer()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
        }
        

    }
}
