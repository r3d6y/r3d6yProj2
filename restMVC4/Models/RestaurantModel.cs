using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Models
{
    public class RestaurantModel
    {
        public RestaurantModel()
        {

        }

        public RestaurantModel(Restaurants model)
        {
            Id = model.IdRestaurant;
            Title = model.TitleRestaurant;
            Address = model.Address;
            Phone = model.Phone;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}