using restMVC4.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restMVC4.Services
{
    public class Services : IService
    {
        public Services()
        {

        }

        private IClientService clientService;
        private IRestaurantService restService;
        private IDishService dishService;
        private ICategoryService categoryService;

        public IClientService ClientService
        {
            get
            {
                return clientService = clientService ?? new ClientService();
            }
        }

        public IRestaurantService RestService
        {
            get
            {
                return restService = restService ?? new RestaurantService();
            }
        }

        public IDishService DishService
        {
            get
            {
                return dishService = dishService ?? new DishService();
            }
        }

        public ICategoryService CategoryService
        {
            get
            {
                return categoryService = categoryService ?? new CategoryService();
            }
        }
    }
}