using restMVC4.Models;
using restMVC4.Repositories;
using restMVC4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly BaseRepository<Restaurants> restRepository;

        public RestaurantService()
        {
            restRepository = new BaseRepository<Restaurants>();
        }


        public IEnumerable<Restaurants> GetRestaurants()
        {
            return restRepository.ToList();
        }

        public void AddRest(RestaurantModel model)
        {
            Restaurants rest = new Restaurants();
            rest.Address = model.Address;
            rest.Phone = model.Phone;
            rest.TitleRestaurant = model.Title;

            restRepository.Insert(ref rest);
        }
    }
}