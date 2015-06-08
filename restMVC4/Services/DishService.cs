using restMVC4.Models;
using restMVC4.Repositories;
using restMVC4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Services
{
    public class DishService : IDishService
    {
        private readonly BaseRepository<Dish> dishRepository;

        public DishService()
        {
            dishRepository = new BaseRepository<Dish>();
        }

        public IEnumerable<Dish> GetDishes()
        {
            return dishRepository.ToList();
        }

        public void AddDish(DishModel model)
        {
            var dish = new Dish();
            dish.IdCategory = model.IdCategory;
            dish.IdRestaurant = model.IdRest;
            dish.NameDish = model.Name;
            dish.Price = model.Price;
            dish.Weight = model.Weight;

            dishRepository.Insert(ref dish);
        }
    }
}