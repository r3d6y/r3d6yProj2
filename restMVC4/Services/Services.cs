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
    }
}