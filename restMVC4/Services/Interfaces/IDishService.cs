﻿using restMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restMVC4.Services.Interfaces
{
    public interface IDishService
    {
        IEnumerable<Dish> GetDishes();
        void AddDish(DishModel model);
        void AddToBasket(int dishId, int userId);
        Dish GetDishById(int id);
        void BuyDishes(List<BasketKeyValueModel> usersDihses, Client user);
    }
}
