using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace restMVC4.Models
{
    public class DishModel
    {

        public DishModel()
        {

        }

        public DishModel(IList<CategoryModel> cat, IList<RestaurantModel> rest)
        {
            Categories = cat.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Title
                });
            Restaurants = rest.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Title
            });
        }

        public DishModel(Dish model)
        {
            Id = model.IdDish;
            Name = model.NameDish;
            Weight = model.Weight;
            Price = model.Price;
            IdRest = model.IdRestaurant;
            IdCategory = model.IdCategory;
            Restaurant = model.Restaurants;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }
        public int IdRest { get; set; }
        public int IdCategory { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Restaurants { get; set; }

        public Restaurants Restaurant { get; set; }
    }
}