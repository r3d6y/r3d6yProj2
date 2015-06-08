using restMVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restMVC4.Services.Interfaces
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurants> GetRestaurants();
        void AddRest(RestaurantModel model);
    }
}
