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
        private readonly BaseRepository<Basket> basketRepository;
        private readonly BaseRepository<Order> orderRepository;

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

        public void AddToBasket(int dishId, int userId)
        {

        }

        public Dish GetDishById(int id)
        {
            return dishRepository.FirstOrDefault(x => x.IdDish == id);
        }

        public void BuyDishes(List<BasketKeyValueModel> usersDihses, Client user)
        {
            Order order = new Order();
            order.IdClient = user.IdClient;
            order.AddressDelivery = "user " + user.Mail + " address";
            order.DateOrder = DateTime.Now;
            order.DateDelivery = DateTime.Now;
            order.Payment = "Mastercard";
            order.Implementation = "In progress";

            orderRepository.Insert(ref order);
        }
    }
}