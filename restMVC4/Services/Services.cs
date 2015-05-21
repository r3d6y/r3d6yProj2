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

        public IClientService ClientService
        {
            get
            {
                return clientService = clientService ?? new ClientService();
            }
        }
    }
}