using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Models
{
    public class DishModel
    {

        public DishModel()
        {

        }

        public DishModel(Dish model)
        {
            Id = model.IdDish;
            Name = model.NameDish;
            Weight = model.Weight;
            Price = model.Price;
            IdRest = model.IdRestaurant;
            IdCategory = model.IdCategory;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }
        public int IdRest { get; set; }
        public int IdCategory { get; set; }
    }
}